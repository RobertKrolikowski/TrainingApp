using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Model
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("trainings")]
        public List<Workout> Trainings { get; set; }
    }
}
