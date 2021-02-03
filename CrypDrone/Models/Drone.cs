using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CrypDrone.Models
{
    public class Drone
    {
        public Drone()
        {
            this.droneId = Guid.NewGuid().ToString();
            this.location = new Location(48.2139, 15.6316);
            history = new List<Location>();
        }
        public Drone(string name, string customer, DateTime validUntil, bool active)
        {
            this.droneId = Guid.NewGuid().ToString();
            this.name = name;
            this.customer = customer;
            this.validUntil = validUntil;
            this.active = active;
            this.location = new Location(48.2139, 15.6316);
            history = new List<Location>();
        }

        [Display(Name = "ID")]
        public string droneId { get; set; }
        [Display(Name = "Drone name")]
        public string name { get; set; }
        [Display(Name = "Customer")]
        public string customer { get; set; }
        [Display(Name = "Expires at")]
        public DateTime validUntil { get; set; }
        [Display(Name = "Active")]
        public bool active { get; set; }
        [Display(Name = "Location")]
        public Location location { get; set; }
        [Display(Name = "History")]
        public List<Location> history { get; set; }
    }
}
