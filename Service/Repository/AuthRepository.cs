using System.Threading.Tasks;
using BHRUGEN_MVC.Service.IRepository;
using Microsoft.AspNetCore.Identity;

namespace BHRUGEN_MVC.Service.Repository
{
    public class AuthRepository : IAuthRepository
    {
        public Task<string> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Register(IdentityUser user, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}