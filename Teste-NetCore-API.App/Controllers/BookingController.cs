using Microsoft.AspNetCore.Mvc;
using Teste_NetCore_API.App.Domain.Interfaces.Services;

namespace Teste_NetCore_API.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingDomainService _bookingDomainService;

        public BookingController(IBookingDomainService bookingDomainService)
        {
            _bookingDomainService = bookingDomainService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingDomainService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _bookingDomainService.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound("Booking not found");
            }
            return Ok(booking);
        }
    }
}
