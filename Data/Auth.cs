using System.Threading.Tasks;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0.Data
{
    public class Auth : IAuth
    {
        private readonly DataContext context;

        public Auth(DataContext context)
        {
            this.context = context;
        }

        public Task<Response<string>> Login(User user, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<int>> Register(User user, string password)
        {
            context.Add(user);
            throw new System.NotImplementedException();
        }

        public Task<bool> UserExists(User user, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}