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
    public class StopSearchController : Controller
    {
        private readonly IStopSearchRepository _searchSearchRepository;

        public StopSearchController(IStopSearchRepository stopSearchRepository)
        {
            _searchSearchRepository = stopSearchRepository;
        }

        [HttpGet("all-stop-search")]
        public async Task<IActionResult> Index()
        {
            var stopSearches = await _searchSearchRepository.GetStopSearches();

            if (stopSearches != null)
            {
                return Ok(stopSearches);
            }

            return NotFound();
        }
    }
}
