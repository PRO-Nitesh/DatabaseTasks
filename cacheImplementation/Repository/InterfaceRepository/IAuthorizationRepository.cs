using ApiProject.Models;
using cacheImplementation.Models;

namespace cacheImplementation.Repository.InterfaceRepository
{
    public interface IAuthorizationRepository
    {
        Task<Users> GetRole(int UserId);
    }
}
