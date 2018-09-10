using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConfigurationApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService uptime, ILogger<HomeController> log)
        {
            this.uptime = uptime;
            logger = log;
        }
        public IActionResult Index()
        {
            logger.LogError($"Handled {Request.Path} at uptime {uptime.Uptime}");
            return View(new Dictionary<string, string> { ["message"] = "This is the Index action", ["Time"] = uptime.Uptime.ToString() });
        }
    }
}