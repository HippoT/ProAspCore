using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkingWithRazor.Models;

namespace WorkingWithRazor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product product = new Product() {
                ProductID = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "Watersport",
                Price = 275M
            };

            ViewBag.StockLevel = 2;
            return View(product);
        }
    }
}