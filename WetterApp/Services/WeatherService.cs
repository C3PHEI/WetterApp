using System.Net.Http;
using System.Text.Json;
using WetterApp.Models;

namespace WetterApp.Services
{
	public class WeatherService : IWeatherServices
	{
		private const string ApiKey = "";
		private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";
		private readonly HttpClient _httpClient;

		public WeatherService()
		{
			_httpClient = new HttpClient();
		}
		
		public async Task<OpenWeatherResponse?> GetWeatherAsync(string city)
		{
			try
			{
				string url = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric&lang=de";
				var response = await _httpClient.GetStringAsync(url);

				using var doc = JsonDocument.Parse(response);
				var root = doc.RootElement;

				return new OpenWeatherResponse
				{
					CityName = root.GetProperty("name").GetString() ?? city,
					Temperature = root.GetProperty("main").GetProperty("temp").GetDouble(),
					Description = root.GetProperty("weather")[0].GetProperty("description").GetString() ?? "",
					Humidity = root.GetProperty("main").GetProperty("humidity").GetInt32(),
					WindSpeed = root.GetProperty("wind").GetProperty("speed").GetDouble()
				};
			}
			catch (Exception e)
			{
				Console.WriteLine($"Fehler beim Laden der Wetterdaten: {ex.Message}");
				return null;
			}
		}
	}
}

//https://api.openweathermap.org/data/2.5/weather?q=Horw&appid={API_KEY}&units=metric&lang=de