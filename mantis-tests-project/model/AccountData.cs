using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_project
{
    public class AccountData
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public AccountData(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
