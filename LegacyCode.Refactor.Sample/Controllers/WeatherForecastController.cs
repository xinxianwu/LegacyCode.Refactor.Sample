using LegacyCode.Refactor.Sample.Services;
using Microsoft.AspNetCore.Mvc;

namespace LegacyCode.Refactor.Sample.Controllers;

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
    public IEnumerable<WeatherForecast> Get()
    {
        var weatherService = new WeatherService();

        return Enumerable.Range(1, 5)
            .Select(index => weatherService.GetWeatherForecast(DateTime.Now.AddDays(index)))
            .ToArray();
    }
}