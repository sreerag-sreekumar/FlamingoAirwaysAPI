using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models
{
    public interface IRegistrationRepository
    {

        //User methods
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUserByEmail(string email);

        Task<User> GetUserIDbyEmail(string email);

        Task<IEnumerable<User>> GetLogin(string email, string password);

        Task AddUser(User user);
        Task UpdateUser(int id,User user);
        Task RemoveUser(int id);


    }
}
