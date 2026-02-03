using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Reflection.Metadata;
using System.Text.Json;

namespace C__Server_Class.Pages
{
    //[IgnoreAntiforgeryToken]
    public class RandomModel : PageModel
    {
        static readonly Random random = new Random();
        public int RandomNumber { get; private set; }
        public void OnGet()
        {
            RandomNumber = random.Next(1, 101);
        }
        public IActionResult OnPost()
        {
            return new JsonResult(new
            {
                number = random.Next(1, 101)
            });
        }
    }
}
