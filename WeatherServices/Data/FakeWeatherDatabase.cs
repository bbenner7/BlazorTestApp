using Microsoft.Extensions.Logging;
using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Data;

public class FakeWeatherDatabase : IWeatherRepository
{
    private readonly ILogger<FakeWeatherDatabase> _logger;

    public FakeWeatherDatabase(ILogger<FakeWeatherDatabase> logger)
    {
        _logger = logger;
    }

    public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int daysToFetch)
    {
        var summaries = new[]
            { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        var forecasts = Enumerable.Range(1, daysToFetch).Select(index =>
            new WeatherForecast(startDate.AddDays(index), Temperature.FromDegreesCelsius(Random.Shared.Next(-20, 55)),
                summaries[Random.Shared.Next(summaries.Length)]));
        return new List<WeatherForecast>(forecasts);
    }
}