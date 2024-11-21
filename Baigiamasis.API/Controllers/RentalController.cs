using Baigiamasis.Core.Contracts.IServices;
using Baigiamasis.Core.Models;
using Baigiamasis.Core.Models.Knygos;
using Baigiamasis.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Baigiamasis.API.Controllers
{
    [ApiController]
    [Route("Rentals")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("AddRental")]
        public void AddRental(Rental rental)
        {
            Log.Information("AddRental request received");
            try
            {
                _rentalService.AddRental(rental);
                Log.Information("AddRental request completed");

            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method AddRental. Exception thrown {e.Message}");
            }
        }

        [HttpPatch("EndRental")]
        public void EndRental(int id)
        {
            Log.Information("EndRental request received");
            try
            {
                _rentalService.EndRental(id);
                Log.Information("EndRental request completed");

            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method EndRental. Exception thrown {e.Message}");
            }
        }

        [HttpGet("GetActiveRentalsByUser")]
        public IActionResult GetActiveRentalsByUser(int userId)
        {
            Log.Information("GetActiveRentalsByUser request received");
            try
            {
                var x = _rentalService.GetActiveRentalsByUser(userId);
                Log.Information("GetActiveRentalsByUser request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetActiveRentalsByUser. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetAllRentalsByUser")]
        public IActionResult GetAllRentalsByUser(int userId)
        {
            Log.Information("GetAllRentalsByUser request received");
            try
            {
                var x = _rentalService.GetAllRentalsByUser(userId);
                Log.Information("GetAllRentalsByUser request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllRentalsByUser. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetAllRentals")]
        public IActionResult GetAllRentals()
        {
            Log.Information("GetAllRentals request received");
            try
            {
                var x = _rentalService.GetAllRentals();
                Log.Information("GetAllRentals request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllRentals. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetAllUsersByBook")]
        public IActionResult GetAllUsersByBook(int bookId)
        {
            Log.Information("GetAllUsersByBook request received");
            try
            {
                var x = _rentalService.GetAllUsersByBook(bookId);
                Log.Information("GetAllUsersByBook request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllUsersByBook. Exception thrown {e.Message}");
            }
            return NotFound();
        }
    }
}
