using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace predprof2022
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }

        public User(string login, string pasword)
        {
            this.login = login;
            this.password = pasword;
        }
    }
}
