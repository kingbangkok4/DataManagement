using DataManagement.Business.BusinessLayer;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Serenity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataManagement.Business.Models;

namespace DataManagement.Modules.Room.Page
{
    [PageAuthorize("user")]
    [RoutePrefix("Room/Room"), Route("{action=index}")]
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            return View(MVC.Views.DataManagement.RoomPage);
        }

        public ActionResult GetRoom([DataSourceRequest]DataSourceRequest request)
        {
            var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();

            var ret = RoomBL.GetRoom(db);

            if (ret != null && ret.Count() > 0)
            {
                DataSourceResult data = ret.ToDataSourceResult(request, m => new DataManagement.Business.Models.Room
                {
                    RoomID = m.RoomID,
                    RoomPic = m.RoomPic,
                    RoomDetail = m.RoomDetail
                });
                return Json(data);
            }
            // return Json(new { result = data }, JsonRequestBehavior.AllowGet);
            return null;
        }

        public ActionResult GetReservation([DataSourceRequest]DataSourceRequest request, string roomID = "")
        {
            var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();

            var ret = ReservationBL.GetReservation(db, roomID);

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

        [HttpPost]
        public ActionResult SaveResevation(string roomID, DateTime? rDate, DateTime? sTime, DateTime? eTime)
        {
            try
            {
                var data = new Reservation();
                data.RoomID = roomID.Trim();
                data.PersonalID = @Serenity.Authorization.Username;
                data.ReservationDate = rDate;
                data.StartTime = sTime.Value.TimeOfDay;
                data.EndTime = eTime.Value.TimeOfDay;

                var db = DataManagement.Modules.Common.CommonClass.GetMathematicsDataContext();
                var ret = ReservationBL.SaveReservation(db, data);
                if (ret)
                {
                    return Json(new { ret = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { ret = "ไม่สามารถจองห้องสอนได้ !!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { ret = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}


