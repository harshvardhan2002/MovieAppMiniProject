using MovieAppLayered.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Configuration;

namespace MovieAppLayered.Services
{
    public class MovieSerializer
    {
        static string filePath = ConfigurationManager.AppSettings["filePath"];

        public static void Serialize(List<Movie> movies)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(JsonSerializer.Serialize(movies));
            }
            Console.WriteLine("Serialization successful!");
        }

        public static List<Movie> Deserialize()
        {
            if (!File.Exists(filePath))
            {
                return new List<Movie>();
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                string json = sr.ReadToEnd();
                return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
            }
        }
    }
}
