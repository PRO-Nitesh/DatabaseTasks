using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using cacheImplementation.Repository.InterfaceRepository;

namespace cacheImplementation.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly IAuthorizationRepository _authorizationRepository;

        public AuthorizationFilter(IAuthorizationRepository authorizationRepository)
        {
            _authorizationRepository = authorizationRepository;
        }
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var userid = context.HttpContext.User.FindFirst(c => c.Type == "ID").Value;
            int userid1 = int.Parse(userid.ToString());
            var role = await _authorizationRepository.GetRole(userid1);
            if (role != null)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
