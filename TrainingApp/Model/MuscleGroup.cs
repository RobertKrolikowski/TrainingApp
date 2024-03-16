using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Model
{
    [Table("MuscleGroup")]
    public class MuscleGroup
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; }
        [StringLength(250)]
        [Column("description")]
        public string? Description { get; set; }
    }
}
