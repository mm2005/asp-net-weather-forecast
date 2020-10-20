using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Webpage.Models;

namespace WeatherApp.Webpage.Services
{
    public class AutocompleteService
    {
        const string API_KEY = "jzxwrjVpz590MChJ0KjlrLnwg_syikNAPYB0tvSemLE";

        public AutocompleteService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        
        public IWebHostEnvironment WebHostEnvironment { get; }

        public IList<Location> GetSuggestions(string query)
        {
            string jsonString = "";
            string url = $"https://autocomplete.geocoder.ls.hereapi.com/6.2/suggest.json?query={query}&maxresults=5&resultType=city&language=en&apikey={API_KEY}";

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
            IList<Location> suggestionList = new List<Location>();
            var jsonSuggestion = json.GetValue("suggestions");

            foreach (var element in jsonSuggestion)
            {
                var locationSuggestion = new Location()
                {
                    City = (string)element["address"]["city"],
                    State = (string)element["address"]["state"],
                    CountryCode = (string)element["countryCode"]
                };
                suggestionList.Add(locationSuggestion);
            }
            //var currentWeather = new CurrentWeather()
            //{
            //    ID = Convert.ToInt64(json.GetValue("id")),
            //    City = json.GetValue("name").ToString(),
            //    Description = (string)json["weather"][0]["description"],
            //    Icon = (string)json["weather"][0]["icon"],
            //    Humidity = Convert.ToInt32(json.GetValue("main")["humidity"]),
            //    Temp = Convert.ToInt32(json.GetValue("main")["temp"]),
            //    Pressure = Convert.ToInt32(json.GetValue("main")["pressure"]),
            //    Wind = Convert.ToDouble((json.GetValue("wind")["speed"]))
            //};
            //return currentWeather;
            return suggestionList;
        }
    }
}

