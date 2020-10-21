using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Webpage.Models;

namespace WeatherApp.Webpage.Services.Interfaces
{
    public interface ICurrentWeatherService
    {
        CurrentWeather GetCurrentWeather(string city);
    }
}
