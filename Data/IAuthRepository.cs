using System.Threading.Tasks;
using netCore5.Migrations;
using netCore5.Models;
using User = Netcore5.Models.User;

namespace Netcore5.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}