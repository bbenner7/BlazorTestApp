using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using UnitsNet;
using WeatherServices.Models;

namespace WeatherServices.Tests.Unit.Models
{
    public class WeatherSummaryTests
    {
        [Fact(DisplayName = "Giving a temperature out of range should raise an exception")]
        public void Given_TemperatureOutOfRange_When_ICreateSummary_Should_RaiseException()
        {
            Action act = () => WeatherSummary.Create(Temperature.FromDegreesCelsius(-100));

            act.Should().Throw<Exception>()
                .WithMessage("Temperature -100 C can not be summarized.");
        }

        [Theory(DisplayName = "When I give a temperature it should create a summary")]
        [InlineData(-20.0, "Freezing")]
        [InlineData(10.0, "Bracing")]
        [InlineData(46.0, "Cool")]
        [InlineData(65.0, "Mild")]
        [InlineData(77.0, "Warm")]
        [InlineData(85.0, "Balmy")]
        [InlineData(95.0, "Hot")]
        [InlineData(105.0, "Sweltering")]
        [InlineData(120.0, "Scorching")]
        public void Given_Temperature_When_ICreateSummary_Should_CreateSummaryWithGivenString(double temperatureF,
            string expectedSummary)
        {
            var summary = WeatherSummary.Create(Temperature.FromDegreesFahrenheit(temperatureF));
            summary.Should().NotBeNull();
            summary.ToString().Should().Be(expectedSummary);
        }
    }
}
