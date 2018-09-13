using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DI.Models;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View(new MemoryRepository().Products);
    }
}