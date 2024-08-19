using FlamingoAirwaysAPI.Models.Interfaces;
using FlamingoAirwaysAPI.Models.Interfaces.cs;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysDbContext;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;
using Microsoft.EntityFrameworkCore;


namespace FlamingoAirwaysAPI.Models.Repositories
{
    public class UserRepository : IUserRepository
    {

        FlamingoAirwaysDB _context;

        public UserRepository(FlamingoAirwaysDB context)
        {
            context = _context;
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

        public async Task<IEnumerable<User>> GetUserByEmail(string email)
        {
            return await _context.Users
                .Where(u => u.Email == email)
                .ToListAsync();
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

