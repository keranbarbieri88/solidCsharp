using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Service
{
    public interface IUserService
    {
        public void CreateUser(string Email, string Name, string Password);

        public string Login(string Email, string Password);
    }
}
