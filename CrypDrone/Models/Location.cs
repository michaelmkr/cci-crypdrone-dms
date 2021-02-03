using System;

namespace CrypDrone.Models
{
    public class Location
    {
        public Location(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
            this.timestamp = DateTime.Now;
        }
        public Location(double lat, double lng, DateTime timestamp)
        {
            this.lat = lat;
            this.lng = lng;
            this.timestamp = timestamp;
        }

        public double lat { get; set; }
        public double lng { get; set; }
        public DateTime timestamp { get; set; }
    }
}
