namespace InfoTrackBookingService.IService
{
    public interface IBookingRepository
    {
        Task<int> GetBookingCountAsync(DateTime timeSlot);
        Task AddBookingAsync(DateTime timeSlot, string name);
    }
}
