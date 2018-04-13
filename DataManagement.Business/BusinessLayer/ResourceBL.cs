using DataManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Business.BusinessLayer
{
    public class ResourceBL
    {
        public static List<Resource> GetResource(DataManagementModelDataContext db, int resourceID = 0)
        {
            var ret = new List<Resource>();
            try
            {
                if (resourceID == 0)
                {
                    ret = db.Resources.OrderBy(o => o.ResourceID).ToList();
                }
                else
                {
                    ret = db.Resources.Where(m => m.ResourceID == resourceID).OrderBy(o => o.ResourceID).ToList();
                }

            }
            catch (Exception ex)
            {

            }
            return ret;
        }
    }
}
