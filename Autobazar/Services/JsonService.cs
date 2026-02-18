using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Autobazar.Models;

using Autobazar.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Autobazar.Services
{
    public class JsonService
    {
        private readonly string filePath = "auta.json";

        public void Uloz(List<Auto> auta)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(auta, options);
            File.WriteAllText(filePath, json);
        }

        public List<Auto> Nacti()
        {
            if (!File.Exists(filePath))
                return new List<Auto>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Auto>>(json) ?? new List<Auto>();
        }
    }
}
