using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.Enums;

namespace WebAPI.DTOs
{
    public class PHIDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string UserName { get; set; }
        public UserType Type { get; set; }
    }
}
