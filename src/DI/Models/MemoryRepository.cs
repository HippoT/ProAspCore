using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI.Models
{
    public class MemoryRepository : IRepository
    {
        private Dictionary<string, Product> products;

        public IEnumerable<Product> Products => products.Values;

        public Product this[string name] => products[name];

        public MemoryRepository()
        {
            products = new Dictionary<string, Product>();
                        new List<Product> {
             new Product { Name = "Kayak", Price = 275M },
             new Product { Name = "Lifejacket", Price = 48.95M },
             new Product { Name = "Soccer ball", Price = 19.50M }
             }.ForEach(p => AddProduct(p));
        }

        public void AddProduct(Product product) => products.Add(product.Name, product);

        public void DeleteProduct(Product product) => products.Remove(product.Name);
    }
}
