using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialCSharpFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; } = "Watersports";
        public Product Related { get; set; }
        public bool InStock { get; }

        public Product(bool inStock = true)
        {
            InStock = inStock;
        }

        public static Product[] GetProducts()
        {
            Product kayak = new Product { Name = "Kayak", Price = 275M, Category = "Water Craft" };
            Product lifejacket = new Product(false) { Name = "Lifejacket", Price = 48.95M };
            kayak.Related = lifejacket;

            ShoppingCart shoppingCart = new ShoppingCart();

            return new Product[] {kayak, lifejacket, null};
        }
    }
}
