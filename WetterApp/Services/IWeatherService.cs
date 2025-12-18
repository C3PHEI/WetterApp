using System.Threading.Tasks;
using WetterApp.Models;

namespace WetterApp.Services
{
	public interface IWeatherServices
	{
		Task<OpenWeatherResponse?> GetWeatherAsync(string city);
	}
}