using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrentWeatherController : ControllerBase
    {
        private readonly ICurrentWeatherService _currentWeatherService;

        public CurrentWeatherController(ICurrentWeatherService currentWeatherService)
        {
            _currentWeatherService = currentWeatherService;
        }

        [HttpGet("{city}")]
        public async Task<CurrentWeather> Get(string city)
        {
            //return _currentWeatherService.GetCurrentWeather(city);
            return await Task.Run(() => _currentWeatherService.GetCurrentWeather(city));
        }
    }
}
