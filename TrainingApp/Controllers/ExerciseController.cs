using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingApp.Model;

namespace TrainingApp.Controllers
{
    [Route("api/[controler]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TrainingAppContext _db;

        public ExerciseController(IConfiguration configuration, TrainingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet("GetAllExercise")]
        public async Task<IActionResult> GetAllExercise()
        {
            var exercises = _db.Exercises.ToList();
            return Ok(exercises);
        }

        [HttpPost("CreateExercise")]
        public async Task<IActionResult> CreateExercise(Exercise exercise)
        {
            exercise.Name = exercise.Name.ToLower();
            if(_db.Exercises.Any(x=> x.Name == exercise.Name))
                return BadRequest($"This exercise {exercise.Name} already exist.");

            _db.Exercises.Add(exercise);
            _db.SaveChanges();
            return Ok(exercise);
        }



        [HttpDelete("DeleteExercise")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = _db.Exercises.FirstOrDefault(x => x.Id == id);
            if(exercise == null)
                return BadRequest($"Exercise with id {id} dosn't exist.");
            _db.Exercises.Remove(exercise);
            _db.SaveChanges();
            return Ok("Exercise was deleted.");
        }

    }
}
