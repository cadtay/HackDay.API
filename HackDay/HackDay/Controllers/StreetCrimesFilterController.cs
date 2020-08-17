using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackDay.Models;
using HackDay.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackDay.Controllers
{
    [Route("api/streetcrimes/[controller]")]
    [ApiController]
    public class StreetCrimesFilterController : Controller
    {
        private readonly IStreetLevelCrimesRepo _crimesRepo;

        public StreetCrimesFilterController(IStreetLevelCrimesRepo crimesRepo)
        {
            _crimesRepo = crimesRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<ActionResult<StreetLevelCrimeCategories[]>> GetStreetLevelCrimeCategories()
        {
            var streetLevelCrimeCategories = await _crimesRepo.GetStreetLevelCrimeCategories();

            if (streetLevelCrimeCategories != null)
            {
                return Ok(streetLevelCrimeCategories);
            }

            return NotFound();
        }
    }
}