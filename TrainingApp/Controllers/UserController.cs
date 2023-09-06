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
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT *
	                    FROM public.""user""";
            string sqlDataSource = _configuration.GetConnectionString("dockerDB");
            NpgsqlDataReader reader;
            List<User> users = new List<User>();
            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query,connection))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            ID = Int32.Parse(reader[0].ToString()),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString()
                        });

                    }
                    reader.Close();
                    connection.Close();
                }
            }
            return new JsonResult(users);
        }
    }
}
