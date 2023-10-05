using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
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
        public JsonResult Get()
        {
            var users = _db.Users.ToList();
            return new JsonResult(users);
        }
    }
}
