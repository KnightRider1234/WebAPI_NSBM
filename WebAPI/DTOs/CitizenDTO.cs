using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Enums;

namespace WebAPI.DTOs
{
    public class CitizenDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public UserType Type { get; set; }
        public string UserName { get; set; }
        public HealthStatus HealthStatus { get; set; } 
        public string Address { get; set; }
        public List<Location> Locations { get; set; }
        public int Telephone { get; set; }
    }
}
