using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Model
{
    [Table("user")]
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("age")]
        [Range (0,150)]
        public int Age { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("trainings")]
        public List<Workout> Trainings { get; set; }
    }
}
