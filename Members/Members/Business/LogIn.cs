using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members.Business
{
    public class LogIn
    {
        int logInId;
        string password;

        public int LogInId { get => logInId; set => logInId = value; }
        public string Password { get => password; set => password = value; }
    }
}
