using cacheImplementation.Repository.InterfaceRepository;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace cacheImplementation.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomAuthorizationFilter(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
 
            if (!TryExtractAuthorizationHeader(context.HttpContext, out string authorizationHeader))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!ValidateAuthorizationHeader(authorizationHeader)) // Replace with your validation logic
            {
                context.Result = new UnauthorizedResult();
                return;
            }

           
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated || !user.IsInRole("admin"))
            {
                context.Result = new ForbidResult();
                return;
            }
        }

        private bool TryExtractAuthorizationHeader(HttpContext httpContext, out string authorizationHeader)
        {
            authorizationHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();
            return !string.IsNullOrEmpty(authorizationHeader);
        }

        private bool ValidateAuthorizationHeader(string authorizationHeader)
        {
            return authorizationHeader.StartsWith("Bearer ");
        }
    }
}
