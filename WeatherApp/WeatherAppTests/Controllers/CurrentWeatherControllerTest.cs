using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using WeatherApp.Webpage.Controllers;
using WeatherApp.Webpage.Models;
using WeatherApp.Webpage.Services;
using WeatherApp.Webpage.Services.Interfaces;

namespace WeatherApp.WebSite
{
    [TestFixture]
    public class Tests
    {
        private CurrentWeatherController _currentWeatherController;
        private ICurrentWeatherService _currentWeatherService;

        [SetUp]
        public void Setup()
        {
            _currentWeatherService = Substitute.For<ICurrentWeatherService>();
            _currentWeatherController = new CurrentWeatherController(_currentWeatherService);
        }

        [Test]
        public void Get_ExistingCity_ReturnCity()
        {
            string city = "Budapest";

            _currentWeatherService.GetCurrentWeather(city).Returns(new CurrentWeather { City = city });

            string expected = city;
            string actual = _currentWeatherController.Get(city).City;

            Assert.AreEqual(expected, actual);
        }
    }
}
