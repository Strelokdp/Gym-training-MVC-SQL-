using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_sports_training.Models.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName { get { return Name + LastName; } }
    }
}