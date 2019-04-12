using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userEmail { get; set; }
        public bool isEnabled { get; set; }
        public byte[] passHash { get; set; }
        public byte[] passSalt { get; set; }
        public string token { get; set; }
    }
}
