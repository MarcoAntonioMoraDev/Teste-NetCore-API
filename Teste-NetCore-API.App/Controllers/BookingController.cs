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
        public IActionResult GetAll()
        {
            var bookings = _bookingDomainService.GetAll();
            return Ok(bookings); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var booking = _bookingDomainService.GetById(id);
            if (booking == null)
            {
                return NotFound("Booking not found"); 
            }
            return Ok(booking);
        }
    }
}
