using System.Data;
using System.Data.SqlClient;

namespace LegacyCode.Refactor.Sample.Services;

public class WeatherService
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public WeatherForecast GetWeatherForecast(DateTime now)
    {
        var dataTable = QueryTemperature(now);
        var queryTemperature = dataTable.Rows.Count > 0 ? int.Parse(dataTable.Rows[0]["Temperature"].ToString()) : 0;

        return new WeatherForecast
        {
            Date = DateOnly.FromDateTime(now),
            TemperatureC = queryTemperature,
            TemperatureF = 32 + (int)(queryTemperature / 0.5556),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        };
    }

    // the logic related to query the temperature from the database
    private DataTable QueryTemperature(DateTime dateTime)
    {
        using var connection = new SqlConnection("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
        connection.Open();
        
        var command = new SqlCommand("SELECT * FROM WeatherForecast WHERE Date = @Date", connection);
        command.Parameters.AddWithValue("@Date", dateTime);
        var adapter = new SqlDataAdapter(command);
        var dataTable = new DataTable();
        
        adapter.Fill(dataTable);
        return dataTable;
    }
}