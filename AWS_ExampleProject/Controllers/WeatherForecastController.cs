using Microsoft.AspNetCore.Mvc;

namespace AWS_ExampleProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freez**ing1", "**racmming11", "Chill**y22", "Commmol", "mmm&Mild", "Wammmrm", "Bammlmy", "Hommmt", "Swelmmmtering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        //45745
        //8956...000

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)] + " <this is by cicd pipeline test 6004 port>"
            })
            .ToArray();
        }
    }
}
