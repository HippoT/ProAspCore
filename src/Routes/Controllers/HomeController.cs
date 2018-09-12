﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Routes.Models;

namespace Routes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new Result {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            });
        }

        public ViewResult CustomVariable(string id)
        {
            Result r = new Result {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable)
            };
            r.Data["Id"] = id ?? "<no value>";
            r.Data["Url"] = Url.Action("CustomVariable", "Home", new { id = 100 });

            return View("Index", r);
        }
    }
}