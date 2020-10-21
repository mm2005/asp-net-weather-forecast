using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;

namespace WeatherApp.WebSite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutocompleteController : ControllerBase
    {
        private readonly AutocompleteService _autocompleteService;

        public AutocompleteController(AutocompleteService autocompleteService)
        {
            _autocompleteService = autocompleteService;
        }

        [HttpGet("{query}")]
        public IList<Location> Get(string query)
        {
            return _autocompleteService.GetSuggestions(query);
        }
    }
}
