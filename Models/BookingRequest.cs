using System.ComponentModel.DataAnnotations;

namespace InfoTrackBookingService.Models
{
    public class BookingRequest
    {
        public string BookingTime { get; set; } // Format: "HH:mm"
        [Required]
        [MinLength(1, ErrorMessage = "Name cannot be empty.")]
        public string Name { get; set; }
    }

    public class BookingResponse
    {
        public Guid BookingId { get; set; }
    }
}
