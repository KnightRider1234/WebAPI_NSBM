using System.Collections.Generic;

namespace WebAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocName { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; }
    }
}
