using static FlamingoAirwaysAPI.Models.FlamingoAirwaysDbContext;
using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models.Repositories
{
    public interface ILogin
    {
        User ValidateUser(string uname, string pwd);
        //bool ValidateUser1(User user);
        int GetUserIdByEmail(string email);
    }

    public class LoginRepo : ILogin
    {
        FlamingoAirwaysDB _context;
        RegistrationRepository _registrationRepo;

        public LoginRepo(FlamingoAirwaysDB context)
        {
            _context = context;
        }
        //public LoginServices(RegistrationRepository registrationRepo)
        //{
        //    _registrationRepo = registrationRepo;
        //}

        public User? ValidateUser(string email, string password)
        {
            User user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }
            return null;  // Return null if user is not found or password doesn't match
        }

        //public bool ValidateUser1(User user)
        //{
        //    User u = _context.Users.Where(us => us.Email == user.Email).Single();
        //    if (u.Password == user.Password)
        //    {
        //        return user.UserId;
        //    }

        //    else
        //    {
        //        return false;
        //    }

        //    //throw new NotImplementedException();
        //}

        public int GetUserIdByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Email==email);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user?.UserId ?? 0;
        }
    }

}
