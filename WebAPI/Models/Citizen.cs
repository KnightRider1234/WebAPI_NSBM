using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class Citizen : User
    {
        public HealthStatus HealthStatus { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }

}
