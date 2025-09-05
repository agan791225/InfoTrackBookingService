using InfoTrackBookingService.IService;
using InfoTrackBookingService.Models;
using MediatR;

namespace InfoTrackBookingService.Handler
{
    public class CreateBookingCommand : IRequest<BookingResponse>
    {
        public string BookingTime { get; }
        public string Name { get; }

        public CreateBookingCommand(string bookingTime, string name)
        {
            BookingTime = bookingTime;
            Name = name;
        }
    }

    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, BookingResponse>
    {
        private readonly IBookingService _service;

        public CreateBookingHandler(IBookingService service)
        {
            _service = service;
        }

        public async Task<BookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            return await _service.CreateBookingAsync(request.BookingTime, request.Name);
        }
    }
}
