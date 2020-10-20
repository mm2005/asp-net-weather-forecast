using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WeatherApp.Webpage.Models;
using WeatherApp.Webpage.Services;

namespace WeatherApp.Webpage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CurrentWeatherService _currentWeatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CurrentWeatherService currentWeatherService)
        {
            _logger = logger;
            _currentWeatherService = currentWeatherService;
        }

        [HttpGet("{city}")]
        public CurrentWeather Get(string city)
        {
            return _currentWeatherService.GetCurrentWeather(city);
        }
    }
}
