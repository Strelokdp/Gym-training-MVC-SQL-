using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_sports_training.Models.Entities
{
    public class TrainingSession
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Coach Coach { get; set; }
        public DateTime TrainingTimeStart { get; set; }
    }
}