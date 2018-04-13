using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataManagement.Modules.Report.Page
{
    [PageAuthorize("manager")]
    [RoutePrefix("Report/RoomReport"), Route("{action=index}")]
    public class RoomReportController : Controller
    {
        // GET: RoomReport
        public ActionResult Index()
        {
            return View(MVC.Views.DataManagement.RoomReportPage);
        }
    }
}