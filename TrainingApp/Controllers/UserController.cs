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

        [HttpGet]
        public IActionResult Get()
        {
            var users = _db.Users.ToList();
            return new JsonResult(users);
        }
        [HttpPost("CreateNewUser")]
        public IActionResult AddUser(string firstName, string lastName, int age, string email)
        {
            if (!ModelState.IsValid)
                return BadRequest("eeeeeeeeee");
            if (!Regex.IsMatch(email, @"\w+@\w+\.\w+"))
                return BadRequest("Invalid email");
            if (_db.Users.Any(x=> x.Email == email.ToLower()))
                return BadRequest(@$"This email {email} is already exist in DB");
            if(age <= 0 || age >= 200)
                return BadRequest(@$"Invalid age");

            User user = new User() { FirstName = firstName, LastName = lastName, Age = age, Email = email.ToLower() };
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user); 
        }
    }
}
