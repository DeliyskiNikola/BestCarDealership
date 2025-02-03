using BestCarDealership.BL.Interfaces;
using BestCarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestCarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipController : ControllerBase
    {
        private readonly IDealershipService _dealershipService;

        public DealershipController(IDealershipService dealershipService)
        {
            _dealershipService = dealershipService;
        }

        [HttpGet("GetDealershipById")]
        public ActionResult<Dealership> GetDealershipById(int id)
        {
            var dealership = _dealershipService.GetDealershipById(id);

            if (dealership != null)
            {
                return Ok(dealership);
            }

            return NotFound();
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Dealership>> GetAllDealerships()
        {
            var dealerships = _dealershipService.GetAllDealerships();

            if (dealerships != null && dealerships.Count > 0)
            {
                return Ok(dealerships);
            }

            return NoContent();
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Dealership dealership)
        {
            if (dealership == null) return BadRequest("Invalid dealership data.");

            _dealershipService.AddDealership(dealership);

            return CreatedAtAction(nameof(GetDealershipById), new { id = dealership.Id }, dealership);
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            var existingDealership = _dealershipService.GetDealershipById(id);

            if (existingDealership == null)
            {
                return NotFound();
            }

            _dealershipService.RemoveDealership(id);
            return NoContent();
        }
    }
}
