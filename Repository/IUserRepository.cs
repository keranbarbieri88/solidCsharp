using solidCsharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace solidCsharp.Repository
{
    public interface IUserRepository : IReadWriteRepository<User>
    {
        public User GetUser(string Email);
    
    }
}
