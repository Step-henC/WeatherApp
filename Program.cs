using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("What is your API Key");
            var apiKey = Console.ReadLine();    

            Console.WriteLine("Please eneter city name");
            var cityName = Console.ReadLine();  
            var weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

            var weatherData = client.GetStringAsync(weatherUrl).Result;
            var response = JObject.Parse(weatherData).GetValue("main").ToString();
            Console.WriteLine($"The weather in {cityName} is {response} ");
        }
    }
}
