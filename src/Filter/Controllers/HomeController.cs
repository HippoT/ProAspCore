using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Filter.Infrastructure;

namespace Filter.Controllers
{
    [ViewResultDetails]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", "This is the index action on the Home Controller");
        }

        public ViewResult SecondAction() => View("Index", "This is the second action on the Home controller");
    }
}