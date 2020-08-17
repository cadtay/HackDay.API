using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackDay.Models;
using HackDay.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetCrimesController : Controller
    {
        private readonly IStreetLevelCrimesRepo _crimesRepo;

        public StreetCrimesController(IStreetLevelCrimesRepo crimesRepo)
        {
            _crimesRepo = crimesRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET api/streetcrime/GetStreetCrimeByLocationAndDefaultDate/{date}
        [HttpGet]
        [Route("GetStreetCrimeByLocationAndDefaultDate")]
        public async Task<ActionResult<StreetLevelCrimes[]>> GetStreetCrimeByLocationAndDate()
        {
            var streetLevelResultsByDate = await _crimesRepo.GetAllStreetLevelCrimesByLocationAndDate();

            if (streetLevelResultsByDate != null)
            {
                return Ok(streetLevelResultsByDate);
            }

            return NotFound();
        }
    }
}