using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingApp.Model;

namespace TrainingApp
{
    public class TrainingAppContext : DbContext
    {
        public TrainingAppContext(DbContextOptions<TrainingAppContext> option): base(option) {}
        public DbSet<User> Users { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Workout> Workouts { get; set; }


    }
}
