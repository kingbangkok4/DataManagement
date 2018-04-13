using DataManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DataManagement.Modules.Common
{
    public class CommonClass
    {
        public enum eConnectionName
        {
            Default,
            Mathematics_DB
        }
        public static string GetConnectionString(eConnectionName connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName.ToString()].ConnectionString;
        }
        public static DataManagementModelDataContext GetMathematicsDataContext()
        {
            String conString = CommonClass.GetConnectionString(CommonClass.eConnectionName.Mathematics_DB);
            DataManagementModelDataContext db = new DataManagementModelDataContext(conString);
            return db;
        }
    }
}