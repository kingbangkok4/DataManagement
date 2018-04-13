using DataManagement.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement.Business.BusinessLayer
{
    public class BorrowBL
    {
        public static bool SaveBorrow(DataManagementModelDataContext db, int resourceID, int num, string user, ref string errMsg)
        {
            errMsg = "";
            var ret = false;
            try
            {
                var saveBorrow = new Borrow();
                var dtNow = CommonBL.GetDateTimeNow(db);
                var ckResource = db.Resources.Where(m => m.ResourceID == resourceID).FirstOrDefault();
                if (ckResource.NumResource >= num)
                {
                    ckResource.NumResource = ckResource.NumResource - num;
                    saveBorrow.ResourceID = resourceID;
                    saveBorrow.PersonalID = user;
                    saveBorrow.BorrowDT = dtNow;
                    saveBorrow.Numborrow = num;

                    db.Borrows.InsertOnSubmit(saveBorrow);
                    db.SubmitChanges();

                    ret = true;
                }
                else
                {
                    errMsg = "จำนวนอุปกรณ์ไม่เพียงพอต่อการยืม !!";
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return ret;
        }

        public static bool ReturnResource(DataManagementModelDataContext db, int borrowID, string user, ref string errMsg)
        {
            errMsg = "";
            var ret = false;
            try
            {
                var dtNow = CommonBL.GetDateTimeNow(db);
                var ckBorrow = db.Borrows.Where(m => m.BorrowID == borrowID).FirstOrDefault();
               
                if (ckBorrow != null)
                {
                    var ckResource = db.Resources.Where(m => m.ResourceID == ckBorrow.ResourceID).FirstOrDefault();
                    ckResource.NumResource = ckResource.NumResource + ckBorrow.Numborrow;

                    ckBorrow.StaffID = user;
                    ckBorrow.ReturnDT = dtNow;

                    db.SubmitChanges();

                    ret = true;
                }
                else
                {
                    errMsg = "ไม่พบรายการอุปกรณ์ที่ยืมไป !!";
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return ret;
        }

        public static List<Borrow> GetBorrow(DataManagementModelDataContext db, long borrowID = 0, bool all = false)
        {
            var ret = new List<Borrow>();
            try
            {
                //var dtNow = CommonBL.GetDateTimeNow(db);
                if (all)
                {
                    if (borrowID == 0)
                    {
                        ret = db.Borrows.OrderBy(o => o.BorrowDT).ToList();
                    }
                    else
                    {
                        ret = db.Borrows.Where(m => m.BorrowID == borrowID).OrderBy(o => o.BorrowDT).ToList();
                    }
                }
                else
                {
                    if(borrowID == 0)
                    {
                        ret = db.Borrows.Where(m => m.StaffID == null && m.ReturnDT == null).OrderBy(o => o.BorrowDT).ToList();
                    }
                    else
                    {
                        ret = db.Borrows.Where(m => m.BorrowID == borrowID && m.StaffID == null && m.ReturnDT == null).OrderBy(o => o.BorrowDT).ToList();
                    }
                }

            }
            catch (Exception)
            {

            }
            return ret;
        }

    }
}
