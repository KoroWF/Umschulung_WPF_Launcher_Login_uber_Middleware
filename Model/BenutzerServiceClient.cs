using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Model
{
    public class BenutzerServiceClient
    {
        public static async Task<JWT?> connectAsync(string uid, string pwd)
        {
            LoginDaten data = new LoginDaten() { uid = uid, pwd = pwd };

            HttpClientHandler httpClientHandler = new HttpClientHandler();

            // Den eigentlichen HttpClient erstellen und den HttpClientHandler übergeben.
            HttpClient httpClient = new HttpClient(httpClientHandler);

            // HttpClient Konfigurieren
            // Url Festlegen
            httpClient.BaseAddress = new Uri("https://localhost:5000");

            // Automatische angelegte Headers löschen.
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Accept Header für Json anlegen
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            // Nutzdaten / Content anlegen
            // Wir wollwn die Post Methode aufrufen und einen Kunden übergeben
            string json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Webservice abfragen
            var responsMessage = httpClient.PostAsync("Connect", content).Result;

            // Die Nutzdaten aus der Nachricht lesen
            string jsonDaten = responsMessage.Content.ReadAsStringAsync().Result;

            if (jsonDaten == "true")
            {
                // ToDo Dienstag
                var Authorization = responsMessage.Headers.GetValues("Authorization");
                foreach (var item in Authorization)
                {
                    JWT jwt = JsonSerializer.Deserialize(item, typeof(JWT)) as JWT;
                    return jwt;
                }
            }

            return null;
        }

        public static async Task<bool> validateAsync(JWT jwt)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            // Den eigentlichen HttpClient erstellen und den HttpClientHandler übergeben.
            HttpClient httpClient = new HttpClient(httpClientHandler);

            // HttpClient Konfigurieren
            // Url Festlegen
            httpClient.BaseAddress = new Uri("https://localhost:5000");

            // Automatische angelegte Headers löschen.
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Accept Header für Json anlegen
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            // Nutzdaten / Content anlegen
            // Wir wollwn die Post Methode aufrufen und einen Kunden übergeben
            string json = JsonSerializer.Serialize(jwt);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Webservice abfragen
            var responsMessage = await httpClient.PostAsync("Validate", content);

            // Die Nutzdaten aus der Nachricht lesen
            string jsonDaten = await responsMessage.Content.ReadAsStringAsync();

            // ToDo Dienstag

            return false;
        }

        public static async Task<List<Nutzer>> getAllAsync()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            // Den eigentlichen HttpClient erstellen und den HttpClientHandler übergeben.
            HttpClient httpClient = new HttpClient(httpClientHandler);

            // HttpClient Konfigurieren
            // Url Festlegen
            httpClient.BaseAddress = new Uri("http://localhost:5001");

            // Automatische angelegte Headers löschen.
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Accept Header für Json anlegen
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            var responsMessage = httpClient.GetAsync("Nutzer").Result;

            // Die Nutzdaten aus der Nachricht lesen
            string jsonDaten = responsMessage.Content.ReadAsStringAsync().Result;


            return JsonSerializer.Deserialize(jsonDaten, typeof(List<Nutzer>)) as List<Nutzer>;
        }

        public static async Task<Nutzer> getAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            // Den eigentlichen HttpClient erstellen und den HttpClientHandler übergeben.
            HttpClient httpClient = new HttpClient(httpClientHandler);

            // HttpClient Konfigurieren
            // Url Festlegen
            httpClient.BaseAddress = new Uri("http://localhost:5001");

            // Automatische angelegte Headers löschen.
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Accept Header für Json anlegen
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            var responsMessage = httpClient.GetAsync("Nutzer/" + id.ToString()).Result;

            // Die Nutzdaten aus der Nachricht lesen
            string jsonDaten = responsMessage.Content.ReadAsStringAsync().Result;


            return JsonSerializer.Deserialize(jsonDaten, typeof(Nutzer)) as Nutzer;
        }

        public static async Task<int> deleteAsync(int id)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();

            // Den eigentlichen HttpClient erstellen und den HttpClientHandler übergeben.
            HttpClient httpClient = new HttpClient(httpClientHandler);

            // HttpClient Konfigurieren
            // Url Festlegen
            httpClient.BaseAddress = new Uri("https://localhost:5000");

            // Automatische angelegte Headers löschen.
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Accept Header für Json anlegen
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
            );

            var responsMessage = httpClient.DeleteAsync("Nutzer/" + id.ToString()).Result;

            // Die Nutzdaten aus der Nachricht lesen
            string jsonDaten = await responsMessage.Content.ReadAsStringAsync();


            return Int32.Parse(jsonDaten);
        }

        public static async Task<Nutzer?> postAsync(Nutzer nutzer)
        {
                        HttpClientHandler httpClientHandler = new HttpClientHandler();

            // Den eigentlichen HttpClient erstellen und den HttpClientHandler übergeben.
            HttpClient httpClient = new HttpClient(httpClientHandler);

            // HttpClient Konfigurieren
            // Url Festlegen
            httpClient.BaseAddress = new Uri("https://localhost:5000");

            // Automatische angelegte Headers löschen.
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Accept Header für Json anlegen
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

            // Nutzdaten / Content anlegen
            // Wir wollwn die Post Methode aufrufen und einen Kunden übergeben
            string json = JsonSerializer.Serialize(nutzer);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Webservice abfragen
            var responsMessage = httpClient.PostAsync("Nutzer", content).Result;

            // Die Nutzdaten aus der Nachricht lesen
            string jsonDaten = await responsMessage.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize(jsonDaten, typeof(Nutzer)) as Nutzer;

        }
    }
}
