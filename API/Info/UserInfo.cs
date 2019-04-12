using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Info
{
    public class UserInfo
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }
        public string userEmail { get; set; }
        public string userPass { get; set; }
        public string token { get; set; }
    }
}
