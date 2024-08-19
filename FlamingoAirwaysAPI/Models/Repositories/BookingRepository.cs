using FlamingoAirwaysAPI.Models.Interfaces.cs;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{
    public class BookingRepository : IBookingRepository
    {
        public Task AddBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetAllBooking()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingById(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}