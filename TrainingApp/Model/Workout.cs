using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TrainingApp.Model
{
    [Table("workout")]
    public class Workout
    {
        [Column("id")]
        public int Id { get; set; }
        [StringLength(50)]
        [Column("name")]
        public string? Name { get; set; }
        [Column("workoutStart")]
        public DateTime WorkoutStart { get; set; } = DateTime.Now;
        [Column("workoutEnd")]
        public DateTime? WorkoutEnd { get; set; }
        [Column("series")]
        public List<Serie> Series { get; set; } = new List<Serie>();
        [StringLength(250)]
        [Column("description")]
        public string? Description { get; set; }
    }
}
