using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Webpage.Models;
using WeatherApp.Webpage.Services;

namespace WeatherApp.Webpage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly CurrentWeatherService _currentWeatherService;
        private FavoriteContext _context;

        public FavoriteController(CurrentWeatherService currentWeatherService, FavoriteContext favoriteContext)
        {
            _currentWeatherService = currentWeatherService;
            _context = favoriteContext;
        }
        
        [HttpPost("{city}")]
        public CurrentWeather Post(string city)
        {
            _context.FavoriteSet.Add(city);
            return _currentWeatherService.GetCurrentWeather(city);
        }
        
        [HttpGet("favorites")]
        public CurrentWeather[] GetFavorites()
        {
            ISet<CurrentWeather> favorites = new HashSet<CurrentWeather>();
            foreach (var city in _context.FavoriteSet)
            {
                favorites.Add(_currentWeatherService.GetCurrentWeather(city));
            }
        
            return favorites.ToArray();
        }
    }
}