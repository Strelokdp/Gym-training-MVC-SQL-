﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gym_sports_training.Models.Entities
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Price { get; set; }
        public int TrainingLength { get; set; }
        public string Description { get; set; }

        public string FullName { get { return Name + LastName; }}
    }
}