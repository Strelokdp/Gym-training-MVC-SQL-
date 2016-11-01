using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Gym_sports_training.Models.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Gym_sports_training.DAL
{
    public class GymContext:DbContext
    {
        public GymContext(): base ("GymContext")
        {

        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}