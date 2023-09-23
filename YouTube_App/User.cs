using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    /// <summary>
    /// User is watching videos or uploading on server his new videos
    /// </summary>
    internal class User: IUser
    {
        /// <summary>
        /// When we are registering, we need an email for it
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// For protect your account
        /// </summary>
        public string Password { get; private set; }
        /// <summary>
        /// User sends a request to the server to get the website
        /// </summary>
        private Server server { get; set; }
        public User(string email, string password, Server server)
        {
            this.Email = email;
            this.Password = password;
            this.server = server;
        }
        /// <summary>
        /// The process where we send request and we get web
        /// </summary>
        public void OpenWebsite()
        {
            Website web = server.RequestedWeb();
            web.WebsiteInterface();
        }
        
    }
}
