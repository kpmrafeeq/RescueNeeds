//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RescueNeeds.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class CampInCharge
    {
        public int CampsID { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public Nullable<int> PlaceID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<int> PersonID { get; set; }
    
        public virtual District District { get; set; }
        public virtual Person Person { get; set; }
        public virtual Place Place { get; set; }
    }
}