using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    internal class Password
    {
        public string Program { get; set; }
        public string Username { get; set; }
        public string Pw { get; set; }

        public Password(string program, string username, string pw)
        {
            Program = program;
            Username = username;
            Pw = pw;
        }
    }
}
