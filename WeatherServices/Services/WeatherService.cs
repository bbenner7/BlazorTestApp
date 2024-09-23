using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Logging;
using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Services;

public class WeatherService(
    IWeatherRepository weatherRepo,
    IInstrumentation instrumentation,
    ILogger<WeatherService> logger)
    : IWeatherService
{
    #region Private Fields

    private readonly ActivitySource _activitySource = instrumentation.ActivitySource;

    #endregion Private Fields

    #region Public Methods

    public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int numberOfForecasts)
    {
        using var activity = _activitySource.CreateActivity("retrieve forecasts", ActivityKind.Producer);

        var forecasts = weatherRepo.GetForecasts(startDate, numberOfForecasts);
        logger.LogInformation($"Generated {numberOfForecasts} weather forecasts");

        return forecasts;
    }

    #endregion Public Methods
}