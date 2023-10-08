using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Model
{
    [Table("exercise")]
    public class Exercise
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("muscle_groups")]
        public List<MuscleGroup> MuscleGroups { get; set; }
    }
}
