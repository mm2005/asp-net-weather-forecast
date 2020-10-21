using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using WeatherApp.WebSite.Controllers;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;
using WeatherApp.WebSite.Services.Interfaces;

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
