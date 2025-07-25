﻿using Microsoft.AspNetCore.Identity;

namespace DahiraAgency.Data
{
    public class Favourite
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}