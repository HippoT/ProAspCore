using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class DerivedController : Controller
    {
        public IActionResult Index()
        {
            string page = "index";
            return View(page, $"This is a derived controller");
        }

        public ViewResult Headers() => View("DictionaryResult", Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.FirstOrDefault()));
    }
}