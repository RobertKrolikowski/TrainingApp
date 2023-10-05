using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingApp.Model;

namespace TrainingApp
{
    public class TrainingAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TrainingAppContext(DbContextOptions<TrainingAppContext> option): base(option) {}

    }
}
