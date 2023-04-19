using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace WeatherCastExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IActionResult Get()
        {
            var rng = new Random();
            var weatherForecasts = new WeatherForecast[5];
            for (int i = 0; i < weatherForecasts.Length; i++)
            {
                weatherForecasts[i] = new WeatherForecast
                {
                    Date = DateTimeOffset.Now.AddDays(i),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                };
            }
            return Ok(JsonConvert.SerializeObject(weatherForecasts));
        }
    }

    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }
    }
}
