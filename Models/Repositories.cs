﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDevBlipAPI.Models {
    public class Repositories {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; } 
        public DateTime CreatedAt { get; set; }

        public Repositories(string name, string language, string description, DateTime createdAt) {
            Name = name;
            Language = language;
            Description = description;
            CreatedAt = createdAt;
        }
    }
}
