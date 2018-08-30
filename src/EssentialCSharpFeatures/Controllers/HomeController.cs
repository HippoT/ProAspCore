using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EssentialCSharpFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace EssentialCSharpFeatures.Controllers
{
    public class HomeController : Controller
    {

        bool FilterByPrice(Product p)
        {
            return (p?.Price ?? 0) >= 20;
        }

        public IActionResult Index()
        {
            //List<string> results = new List<string>();
            //foreach (Product p in Product.GetProducts())
            //{
            //    string name = p?.Name??"<No Name>";
            //    decimal? price = p?.Price ?? 0;
            //    string relatedName = p?.Related?.Name ?? "<No Name>";
            //    results.Add(string.Format($"Name: {name}, Price: {price:C2}, Related: {relatedName}, Instock: {p?.InStock}"));
            //}
            //return View(results);

            Product[] products = { new Product { Name = "Tran", Price = 275M },
                new Product { Name = "Minh", Price = 48.95M },
                new Product { Name = "Tuan", Price = 16M },
                new Product { Name = "Min", Price = 21M }
            };

            var list = new[]
            {
                new {Name = "Tran", Price = 123},
                new {Name = "Minh", Price = 124},
                new {Name = "Tuan", Price = 125}
            };
            Func<Product, bool> nameFilter = delegate (Product p)
            {
                return p?.Name?[0] == 'T';
            };

            decimal productsTotal = products.Filter(p => (p?.Price ?? 0) >= 20).TotalPrice();
            decimal product = products.Filter(p => (p?.Name?[0] == 'T')).TotalPrice();

            return View(new string[]
            {
                $"{nameof(productsTotal)}: {productsTotal:c2}",
                $"{nameof(product)}: {product:c2}"
            });
        }
    }
}