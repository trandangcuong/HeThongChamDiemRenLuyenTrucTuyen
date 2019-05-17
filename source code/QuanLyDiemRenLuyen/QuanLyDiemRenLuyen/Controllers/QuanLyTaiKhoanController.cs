using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDiemRenLuyen.Models;

namespace QuanLyDiemRenLuyen.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities();
        #region ***** Dang nhap
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f.Get("mssv").ToString();
            string sMatKhau = f.Get("password").ToString();

            if (ModelState.IsValid)
            {
                TAIKHOAN tk = db.TAIKHOANs.SingleOrDefault(n => n.Username == sTaiKhoan);

                if (tk == null)
                {
                    ViewBag.ThongBao = ("Tài khoản không tồn tại");
                    return View();
                }
                else
                {
                    if (tk.Password == sMatKhau)
                    {
                        if (tk.IDQuyen == 3 || tk.IDQuyen ==4)
                        {
                            Session["TaiKhoan"] = tk;
                           
                            Session["masv"] = tk.Username;
                           Session["QuyenId"] = tk.IDQuyen;

                            var ten = (from sv in db.SINHVIENs
                                       join tk1 in db.TAIKHOANs on sv.PK_sMaSVID equals tk1.Username

                                       where sv.PK_sMaSVID == tk.Username
                                       select new Dangnhap {
                                           Ten = sv.sTenSV,
                                           lop = sv.FK_sMaLopID



                                       }).ToArray();

                            Session["TenNguoiDung"] = ten.ToArray()[0].Ten.ToString();
                            Session["Lop"] = ten.ToArray()[0].lop.ToString();
                            return RedirectToAction("Index", "Home");
                        }
                        else if(tk.IDQuyen==2)
                        {
                            Session["TaiKhoan"] = tk;

                            Session["masv"] = tk.Username;
                            Session["QuyenId"] = tk.IDQuyen;
                            var tenGV = (from gv in db.GIAOVIENs
                                         join tk2 in db.TAIKHOANs on gv.PK_sMaGVID equals tk2.Username
                                         where gv.PK_sMaGVID == tk.Username
                                         select new Dangnhap
                                         {
                                             Ten = gv.sTenGV,
                                             lop = gv.FK_sMaLopID



                                         }).ToArray();


                            Session["TenNguoiDung"] = tenGV.ToArray()[0].Ten.ToString();
                            Session["Lop"] = tenGV.ToArray()[0].lop.ToString();

                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            Session["TaiKhoan"] = tk;

                            Session["TenNguoiDung"] = tk.Username;
                            Session["QuyenId"] = tk.IDQuyen;

                            Session["AccountId"] = tk.Username;

                            return RedirectToAction("Index", "QuanLy");
                        }
                        

                    }

                    else
                    {
                        ViewBag.ThongBao = ("Đăng nhập thất bại!");
                        return View();
                    }


                }
            }
            return View();

        }
        #endregion ***** Dang nhap
        public ActionResult DangXuat()
        {
            if (Session["TaiKhoan"] != null)
            {
                if (Convert.ToInt32(Session["QuyenId"]) == 1)
                {
                    Session["TaiKhoan"] = null;
                    return RedirectToAction("DangNhap");
                }
                else
                {
                    Session["TaiKhoan"] = null;
                    return RedirectToAction("DangNhap");
                }


            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }

}