using System;

namespace DataLibrary
{
    public interface IWeatherForecast
    {
        DateTime Date { get; set; }
        int TemperatureC { get; set; }
    }
}