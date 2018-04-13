using DataManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Business.BusinessLayer
{
    public class RoomBL
    {
        public static List<Room> GetRoom(DataManagementModelDataContext db, string roomID = "") {
            var ret = new List<Room>();
            try
            {
                if (roomID.Trim() == "") {
                    ret = db.Rooms.OrderBy(o=>o.RoomID).ToList();
                }
                else {
                    ret = db.Rooms.Where(m => m.RoomID == roomID.Trim()).OrderBy(o => o.RoomID).ToList();
                }
                
            }
            catch (Exception ex)
            {

            }
            return ret;
        }
    }
}
