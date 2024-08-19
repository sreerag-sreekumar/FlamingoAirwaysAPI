using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models.Interfaces.cs
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingById(int id);
        Task<IEnumerable<Booking>> GetAllBooking();
        Task AddBooking(Booking booking);
        Task UpdateBooking(Booking booking);
        Task RemoveBooking(Booking booking);
    }
}
