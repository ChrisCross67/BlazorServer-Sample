using System;
using System.Threading.Tasks;

namespace DataLibrary
{
    public interface IWeatherForecastService
    {
        Task<IWeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}