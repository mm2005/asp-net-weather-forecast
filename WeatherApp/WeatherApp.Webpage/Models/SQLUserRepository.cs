using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public SQLUserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User SaveNewUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}
