using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DI.Models;
using DI.Infrastructure;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index([FromServices]ProductTotalizer productTotalizer)
        {
            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = productTotalizer.Repository.ToString();
            return View(repository.Products);
        }
    }
}