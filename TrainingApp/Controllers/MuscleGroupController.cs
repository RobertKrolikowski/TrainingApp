using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using TrainingApp.Model;

namespace TrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleGroupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TrainingAppContext _db;

        public MuscleGroupController(IConfiguration configuration, TrainingAppContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpGet("GetAllMuscleGroups")]
        public async Task<IActionResult> GetaAllMuscleGroup()
        {
            var muscleGoups = _db.MuscleGroups.ToList();
            return Ok(muscleGoups);
        }

        [HttpPost("CreateNewMuscleGroup")]
        public async Task<IActionResult> AddMuscleGroup(MuscleGroup muscleGroup)
        {
            muscleGroup.Name = muscleGroup.Name.ToLower();
            if (_db.MuscleGroups.Any(x => x.Name == muscleGroup.Name))
                return BadRequest($"This muscle group {muscleGroup.Name} already exist.");
            _db.MuscleGroups.Add(muscleGroup);
            _db.SaveChanges();
            return Ok(muscleGroup);
        }

        [HttpPost("EditMuscleGroup")]
        public async Task<IActionResult> EditMuscleGroup(MuscleGroup muscleGroup)
        {
            if (!_db.MuscleGroups.Any(x => x.Id == muscleGroup.Id))
                return BadRequest("Muscle group dosn't exist");

            _db.Update(muscleGroup);
            _db.SaveChanges();
            return Ok("Muscle group was edited");
        }

        [HttpDelete("DeleteMuscleGroup")]
        public async Task<IActionResult> DeleMuscleGroup(int id)
        {
            var muscleGroup = _db.MuscleGroups.FirstOrDefault(x => x.Id == id);
            if (muscleGroup == null)
                return BadRequest($"Muscle group with id {id} dosn't exist.");
            _db.MuscleGroups.Remove(muscleGroup);
            _db.SaveChanges();
            return Ok("Muscle group was deleted.");
        }

    }
}
