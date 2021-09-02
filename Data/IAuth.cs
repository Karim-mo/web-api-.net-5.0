using System.Threading.Tasks;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Data
{
    public interface IAuth
    {
        Task<Response<int>> Register(User user, string password);
        Task<Response<string>> Login(User user, string password);
        Task<bool> UserExists(User user, string password);

    }
}