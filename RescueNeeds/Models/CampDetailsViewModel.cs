using RescueNeeds.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RescueNeeds.Models
{
    public class CampDetailsViewModel
    {
        public List<CampRequirement> CampsDetails { get; set; }
        public CampInCharge CampInCharge { get; set; }
    }
}
