using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Controllers.Controllers
{
    public class PocoController : Controller
    {
        public ViewResult Index()
        {
            return new ViewResult()
            {
                ViewName = "index",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = $"This is a POCO controller"
                }
            };
        }
    }
}