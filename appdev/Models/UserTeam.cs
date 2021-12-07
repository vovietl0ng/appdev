﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appdev.Models
{
    public class UserTeam
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}