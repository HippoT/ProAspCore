using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsingViewComponent.Models;

namespace UsingViewComponent.Controllers
{
    public class HomeController : Controller
    {
        private IRepository Repository;

        public HomeController(IRepository reposity)
        {
            Repository = reposity;
        }

        public ViewResult Index()
        {
            return View(Repository.Cities);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public IActionResult Create(City city)
        {
            Repository.AddCity(city);
            return RedirectToAction("Index");
        }
    }
}