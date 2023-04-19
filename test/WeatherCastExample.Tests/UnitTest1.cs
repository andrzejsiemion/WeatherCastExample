using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherCastExample.Controllers;
using Xunit;

namespace WeatherCastExample.Test.UnitTest
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void TestGetWeatherForecastReturnsWeatherForecasts()
        {
            // Arrange
            var controller = new WeatherForecastController();

            // Act
            var result = controller.Get() as OkObjectResult;
            var weatherForecasts = JsonConvert.DeserializeObject<WeatherForecast[]>(result.Value.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.NotNull(weatherForecasts);
            Assert.Equal(5, weatherForecasts.Length);
        }
    }
}
