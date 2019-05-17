using QuanLyDiemRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace QuanLyDiemRenLuyen.Controllers
{
    public class QuanLyDiemDanhGiaRenLuyenController : Controller
    {
        QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewALL()
        {
            return View(GetAllSuKien());
        }
        IEnumerable<DANHGIARENLUYEN> GetAllSuKien()
        {
            using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
            {
                return db.DANHGIARENLUYENs.ToList<DANHGIARENLUYEN>();
            }
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            DANHGIARENLUYEN sk = new DANHGIARENLUYEN();
            if (id != 0)
            {
                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {
                    sk = db.DANHGIARENLUYENs.Where(x => x.ID == id).FirstOrDefault<DANHGIARENLUYEN>();
                }
            }
            return View(sk);
        }
        [HttpPost]
        public ActionResult AddOrEdit(DANHGIARENLUYEN sk )
        {
            try
            {
                
                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {
                    if (sk.ID == 0)
                    {
                        db.DANHGIARENLUYENs.Add(sk);
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
                    DANHGIARENLUYEN sk = db.DANHGIARENLUYENs.Where(x => x.ID == id).FirstOrDefault<DANHGIARENLUYEN>();
                    db.DANHGIARENLUYENs.Remove(sk);
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