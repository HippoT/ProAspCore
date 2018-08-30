using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using Moq;

namespace XUnitTest
{
    public class HomeControllerTest
    {
        class ModelCompleteFakeReposity : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {
            }
        }

        [Theory]
        //[InlineData(275,48.95,19.50,24.95)]
        //[InlineData(5,48.95,19.50,24.95)]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] p)
        {
            //var controller = new HomeController();
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(p);
            var controller = new HomeController { Repository = mock.Object };

            controller.Repository = new ModelCompleteFakeReposity {
                Products = p
            };

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        //class ModelCompleteFakeReposityUnder50 : IRepository
        //{
        //    public IEnumerable<Product> Products => new Product[]
        //    {
        //        new Product{Name = "P1", Price = 5M},
        //        new Product{Name = "P2", Price = 48.95M},
        //        new Product{Name = "P3", Price = 19.50M},
        //        new Product{Name = "P4", Price = 34.59M}
        //    };

        //    public void AddProduct(Product p)
        //    {
        //    }
        //}
        //[Fact]
        //public void IndexActionModelIsCompleteUnder50()
        //{
        //    var controller = new HomeController();

        //    controller.Repository = new ModelCompleteFakeReposityUnder50();

        //    var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

        //    Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        //}

        class PropertyOnceFakeRepository : IRepository
        {
            public int PropertyCounter { get; set; } = 0;
            public IEnumerable<Product> Products
            {
                get
                {
                    PropertyCounter++;
                    return new[] { new Product { Name = "P1", Price = 100 } };
                }
            }
            public void AddProduct(Product p)
            {
                // do nothing - not required for test
            }
        }
        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange
            var repo = new PropertyOnceFakeRepository();
            var controller = new HomeController { Repository = repo };
            // Act
            var result = controller.Index();
            // Assert
            Assert.Equal(1, repo.PropertyCounter);
        }
    }

    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPricesUnder50() };
            yield return new object[] { GetPricesOver50 };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IEnumerable<Product> GetPricesUnder50()
        {
            decimal[] prices = new decimal[] { 275, 49.95M, 19.50M, 24.95M };
            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product { Name = $"P{i + 1}", Price = prices[i] };
            }
        }

        private Product[] GetPricesOver50 => new Product[] {
             new Product { Name = "P1", Price = 5 },
             new Product { Name = "P2", Price = 48.95M },
             new Product { Name = "P3", Price = 19.50M },
             new Product { Name = "P4", Price = 24.95M }
        };
    }


}
