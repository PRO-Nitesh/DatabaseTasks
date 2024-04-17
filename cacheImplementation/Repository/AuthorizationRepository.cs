using ApiProject.Models;
using cacheImplementation.Data;
using cacheImplementation.Models;
using cacheImplementation.Repository.InterfaceRepository;
using System.Linq;

namespace cacheImplementation.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {

        private readonly combineContext _context;
        public AuthorizationRepository(combineContext context)
        {
            _context = context;
        }
        public async Task<Users> GetRole(int UserId)
        {
            Users user = null;
            user = _context.Users.Find(UserId);
            return user;
        }
    }
}
