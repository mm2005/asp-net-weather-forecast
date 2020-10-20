using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WeatherApp.Webpage.Services
{
    public class CurrentWeatherService
    {
        string apiKey = "3c850b0463346d2fffad82b66d5eb561";
        //string url = "https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${apiKey}&units=metric";
        string url = "https://api.openweathermap.org/data/2.5/weather?q=budapest&appid=3c850b0463346d2fffad82b66d5eb561&units=metric";

        public CurrentWeatherService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public JObject GetCurrentWeather()
        {
            string jsonString = "";

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
            return json;
        }
    }
}
