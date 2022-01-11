using Microsoft.EntityFrameworkCore;
using solidCsharp.Model;
using System;

namespace solidCsharp.Repository
{
    public class UserRepository : BaseRepository<User, UserRepository>
    {
        public UserRepository(DbContextOptions<UserRepository> options)
            : base(options)
        { }
              
    }
}
