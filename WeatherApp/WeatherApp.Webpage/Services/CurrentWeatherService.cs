using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services.Interfaces;

namespace WeatherApp.WebSite.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        const string API_KEY = "3c850b0463346d2fffad82b66d5eb561";

        public CurrentWeatherService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public CurrentWeather GetCurrentWeather(string city)
        {
            string jsonString = "";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                //HTTP GET
                var responseTask = client.GetAsync("");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    jsonString = readTask.Result;
                }
            }

            var json = JObject.Parse(jsonString);
            var currentWeather = new CurrentWeather()
            {
                ID = Convert.ToInt64(json.GetValue("id")),
                City = json.GetValue("name").ToString(),
                Description = (string)json["weather"][0]["description"],
                Icon = (string)json["weather"][0]["icon"],
                Humidity = Convert.ToInt32(json.GetValue("main")["humidity"]),
                Temp = Convert.ToInt32(json.GetValue("main")["temp"]),
                Pressure = Convert.ToInt32(json.GetValue("main")["pressure"]),
                Wind = Convert.ToDouble((json.GetValue("wind")["speed"]))
            };
            return currentWeather;
        }
    }
}
