using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using C__Server_Class.Models;
using C__Server_Class.Services;
using System.Text.Json;

namespace C__Server_Class.Pages
{ 
    public class ProductsModel : PageModel
    {
        private readonly ProductsService _products;

        public List<Product> Products => _products.GetAll();
        [BindProperty]
        public Product CurrentProduct { get; set; } = new Product();
        public ProductsModel(ProductsService products)
        {
            _products = products; 
        }
        public void OnGet()
        {
            
        }
        public void OnPostAdd() { 
            _products.Add(CurrentProduct);
        }
        public async Task<IActionResult> OnPostEdit(int id)
        {
            var product = await Request.ReadFromJsonAsync<Product>();
            Console.WriteLine(JsonSerializer.Serialize(product));
            product.Id = id;
            bool result = _products.Update(product);
            return new JsonResult(new {
                success= result
            });
        }
        public IActionResult OnPostDelete(int id)
        {
            string? errorMSG = null;
            bool result = _products.Delete(id);
            if (!result)
            {
                Product? p = _products.GetProductById(id);
                if (p != null || p.Id == 0)
                {
                    errorMSG = "Не вдалося знайти вказаний товар";
                }
            }
            errorMSG = "Some errors on backend :(";
            return new JsonResult(new {
                success = result,
                error = errorMSG
            });
        }
    }
}
 