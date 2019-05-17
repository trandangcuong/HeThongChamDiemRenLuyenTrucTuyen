using QuanLyDiemRenLuyen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDiemRenLuyen.Controllers
{
    public class QuanLySinhVienController : Controller
    {
        // GET: QuanLySinhVien



        QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewALL()
        {
            return View(GetAllSinhVien());
        }
        IEnumerable<SINHVIEN> GetAllSinhVien()
        {
            using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
            {
                return db.SINHVIENs.ToList<SINHVIEN>();
            }
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            SINHVIEN sk = new SINHVIEN();
            if (id != 0)
            {
                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {
                    sk = db.SINHVIENs.Where(x => x.ID == id).FirstOrDefault<SINHVIEN>();
                }
            }
            return View(sk);
        }
        [HttpPost]
        public ActionResult AddOrEdit(SINHVIEN sk)
        {
            try
            {

                using (QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities())
                {
                    if (sk.ID == 0)
                    {
                        db.SINHVIENs.Add(sk);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(sk).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllSinhVien()), message = "Gửi Thành Công" }, JsonRequestBehavior.AllowGet);
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
                    SINHVIEN sk = db.SINHVIENs.Where(x => x.ID == id).FirstOrDefault<SINHVIEN>();
                    db.SINHVIENs.Remove(sk);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllSinhVien()), message = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Import()
        {
            return View();
        }

    }
}
