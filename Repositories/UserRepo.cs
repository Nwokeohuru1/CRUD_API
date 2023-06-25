using UserAPI.Data;
using UserAPI.Helpers;
using UserAPI.Interface;
using UserAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace UserAPI.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDbContext _userDb;
        private readonly Encryption _encryption;
        public UserRepo(UserDbContext userDb, Encryption encryption)
        {
            _userDb = userDb;
            _encryption = encryption;
        }
        public async Task<bool> CreateUser(UserCreateDto user)
        {
            var password = _encryption.Encrypt(user.Password);
            var CreatedUser = new User
            {
                Password = password,
                UserName = user.UserName,
                Quantity = user.Quantity,
                UserCreated = user.UserCreated,
                DateCreated = DateTime.UtcNow,                        
                DelFlag = false

              
            };  
            _userDb.Add(CreatedUser);
           await _userDb.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await GetUser(id);
            user.DelFlag = true;
            _userDb.Update(user);
            await _userDb.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _userDb.users.Where(u => u.Id == id && u.DelFlag == false).FirstOrDefaultAsync();
            
            return user;
        }
        public async Task<User> GetDecryptUser(int id)
        {
            var user = await _userDb.users.Where(u => u.Id == id && u.DelFlag == false).FirstOrDefaultAsync();
            user.Password = _encryption.Decrypt(user.Password);
            _userDb.Update(user);
            
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var user = await _userDb.users.Where(u => u.DelFlag == false).ToListAsync();
            return user;
        }

        public async Task<bool> UpdateUser(UserUpdateDto user)
        {
            var password = _encryption.Encrypt(user.Password);
            var Edituser = new User
            {
                Id = user.Id,
                Password = password,
                UserName = user.UserName,
                Quantity = user.Quantity,
                DateModified = user.DateModified,
                UserModified = user.UserModified,
                
            };
            _userDb.Update(Edituser);
            await _userDb.SaveChangesAsync();
            return true;
        }
    }
}
