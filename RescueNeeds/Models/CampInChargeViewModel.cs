using RescueNeeds.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RescueNeeds.Models
{
    public class CampInChargeViewModel
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int CampInChargeID { get; set; }
        public Nullable<int> CampsID { get; set; }
        
    }
}