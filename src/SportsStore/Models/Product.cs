using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }

    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{Name = "Football", Price = 25},
            new Product {Name = "Surf board", Price = 179},
            new Product {Name = "Running shoes", Price = 95}
        }.AsQueryable<Product>();
    }
}
