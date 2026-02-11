using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Autobazar.Models;

namespace Autobazar.Services
{
    public class JsonService
    {
        private string cesta = "auta.json";

        public void Uloz(List<Auto> auta)
        {
            string json = JsonSerializer.Serialize(auta, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(cesta, json);
        }

        public List<Auto> Nacti()
        {
            if (!File.Exists(cesta))
                return new List<Auto>();

            string json = File.ReadAllText(cesta);
            return JsonSerializer.Deserialize<List<Auto>>(json);
        }
    }
}
