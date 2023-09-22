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
        private Website website { get; set; }
        public User(string email, string password, Server server)
        {
            this.Email = email;
            this.Password = password;
            this.website = website;
        }
        public string OpenWebsite()
        {
            return "";
        }
        
    }
}
