using FlamingoAirwaysAPI.Models.Interfaces.cs;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysDbContext;

namespace FlamingoAirwaysAPI.Models
{
    public class TicketRepository : ITicketRepository
    {
        public Task AddTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllTicket()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }


}
