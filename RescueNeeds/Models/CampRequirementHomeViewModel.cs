using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RescueNeeds.Models
{
    public class CampRequirementHomeViewModel
    {
        public IEnumerable<RescueNeeds.Service.Camp> Data { get; set; }
        public IEnumerable<RescueNeeds.Service.Place> Places { get; set; }
        public IEnumerable<RescueNeeds.Service.District> District { get; set; }
        public int PlaceId{ get; set; }

    }
}