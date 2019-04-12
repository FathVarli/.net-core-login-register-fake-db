using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class UserDto
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userEmail { get; set; }
        public string userPass { get; set; }
    }
}
