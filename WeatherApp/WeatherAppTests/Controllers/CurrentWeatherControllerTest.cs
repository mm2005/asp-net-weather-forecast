using NSubstitute;
using NUnit.Framework;
using WeatherApp.Webpage.Controllers;
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
        public void Test1()
        {
            string expected = "Hello World";
            string actual = _currentWeatherController.TestMethod();

            Assert.AreEqual(expected, actual);
        }
    }
}
