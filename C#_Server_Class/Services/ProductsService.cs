using C__Server_Class.Models;
using System.Xml.Linq;
using C__Server_Class.Models;

namespace C__Server_Class.Services
{
    public class ProductsService
    {
        private List<Product> _products = new();
        private int _lastId = 0;

        public ProductsService()
        {
            Add(new Product()
            {
                Id = 0,
                Name = "Чайник",
                Description = "Якісний електрочайник",
                Price = 205.0
            });
            Add(new Product()
            {
                Id = 0,
                Name = "Пательня",
                Description = "Якісний пательня",
                Price = 130.0
            });
        }

        public List<Product> GetAll() => _products;
        public Product? GetProductById(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public int Add(Product product)
        {
            product.Id = GetLastId();
            _products.Add(product);
            return product.Id;
        }

        public int GetLastId() => ++_lastId;

        public bool Update(Product product)
        {
            Product? foundProduct = GetProductById(product.Id);
            if (foundProduct == null || foundProduct.Id == 0)
                return false;
            foundProduct.Name = product.Name;
            foundProduct.Description = product.Description;
            foundProduct.Price = product.Price;
            return true;
        }

        public bool Delete(int id)
        {
            Product? foundProduct = GetProductById(id);
            if (foundProduct == null || foundProduct.Id == 0)
                return false;
            _products.Remove(foundProduct);
            return true;
        }
    }
}
