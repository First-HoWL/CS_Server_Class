using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection.Metadata;
using System.Text.Json;

namespace C__Server_Class.Pages
{
    public class ApiDice
    {
        public string input { get; set; }
        public int result { get; set; }
        public string details { get; set; }
        public string code { get; set; }
        public string illustration { get; set; }
        public long timestamp { get; set; }
        public long x { get; set; }


    }
    public class RandomModel : PageModel
    {
        static readonly Random random = new Random();
        public int RandomNumber { get; private set; }
        public string Dice { get; private set; }
        public int Result { get; private set; }
        public async Task OnGet()
        {
            using var client = new HttpClient();

            try
            {
                var response = await client.GetAsync("https://rolz.org/api/?1d20.json");

                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("CONTENT TYPE: " + response.Content.Headers.ContentType);
                Console.WriteLine(responseBody);

                if (!responseBody.TrimStart().StartsWith("{"))
                {
                    Console.WriteLine("Это не JSON!");
                    return;
                }

                var ressp = JsonSerializer.Deserialize<ApiDice>(responseBody);

                Dice = ressp?.illustration;
                Result = ressp.result;
                Console.WriteLine(Dice);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
