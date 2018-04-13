using DataManagement.Business.BusinessLayer;
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
    [PageAuthorize("staff")]
    [RoutePrefix("Resource/ReturnResource"), Route("{action=index}")]
    public class ReturnResourceController : Controller
    {
        // GET: ReturnResourcec
        public ActionResult Index()
        {
            return View(MVC.Views.DataManagement.ReturnResourcecPage);
        }

        public ActionResult GetBorrow([DataSourceRequest]DataSourceRequest request)
        {
            var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();

            var ret = BorrowBL.GetBorrow(db);

            if (ret != null && ret.Count() > 0)
            {
                DataSourceResult data = ret.ToDataSourceResult(request, m => new DataManagement.Business.Models.Borrow
                {
                    BorrowID = m.BorrowID,
                    ResourceID = m.ResourceID,
                    PersonalID = m.PersonalID,
                    BorrowDT = m.BorrowDT,
                    StaffID = m.StaffID,
                    ReturnDT = m.ReturnDT,
                    Numborrow = m.Numborrow
                });
                return Json(data);
            }
            // return Json(new { result = data }, JsonRequestBehavior.AllowGet);
            return null;
        }

        [HttpPost]
        public ActionResult SaveReturnResource(string borrowID)
        {
            try
            {
                string errMsg = "";
                var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();
                var ret = BorrowBL.ReturnResource(db, int.Parse(borrowID), @Serenity.Authorization.Username, ref errMsg);
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