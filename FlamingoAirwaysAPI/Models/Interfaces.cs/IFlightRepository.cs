﻿using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models.Interfaces.cs
{
    public interface IFlightRepository
    {
        Task<Flight> GetFlightById(int id);
        Task<IEnumerable<Flight>> GetAllFlights();
        Task AddFlight(Flight flight);
        Task UpdateFlight(int id,Flight flight);
        Task RemoveFlight(int id);
        Task<IEnumerable<Flight>> SearchFlightsAsync(string origin, string destination, DateTime departureDate);
        //Task UpdateFlight(int id,Flight value);
    }
}
