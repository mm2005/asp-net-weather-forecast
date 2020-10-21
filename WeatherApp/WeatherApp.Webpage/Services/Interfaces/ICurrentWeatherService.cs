using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.WebSite.Models;

namespace WeatherApp.WebSite.Services.Interfaces
{
    public interface ICurrentWeatherService
    {
        CurrentWeather GetCurrentWeather(string city);
    }
}
