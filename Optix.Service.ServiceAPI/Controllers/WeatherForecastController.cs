using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Optix.Service.ServiceAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult<Movies> Get()
    {
        var movies = new Movies
        {
            ActorName = "£hioze"
        };
        return Ok(movies);
    }


    //[HttpGet(Name = "GetWeatherForecastList")]
    //public IEnumerable<WeatherForecast> GetList()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}

    public class Movies
    {
        [Key]
        public int MovieID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string ActorName { get; set; }

        public string MovieList { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
