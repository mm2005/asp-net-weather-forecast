using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Webpage.Models;
using WeatherApp.Webpage.Services;

namespace WeatherApp.Webpage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TheRealWeatherForecastController : ControllerBase
    {
        private readonly ILogger<TheRealWeatherForecastController> _logger;
        private readonly WeatherForecastService _weatherForecastService;

        public TheRealWeatherForecastController(ILogger<TheRealWeatherForecastController> logger, WeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("{city}")]
        public IList<WeatherForecast> Get(string city)
        {
            return _weatherForecastService.GetCurrentWeather(city);
        }
    }
}
