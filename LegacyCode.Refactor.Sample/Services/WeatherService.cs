namespace LegacyCode.Refactor.Sample.Services;

public class WeatherService
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public WeatherForecast GetWeatherForecast(DateTime now)
    {
        var queryTemperature = QueryTemperature(now);

        return new WeatherForecast
        {
            Date = DateOnly.FromDateTime(now),
            TemperatureC = queryTemperature,
            TemperatureF = 32 + (int)(queryTemperature / 0.5556),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }

    private int QueryTemperature(DateTime dateTime)
    {
        return Random.Shared.Next(-20, 55);
    }
}