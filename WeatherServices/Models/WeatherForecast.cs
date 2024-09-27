using UnitsNet;

namespace WeatherServices.Models;

public record WeatherForecast(DateOnly Date, Temperature Temperature)
{
    public WeatherSummary Summary => WeatherSummary.Create(Temperature);
}
