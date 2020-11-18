using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.WebSite.Models
{
    public class User
    {
        public User(string name, string email, string passord)
        {
            this.Name = name;
            this.Email = email;
            this.Password = passord;

        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
    }
   
}
