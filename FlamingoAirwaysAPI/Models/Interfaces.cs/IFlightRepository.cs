using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{
    public interface IFlightRepository
    {
        Task<Flight> GetFlightById(int id);
        Task<IEnumerable<Flight>> GetAllFlights();
        Task AddFlight(Flight flight);
        Task UpdateFlight(int id,Flight flight);
        Task UpdateFlight1(Flight flight);
        Task RemoveFlight(int id);
        Task<IEnumerable<Flight>> SearchFlightsAsync(string origin, string destination, DateTime departureDate);
        //Task UpdateFlight(int id,Flight value);

        Task<Flight> GetByBookingIdAsync(int bookingId);
        Task UpdateAsync(Flight flight);
        Task DeleteAsync(int id);
        Task<Flight> GetByIdAsync(int id);

    }
}
