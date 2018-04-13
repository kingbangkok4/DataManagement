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

         public ActionResult GetReservation([DataSourceRequest]DataSourceRequest request, string roomID = "")
        {
            var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();

            var ret = ReservationBL.GetReservation(db, "", true);

            if (ret != null && ret.Count() > 0)
            {
                DataSourceResult data = ret.ToDataSourceResult(request, m => new DataManagement.Business.Models.Reservation
                {
                    ReservationID = m.ReservationID,
                    RoomID = m.RoomID,
                    PersonalID = m.PersonalID,
                    ReservationDate = m.ReservationDate,
                    StartTime = m.StartTime,
                    EndTime = m.EndTime
                });
                return Json(data);
            }
            // return Json(new { result = data }, JsonRequestBehavior.AllowGet);
            return null;
        }

    }
}