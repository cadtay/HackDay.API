using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackDay.Modals;
using HackDay.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackDay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloodController : Controller
    {
        private readonly IFloodRepository _floodRepository;

        public FloodController(IFloodRepository floodRepository)
        {
            _floodRepository = floodRepository;
        }
        [HttpGet("flood")]
        public async Task<IActionResult> Index(FloodViewModel floodModel)
        {
            var floodAsync = await _floodRepository.GetFloodAsync(floodModel);

            if (floodAsync != null)
            {
                return Ok(floodAsync);
            }

            return NotFound();
        }
    }
}
