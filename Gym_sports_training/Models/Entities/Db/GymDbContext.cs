using System.Data.Entity;

namespace Gym_sports_training.Models.Entities.Db
{
    public class GymDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
    }
}