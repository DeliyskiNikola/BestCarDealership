using BestCarDealership.BL.Interfaces;
using BestCarDealership.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace BestCarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDealershipController : ControllerBase
    {
        private readonly ICarDealershipService _carDealershipService;

        public CarDealershipController(ICarDealershipService carDealershipService)
        {
            _carDealershipService = carDealershipService;
        }

        [HttpPost("GetCarsByDealership")]
        public ActionResult<GetCarsByDealershipResponse?> GetCarsByDealership(GetCarsByDealershipRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request.");
            }

            var response = _carDealershipService.GetCarsByDealership(request);

            if (response != null)
            {
                return Ok(response);
            }

            return NotFound();
        }
    }
}
