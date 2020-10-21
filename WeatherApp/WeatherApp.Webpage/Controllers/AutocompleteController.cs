using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Webpage.Models;
using WeatherApp.Webpage.Services;

namespace WeatherApp.Webpage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutocompleteController : ControllerBase
    {
        private readonly ILogger<CurrentWeatherController> _logger;
        private readonly AutocompleteService _autocompleteService;

        public AutocompleteController(ILogger<CurrentWeatherController> logger, AutocompleteService autocompleteService)
        {
            _logger = logger;
            _autocompleteService = autocompleteService;
        }

        [HttpGet("{query}")]
        public IList<Location> Get(string query)
        {
            return _autocompleteService.GetSuggestions(query);
        }
    }
}
