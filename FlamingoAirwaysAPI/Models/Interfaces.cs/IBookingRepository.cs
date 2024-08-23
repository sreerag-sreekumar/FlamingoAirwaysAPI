using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{ 
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
        Task<Booking> GetByIdAsync(int id);
        Task<Booking> GetByPnrAsync(string pnr);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task AddAsync(Booking booking);
        Task CancelAsync(int id); // Cancel entire booking
        Task DeleteTicketsByBookingIdAsync(int bookingId); // New method for deleting tickets
    }
}
