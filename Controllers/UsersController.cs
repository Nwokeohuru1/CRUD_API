using Microsoft.AspNetCore.Mvc;
using UserAPI.Interface;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers() 
        {
            var users = await _userRepo.GetUsers();
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepo.GetUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("GetDecryptUser")]
        public async Task<IActionResult> GetDecryptUser(int id)
        {
            var user = await _userRepo.GetDecryptUser(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser(UserCreateDto user)
        {
            await _userRepo.CreateUser(user);
            return StatusCode(StatusCodes.Status201Created, "successfully created");
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto user)
        {
            var result = await _userRepo.GetUser(user.Id);
            if (result == null)
            {
                return BadRequest("User not found");
            }
            await _userRepo.UpdateUser(user);

            return StatusCode(StatusCodes.Status200OK, "successfully Updated");
        }



        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var user = await _userRepo.GetUser(id);
            if(user == null)
            {
                return BadRequest("User not found");
            }
            await _userRepo.DeleteUser(id);

            return StatusCode(StatusCodes.Status200OK, "successfully Deleted");
        }

    }
}
