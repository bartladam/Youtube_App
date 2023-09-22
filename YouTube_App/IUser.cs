using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube_App
{
    internal interface IUser
    {
        string Email { get; }
        string Password { get; }
        void OpenWebsite();

    }
}
