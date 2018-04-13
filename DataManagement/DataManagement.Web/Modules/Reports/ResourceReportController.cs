using DataManagement.Business.BusinessLayer;
using DataManagement.Business.Models;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataManagement.Modules.Report.Page
{
    [PageAuthorize("manager")]
    [RoutePrefix("Reports/ResourceReport"), Route("{action=index}")]
    public class ResourceReportController : Controller
    {
        // GET: ResourceReport
        public ActionResult Index()
        {
            var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();
            var model = new List<BorrowModel>();

            var ret = BorrowBL.GetBorrow(db, 0, true);
            foreach (var item in ret)
            {
                var tmp = new BorrowModel
                {
                    BorrowID = item.BorrowID,
                    ResourceID = item.ResourceID,
                    ResourceName = item.Resource.ResourceName,
                    ResourceDetail = item.Resource.ResourceDetail,
                    PersonalID = item.PersonalID,
                    PersonalName = item.Personal.PersonalName,
                    BorrowDT = item.BorrowDT,
                    StaffID = item.StaffID,
                    ReturnDT = item.ReturnDT,
                    Numborrow = item.Numborrow
                };
                model.Add(tmp);
            }

            return View(MVC.Views.DataManagement.ResourceReportPage, model);
        }
    }
}