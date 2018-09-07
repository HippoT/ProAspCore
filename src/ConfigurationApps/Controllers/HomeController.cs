using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        public HomeController(UptimeService uptime)
        {
            this.uptime = uptime;
        }
        public IActionResult Index()
        {
            return View(new Dictionary<string, string> { ["message"] = "This is the Index action", ["Time"] = uptime.Uptime.ToString() });
        }
    }
}