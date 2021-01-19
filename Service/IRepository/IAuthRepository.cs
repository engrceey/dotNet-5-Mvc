using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BHRUGEN_MVC.Service.IRepository
{
    public interface IAuthRepository
    {
        Task<int> Register(IdentityUser user, string password);
        Task<string> Login(string username, string password);
        
    }
}