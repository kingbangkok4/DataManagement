using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataManagement.Modules.Report.Page
{
    [PageAuthorize("manager")]
    [RoutePrefix("Report/ResourceReport"), Route("{action=index}")]
    public class ResourceReportController : Controller
    {
        // GET: ResourceReport
        public ActionResult Index()
        {
            return View(MVC.Views.DataManagement.ResourceReportPage);
        }
    }
}