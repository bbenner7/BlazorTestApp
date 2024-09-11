using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Logging;
using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Services;

public class WeatherService : IWeatherService
{
    #region Private Fields

    private readonly ActivitySource _activitySource;
    private readonly IWeatherRepository _weatherRepo;
    private readonly ILogger<WeatherService> _logger;

    #endregion Private Fields

    #region Public Constructors

    public WeatherService(IWeatherRepository weatherRepo, IInstrumentation instrumentation, ILogger<WeatherService> logger)
    {
        _weatherRepo = weatherRepo;
        _logger = logger;
        _activitySource = instrumentation.ActivitySource;
    }

    #endregion Public Constructors

    #region Public Methods

    public ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int numberOfForecasts)
    {
        using var activity = _activitySource.CreateActivity("retrieve forecasts", ActivityKind.Producer);

        var forecasts = _weatherRepo.GetForecasts(startDate, numberOfForecasts);
        _logger.LogInformation($"Generated {numberOfForecasts} weather forecasts");

        return forecasts;
    }

    #endregion Public Methods
}