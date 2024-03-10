using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Model
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("last_name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("birthday")]
        public DateTime Birthday { get; set; }
        [Column("email")]
        [EmailAddress]
        public string Email { get; set; }
        [Column("trainings")]
        public List<Workout> Trainings { get; set; }
    }
}
