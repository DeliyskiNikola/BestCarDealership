using BestCarDealership.BL.Interfaces;
using BestCarDealership.Models;
using Microsoft.AspNetCore.Mvc;

namespace BestCarDealership.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetCarById")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car = _carService.GetCarById(id);

            if (car != null)
            {
                return Ok(car);
            }

            return NotFound();
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Car>> GetAllCars()
        {
            var cars = _carService.GetAllCars();

            if (cars != null && cars.Count > 0)
            {
                return Ok(cars);
            }

            return NoContent();
        }

        [HttpPost("Add")]
        public ActionResult Add([FromBody] Car car)
        {
            if (car == null) return BadRequest("Invalid car data.");

            _carService.AddCar(car);

            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            var existingCar = _carService.GetCarById(id);

            if (existingCar == null)
            {
                return NotFound();
            }

            _carService.RemoveCar(id);
            return NoContent();
        }
    }
}
