using Microsoft.Extensions.Logging;
using System.Diagnostics;
using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Services;

public class WeatherService : IWeatherService
{
    #region Private Fields

    private readonly ActivitySource _activitySource;
    private readonly ILogger<WeatherService> _logger;

    #endregion Private Fields

    #region Public Constructors

    public WeatherService(ILogger<WeatherService> logger)
    {
        _logger = logger;
        _activitySource = new ActivitySource("weather-service");
    }

    #endregion Public Constructors

    #region Public Methods

    public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int numberOfForecasts)
    {
        using var activity = _activitySource.CreateActivity("retrieve forecasts", ActivityKind.Producer);

        var summaries = new[]
            { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        var forecasts = Enumerable.Range(1, numberOfForecasts).Select(index =>
            new WeatherForecast(startDate.AddDays(index), Temperature.FromDegreesCelsius(Random.Shared.Next(-20, 55)),
                summaries[Random.Shared.Next(summaries.Length)]));

        _logger.LogInformation($"Generated {numberOfForecasts} weather forecasts");

        return new List<WeatherForecast>(forecasts);
    }

    #endregion Public Methods
}