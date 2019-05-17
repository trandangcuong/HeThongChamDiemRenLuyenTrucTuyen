using QuanLyDiemRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDiemRenLuyen.Controllers
{
    public class QuanLySuKienController : Controller
    {
        // GET: QuanLySuKien
        QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewALL()
        {
            return View(GetAllSuKien());
        }
        IEnumerable<SUKIEN> GetAllSuKien()
        {
            using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
            {
                return db.SUKIENs.ToList<SUKIEN>();
            }
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            SUKIEN sk = new SUKIEN();
            if (id != 0)
            {
                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {
                    sk = db.SUKIENs.Where(x => x.ID == id).FirstOrDefault<SUKIEN>();
                }
            }
            return View(sk);
        }
        [HttpPost]
        public ActionResult AddOrEdit( SUKIEN sk )
        {
            try
            {
                
                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {
                    if (sk.ID == 0)
                    {
                        db.SUKIENs.Add(sk);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(sk).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllSuKien()), message = "Gửi Thành Công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {
                    SUKIEN sk = db.SUKIENs.Where(x => x.ID == id).FirstOrDefault<SUKIEN>();
                    db.SUKIENs.Remove(sk);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllSuKien()), message = "Xóa Thành Công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}