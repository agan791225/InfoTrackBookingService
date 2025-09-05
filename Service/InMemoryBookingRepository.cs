using InfoTrackBookingService.IService;

namespace InfoTrackBookingService.Service
{
    public class InMemoryBookingRepository : IBookingRepository
    {
        private readonly Dictionary<DateTime, List<string>> _bookings = new();

        public Task<int> GetBookingCountAsync(DateTime timeSlot)
        {
            _bookings.TryGetValue(timeSlot, out var list);
            return Task.FromResult(list?.Count ?? 0);
        }

        public Task AddBookingAsync(DateTime timeSlot, string name)
        {
            if (!_bookings.ContainsKey(timeSlot))
                _bookings[timeSlot] = new List<string>();

            _bookings[timeSlot].Add(name);
            return Task.CompletedTask;
        }
    }
}
