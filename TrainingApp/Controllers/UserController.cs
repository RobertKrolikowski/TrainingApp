using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TrainingApp.Model;

namespace TrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TrainingAppContext _db;

        public UserController(IConfiguration configuration, TrainingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = _db.Users.ToList();
            return Ok(users);
        }
        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Wrong user.");
            user.Email = user.Email.ToLower();
            if (_db.Users.Any(x => x.Email == user.Email))
                return BadRequest($"User with email {user.Email} already exist.");

            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(User user)
        {
            if (!_db.Users.Any(x => x.ID == user.ID))
                return BadRequest("User dosn't exist");

            _db.Users.Update(user);
            _db.SaveChanges();
            return Ok("User was edited");
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = _db.Users.FirstOrDefault(x => x.ID == userId);
            if (user == null)
                return BadRequest($"User with id {userId} dosn't exist");

            _db.Users.Remove(user);
            _db.SaveChanges();
            return Ok($"User was deleted.");
        }

    }
}
