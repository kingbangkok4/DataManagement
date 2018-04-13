using DataManagement.Business.BusinessLayer;
using DataManagement.Business.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataManagement.Modules.Resource.Page
{
    [PageAuthorize("user")]
    [RoutePrefix("Resource/Resource"), Route("{action=index}")]
    public class ResourceController : Controller
    {
        // GET: Resource
        public ActionResult Index()
        {
            return View(MVC.Views.DataManagement.ResourcePage);
        }
        public ActionResult GeResource([DataSourceRequest]DataSourceRequest request)
        {
            var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();

            var ret = ResourceBL.GetResource(db);

            if (ret != null && ret.Count() > 0)
            {
                DataSourceResult data = ret.ToDataSourceResult(request, m => new DataManagement.Business.Models.Resource
                {
                    ResourceID = m.ResourceID,
                    ResourcePic = m.ResourcePic,
                    ResourceName = m.ResourceName,
                    ResourceDetail = m.ResourceDetail,
                    NumResource = m.NumResource
                });
                return Json(data);
            }
            // return Json(new { result = data }, JsonRequestBehavior.AllowGet);
            return null;
        }

        [HttpPost]
        public ActionResult SaveBorrow(string resourceID, string num)
        {
            try
            {
                string errMsg = "";
                var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();
                var ret = BorrowBL.SaveBorrow(db, int.Parse(resourceID), int.Parse(num), @Serenity.Authorization.Username, ref errMsg);
                if (ret)
                {
                    return Json(new { ret = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { ret = errMsg }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { ret = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}