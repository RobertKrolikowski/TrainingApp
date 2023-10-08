using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TrainingApp.Model
{
    [Table("workout")]
    public class Workout
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("workoutStart")]
        public DateTime WorkoutStart { get; set; } = DateTime.Now;
        [Column("workoutEnd")]
        public DateTime? WorkoutEnd { get; set; }
        [Column("series")]
        public List<Serie> Series { get; set; } = new List<Serie>();
        [Column("description")]
        public string? Description { get; set; }
    }
}
