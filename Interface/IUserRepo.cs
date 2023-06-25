using UserAPI.Models;

namespace UserAPI.Interface
{
    public interface IUserRepo
    {   
        Task<List<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> GetDecryptUser(int id);
        Task<bool> CreateUser(UserCreateDto user);
        Task<bool> UpdateUser(UserUpdateDto user);
        Task<bool> DeleteUser(int id);
        
    }
}
