using InfoTrackBookingService.IService;
using InfoTrackBookingService.Models;

namespace InfoTrackBookingService.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly int _maxSettlements;

        public BookingService(IBookingRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
            _maxSettlements = Convert.ToInt32(_configuration.GetSection("AppSettings:MaxSettlements").Value);
        }

        public async Task<BookingResponse> CreateBookingAsync(string time, string name)
        {
            if (!TimeSpan.TryParse(time, out var bookingTime))
                throw new BadRequestException("Invalid time format.");

            var now = DateTime.Now;
            var bookingDateTime = now.Date + bookingTime;

            if (bookingTime < TimeSpan.FromHours(9) || bookingTime > TimeSpan.FromHours(16))
                throw new BadRequestException("Booking time must be between 09:00 and 16:00.");

            var count = await _repository.GetBookingCountAsync(bookingDateTime);
            if (count >= _maxSettlements)
                throw new ConflictException("Maximum simultaneous bookings reached.");

            await _repository.AddBookingAsync(bookingDateTime, name);

            return new BookingResponse { BookingId = Guid.NewGuid() };
        }
    }
}
