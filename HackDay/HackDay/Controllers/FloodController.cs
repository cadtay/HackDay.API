using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HackDay.Controllers
{
    public class FloodController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
