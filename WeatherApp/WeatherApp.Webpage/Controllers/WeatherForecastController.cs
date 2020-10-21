using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;

namespace WeatherApp.WebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService _weatherForecastService;

        public WeatherForecastController(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("{city}")]
        public IList<WeatherForecast> Get(string city)
        {
            return _weatherForecastService.GetForecasts(city);
        }
    }
}
