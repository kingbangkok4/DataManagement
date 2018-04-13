using DataManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Business.BusinessLayer
{
    public class CommonBL
    {
        public static DateTime GetDateTimeNow(DataManagementModelDataContext db) {
            var ret = new DateTime();
            try
            {
                ret =  db.ExecuteQuery<DateTime>("SELECT GETDATE()").FirstOrDefault();
            }
            catch (Exception)
            {

            }
            return ret;
        }
    }
}
