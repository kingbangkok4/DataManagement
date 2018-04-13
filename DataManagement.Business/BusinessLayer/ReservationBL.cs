using DataManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Business.BusinessLayer
{
    public class ReservationBL
    {
        public static List<Reservation> GetReservation(DataManagementModelDataContext db, string roomID = "", bool all = false)
        {
            var ret = new List<Reservation>();
            try
            {
                var dtNow = CommonBL.GetDateTimeNow(db);
                if (all)
                {
                    if (roomID == "")
                    {
                        ret = db.Reservations.OrderByDescending(o=>o.ReservationDate).ToList();
                    }
                    else {
                        ret = db.Reservations.Where(m => m.RoomID == roomID).OrderByDescending(o => o.ReservationDate).ToList();
                    }
                }
                else {
                    if (roomID == "")
                    {
                        ret = db.Reservations.Where(m=>m.ReservationDate.Value.Date >= dtNow.Date).OrderByDescending(o => o.ReservationDate).ToList();
                    }
                    else
                    {
                        ret = db.Reservations.Where(m => m.RoomID == roomID && m.ReservationDate.Value.Date >= dtNow.Date).OrderByDescending(o => o.ReservationDate).ToList();
                    }
                }
               
            }
            catch (Exception)
            {

            }
            return ret;
        }
        public static bool SaveReservation(DataManagementModelDataContext db, Reservation data)
        {
            var ret = false;
            try
            {
                //var dtNow = CommonBL.GetDateTimeNow(db);
                var chkRoom = db.Reservations.Where(m => m.ReservationDate.Value.Date == data.ReservationDate.Value.Date).ToList();
                if (chkRoom.Count() > 0)
                {
                    chkRoom = chkRoom.Where(m => (m.StartTime.Value >= data.StartTime.Value && m.StartTime.Value <= data.EndTime.Value)
                    || (m.StartTime.Value <= data.StartTime.Value && m.EndTime.Value >= data.StartTime.Value)).ToList();
                }
                if (chkRoom.Count() == 0)
                {
                    db.Reservations.InsertOnSubmit(data);
                    db.SubmitChanges();
                    ret = true;
                }
            }
            catch (Exception ex)
            {

            }
            return ret;
        }
    }
}
