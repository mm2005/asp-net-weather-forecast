using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WeatherApp.Webpage.Models;
using WeatherApp.Webpage.Services;
using WeatherApp.Webpage.Services.Interfaces;

namespace WeatherApp.Webpage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly ILogger<CurrentWeatherController> _logger;
        private readonly ICurrentWeatherService _currentWeatherService;

        public CurrentWeatherController(ILogger<CurrentWeatherController> logger, ICurrentWeatherService currentWeatherService)
        {
            _logger = logger;
            _currentWeatherService = currentWeatherService;
        }

        [HttpGet("{city}")]
        public CurrentWeather Get(string city)
        {
            return _currentWeatherService.GetCurrentWeather(city);
        }

        virtual public string TestMethod()
        {
            return "Hello World";
        }
    }
}
