using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    internal class User: IUser
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        private Server server { get; set; }
        public User(string email, string password, Server server)
        {
            this.Email = email;
            this.Password = password;
            this.server = server;
        }
        public void OpenWebsite()
        {
            Website web = server.RequestedWeb();
            web.WebsiteInterface();
        }
        
    }
}
