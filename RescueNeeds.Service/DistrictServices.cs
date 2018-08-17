using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RescueNeeds.Service
{
    public class DistrictServices
    {
        public IEnumerable<District> GetDistricts()
        {
            IEnumerable<District> result = null;
            using (var entity = new RescueNeedsEntities())
            {
                result=entity.Districts.ToList();
            }
            return result;
        }

    }
}
