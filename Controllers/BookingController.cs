using InfoTrackBookingService.Handler;
using InfoTrackBookingService.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackBookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookingRequest request)
        {
            var result = await _mediator.Send(new CreateBookingCommand(request.BookingTime, request.Name));
            return Ok(result);
        }
    }
}
