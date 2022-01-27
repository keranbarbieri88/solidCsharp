using Microsoft.EntityFrameworkCore;
using solidCsharp.Model;
using System.Linq;


namespace solidCsharp.Repository
{
    public class UserRepository : BaseRepository<User, UserRepository>, IUserRepository
    {
        public UserRepository(DbContextOptions<UserRepository> options)
            : base(options)
        { }
        
        public User GetUser(string Email)
        {
            var user = (from u in this.Items where u.Email == Email select u).FirstOrDefault();
            return user;
        }
    }
}
