using InfoTrackBookingService.Models;

namespace InfoTrackBookingService.IService
{
    public interface IBookingService
    {
        Task<BookingResponse> CreateBookingAsync(string time, string name);
    }
}
