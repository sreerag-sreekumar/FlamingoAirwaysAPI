using FlamingoAirwaysAPI.Models;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysDbContext;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;
using Microsoft.EntityFrameworkCore;


namespace FlamingoAirwaysAPI.Models
{
    public class RegistrationRepository : IRegistrationRepository
    {

        FlamingoAirwaysDB _context;

        public RegistrationRepository(FlamingoAirwaysDB context)
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            _context.Users.Add(user);   
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetLogin(string email, string password)
        {
            return await _context.Users
                .Where(u => u.Email == email && u.Password==password)
                .ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUserByEmail(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email)
                .ToListAsync();
        }

        public async Task<User> GetUserIDbyEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
            //throw new NotImplementedException();
        }

        public async Task RemoveUser(int id)
        {
            var user = await GetUserById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            //throw new NotImplementedException();
        }

        public async Task UpdateUser(int id,User user)
        {
            User u = _context.Users.Find(id);
            u.FirstName = user.FirstName;
            u.LastName = user.LastName;
            u.Role = user.Role;
            u.Email = user.Email;
            u.PhoneNo = user.PhoneNo;
            u.Password = user.Password;
            await _context.SaveChangesAsync();


            //throw new NotImplementedException();
        }
    }

}

