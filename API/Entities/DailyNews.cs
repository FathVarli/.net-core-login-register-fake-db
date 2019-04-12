using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class DailyNews
    {
        [Key]
        public int dailyID { get; set; }
        public string mainSubject { get; set; }
        public string body { get; set; }
        public string contentImage { get; set; }
        public int userID { get; set; }
        public string userName { get; set; }
        public string userSurname { get; set; }

    }
}
