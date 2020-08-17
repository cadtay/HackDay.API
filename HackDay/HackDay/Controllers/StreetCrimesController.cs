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

        /***
         * The below Method returns all of the crimes for a specific area for July 2020.
         * a 'date' argument can be quickly added (YYY-MM) to change it.
         ***/

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

        // -- GET api/streetcrime/GetStreetCrimeById/{id}
        [HttpGet]
        [Route("GetStreetCrimeById/{id}")]
        public async Task<ActionResult<StreetLevelCrimes>> GetStreetCrimeById(int id)
        {
            // PLACEHOLDER ID: 84752354, this works in Postman
            var streetLevelResult = await _crimesRepo.GetStreetLevelCrimeById(id);

            if (streetLevelResult != null)
            {
                return Ok(streetLevelResult);
            }

            return NotFound();
        }
    }
}