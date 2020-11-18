using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository  _context;
        private readonly ICurrentWeatherService _currentWeatherService;

        public UserController(ICurrentWeatherService currentWeatherService, IUserRepository userRepository)
        {
            _currentWeatherService = currentWeatherService;
            _context = userRepository;
        }


        [HttpPost("reg")]
        public CurrentWeather Post([FromBody] string text)
        {
            Console.WriteLine(text);
            //_context.SaveNewUser(User user);
            return _currentWeatherService.GetCurrentWeather("Budapest");
        }
    }
}
