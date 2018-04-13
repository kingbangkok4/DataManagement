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

namespace DataManagement.Modules.Report.Page
{
    [PageAuthorize("manager")]
    [RoutePrefix("Reports/RoomReport"), Route("{action=index}")]
    public class RoomReportController : Controller
    {
        // GET: RoomReport
        public ActionResult Index()
        {
            var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();
            var model = new List<ReservationModel>();

            var ret = ReservationBL.GetReservation(db, "", true);
            foreach (var item in ret)
            {
                var tmp = new ReservationModel
                {
                    ReservationID = item.ReservationID,
                    RoomID = item.RoomID,
                    PersonalID = item.PersonalID,
                    ReservationDate = item.ReservationDate,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    PersonalName = item.Personal.PersonalName,
                    Posision = item.Personal.Position,
                    RoomDetail = item.Room.RoomDetail,
                    Count = 1
                };
                model.Add(tmp);
            }
            return View(MVC.Views.DataManagement.RoomReportPage, model);
        }

    }
}