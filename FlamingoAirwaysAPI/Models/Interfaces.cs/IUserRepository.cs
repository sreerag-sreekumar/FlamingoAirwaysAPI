using static FlamingoAirwaysAPI.Models.FlamingoAirwaysModel;

namespace FlamingoAirwaysAPI.Models.Interfaces.cs
{
    public interface IUserRepository
    {

        //User methods
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<User>> GetUserByEmail(string email);

        Task AddUser(User user);
        Task UpdateUser(int id,User user);
        Task RemoveUser(int id);


    }
}
