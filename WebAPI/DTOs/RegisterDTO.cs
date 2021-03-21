using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Models.Enums;

namespace WebAPI.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        public UserType Type { get; set; } = 0;
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public HealthStatus HealthStatus { get; set; } = 0;
        public string Address { get; set; }
        public Location Location { get; set; }
        public int Telephone { get; set; }
    }
}
