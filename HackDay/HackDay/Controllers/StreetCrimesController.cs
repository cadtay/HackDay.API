using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HackDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetCrimesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}