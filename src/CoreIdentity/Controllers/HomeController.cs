﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(new Dictionary<string, object> { ["Placeholder"] = "Placeholder"});
        }
    }
}