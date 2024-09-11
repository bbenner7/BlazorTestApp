using System.Runtime.InteropServices.JavaScript;
using UnitsNet;

namespace WeatherServices.Models;

public record WeatherSummary(Temperature MinTemp, Temperature MaxTemp, string SummaryString)
{
    public static WeatherSummary Freezing = new(Temperature.FromDegreesFahrenheit(-40.0),
        Temperature.FromDegreesFahrenheit(0.0), "Freezing");

    public static WeatherSummary Bracing = new WeatherSummary(Temperature.FromDegreesFahrenheit(0.0),
        Temperature.FromDegreesFahrenheit(32.0), "Bracing");

    public static WeatherSummary Chilly = new WeatherSummary(Temperature.FromDegreesFahrenheit(32.0),
        Temperature.FromDegreesFahrenheit(45.0), "Chilly");

    public static WeatherSummary Cool = new WeatherSummary(Temperature.FromDegreesFahrenheit(45.0),
        Temperature.FromDegreesFahrenheit(60.0), "Cool");

    public static WeatherSummary Mild = new WeatherSummary(Temperature.FromDegreesFahrenheit(60.0),
        Temperature.FromDegreesFahrenheit(75.0),
        "Mild");

    public static WeatherSummary Warm = new WeatherSummary(Temperature.FromDegreesFahrenheit(75.0),
        Temperature.FromDegreesFahrenheit(80.0), "Warm");

    public static WeatherSummary Balmy = new WeatherSummary(Temperature.FromDegreesFahrenheit(80.0),
        Temperature.FromDegreesFahrenheit(90.0), "Balmy");

    public static WeatherSummary Hot = new WeatherSummary(Temperature.FromDegreesFahrenheit(90.0),
        Temperature.FromDegreesFahrenheit(100.0), "Hot");

    public static WeatherSummary Sweltering = new WeatherSummary(Temperature.FromDegreesFahrenheit(100.0),
        Temperature.FromDegreesFahrenheit(110.0), "Sweltering");

    public static WeatherSummary Scorching = new WeatherSummary(Temperature.FromDegreesFahrenheit(110.0),
        Temperature.FromDegreesFahrenheit(130.0), "Scorching");

    public override string ToString() => SummaryString;

    public static WeatherSummary Create(Temperature temperature)
    {
        if (temperature > Freezing.MinTemp && temperature <= Freezing.MaxTemp)
            return Freezing;
        if (temperature > Bracing.MinTemp && temperature <= Bracing.MaxTemp)
            return Bracing;
        if (temperature > Chilly.MinTemp && temperature <= Chilly.MaxTemp)
            return Chilly;
        if (temperature > Cool.MinTemp && temperature <= Cool.MaxTemp)
            return Cool;
        if (temperature > Mild.MinTemp && temperature <= Mild.MaxTemp)
            return Mild;
        if (temperature > Warm.MinTemp && temperature <= Warm.MaxTemp)
            return Warm;
        if (temperature > Balmy.MinTemp && temperature <= Balmy.MaxTemp)
            return Balmy;
        if (temperature > Hot.MinTemp && temperature <= Hot.MaxTemp)
            return Hot;
        if (temperature > Sweltering.MinTemp && temperature <= Sweltering.MaxTemp)
            return Sweltering;
        if (temperature > Scorching.MinTemp && temperature <= Scorching.MaxTemp)
            return Scorching;

        throw new Exception($"Temperature {temperature.DegreesCelsius} C can not be summarized.");
    }
}