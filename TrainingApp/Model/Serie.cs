using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp.Model
{
    [Table("serie")]
    public class Serie
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("serie_start")]
        public DateTime SerieStart { get; set; } = DateTime.Now;
        [Column("serie_end")]
        public DateTime? SerieEnd { get; set; }
        [Column("exercise")]
        public Exercise Exercise { get; set; }
        [Column("weight")]
        public double Weight { get; set; }
        [Column("reps")]
        public int Reps { get; set; }
        [Column("description")]
        public string? Description { get; set; }

    }
}
