using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace C__Server_Class.Pages
{
    public class IndexModel : PageModel
    {
        public string LangDesc { get; set; }
        public void OnGet()
        {
            LangDesc = "text 1";
        }
    }
}
