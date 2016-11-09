using Gym_sports_training.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_sports_training.DAL
{
    public class GymInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GymContext>
    {
        protected override void Seed(GymContext context)
        {
            var clients = new List<Client>
            {
                new Client { Name = "Bob", LastName = "Smith", EMail="bob.smith@mail.ru", PhoneNumber= "0671916712" },
                new Client { Name = "Tony", LastName = "Adams", EMail = "tony.adams@mail.ru", PhoneNumber="0671581561" },
                new Client { Name = "Adam", LastName = "Scott", EMail = "adam.scott@mail.ru", PhoneNumber = "0931385858" }
            };

            clients.ForEach(g => context.Clients.Add(g));
            context.SaveChanges();

            var coaches = new List<Coach>
            {
                new Coach {Name="Jack", LastName = "Hobbs", Speciality=Speciality.Cardio, Price=30, TrainingLength=45, Description="Good coach" },
                new Coach {Name="Miki", LastName = "Roque", Speciality=Speciality.Fitness, Price=25, TrainingLength=60, Description="Good coach" },
                new Coach {Name="Craig", LastName = "Lindfield", Speciality=Speciality.Boxing, Price=35, TrainingLength=40, Description="Good coach" },
                new Coach {Name="Bojan", LastName = "Krkic", Speciality=Speciality.Boxing, Price=35, TrainingLength=40, Description="Good coach" },
            };

            coaches.ForEach(g => context.Coaches.Add(g));
            context.SaveChanges();

            var trainingSessions = new List<TrainingSession>
            {
                new TrainingSession { ClientId = 1, CoachId = 1, TrainingTimeStart = DateTime.Now.AddDays(-10)},
                new TrainingSession { ClientId = 2, CoachId = 2, TrainingTimeStart = DateTime.Now},
                new TrainingSession { ClientId = 3, CoachId = 3, TrainingTimeStart = DateTime.Now.AddDays(10) },
                new TrainingSession { ClientId = 1, CoachId = 3, TrainingTimeStart = DateTime.Now.AddDays(12) },
                new TrainingSession { ClientId = 3, CoachId = 2, TrainingTimeStart = DateTime.Now.AddDays(-5) }
            };

            trainingSessions.ForEach(g => context.TrainingSessions.Add(g));
            context.SaveChanges();

            var contacts = new List<Contact>
            {
                new Contact
                {
                    Name = "Debra Garcia",
                    Address = "1234 Main St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "debra@example.com",
                },
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com",
                },
                new Contact
                {
                    Name = "Yuhong Li",
                    Address = "9012 State st",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "yuhong@example.com",
                },
                new Contact
                {
                    Name = "Jon Orton",
                    Address = "3456 Maple St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "jon@example.com",
                },
                new Contact
                {
                    Name = "Diliana Alexieva-Bosseva",
                    Address = "7890 2nd Ave E",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "diliana@example.com",
                }
            };

            contacts.ForEach(g => context.Contacts.Add(g));
            context.SaveChanges();
        }
    }
}