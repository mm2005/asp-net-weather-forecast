using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public interface IUserRepository
    {
        public User GetUserById(int id);
        public User SaveNewUser(User user);
    }
}
