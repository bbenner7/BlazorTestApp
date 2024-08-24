using WeatherServices.Models;

namespace WeatherServices;

public interface IWeatherService
{
    ICollection<WeatherForecast> GetForecasts(DateOnly startDate, int numberOfForecasts);
}