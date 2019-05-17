using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDiemRenLuyen.Models;
using QuanLyDiemRenLuyen.Controllers;
using System.Data.Entity.Core.Objects;

namespace QuanLyDiemRenLuyen.Controllers
{
    public class QuanLyDiemRenLuyenController : Controller
    {
        QuanLyDiemRenLuyenEntities db = new QuanLyDiemRenLuyenEntities();
        //sinh viên xem điểm Rèn Luyện 
        // GET: QuanLyDiemRenLuyen
        [HttpGet]
        public ActionResult DanhSachXemDiem()
        {
            string a = Session["Lop"].ToString();

            if (Session["masv"] != null)
            {



                List<sd_sinhviendanhgia_Result> obj = new List<sd_sinhviendanhgia_Result>();
                var lstPQND = db.sd_sinhviendanhgia(a).ToList();
                obj = lstPQND;


                return View(obj.ToList());
            }

            return RedirectToAction("DangNhap", "TaiKhoan");

        }
        [HttpGet]
        public ActionResult XemDiemRenLuyen(String MSV)
        {
            string a = MSV;
          //  string a = Session["masv"].ToString();
            List<sp_xemdiemrenluyen2_Result> dbo = new List<sp_xemdiemrenluyen2_Result>();
            dbo = db.sp_xemdiemrenluyen2(a, 1).ToList().Count>0? db.sp_xemdiemrenluyen2(a, 1).ToList():null;
            ViewBag.SV_SV = dbo;
            //dbo!=null? db.sp_xemdiemrenluyen1(a, 1).ToList()[0]:null;

            List<sp_xemdiemrenluyen2_Result> dbolt = new List<sp_xemdiemrenluyen2_Result>();
            dbolt = db.sp_xemdiemrenluyen2(a, 2).ToList().Count > 0 ? db.sp_xemdiemrenluyen2(a, 2).ToList() : null;
            ViewBag.SV_LT = dbolt;

            List<sp_xemdiemrenluyen2_Result> dbogv = new List<sp_xemdiemrenluyen2_Result>();
            dbogv = db.sp_xemdiemrenluyen2(a, 3).ToList().Count > 0 ? db.sp_xemdiemrenluyen2(a, 3).ToList() : null;
            ViewBag.SV_GV = dbogv;




            return View();
        }
        [HttpGet]
        public ActionResult DanhGiaDiemRenLuyen()
        {
          
            string a = Session["masv"].ToString();

            List<dk_locsinhviendanhgia_Result> dk = new List<dk_locsinhviendanhgia_Result>();
            var dkloc = db.dk_locsinhviendanhgia(a).ToList();
            dk = dkloc;
            if(dk.Count == 0)
            {
                List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
                var lstPQND = db.sp_laydiemsukien(a).ToList();
                obj = lstPQND;

                int? ThamGiaHD = obj[0].TONGDIEM;
                ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;
                ViewBag.ThamGiaHD = ThamGiaHD;




                return View();

            }
          else
            {


          
                Session["ThongBao"] = "Bạn đã đánh giá rèn luyện không thể  đánh giá nữa.";
                return RedirectToAction("Index", "Home" );


            }



           
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult DanhGiaDiemRenLuyen(IEnumerable<HttpPostedFileBase> files, FormCollection f)
        {

            string a = Session["masv"].ToString();
            //tieu chi 1
            //dihocdaydult
            var parDiHocDayDu = f["DiHocDayDu"];
            int DiHocDayDu = parDiHocDayDu != null ? int.Parse(f["DiHocDayDu"].ToString()) : 0;
            //kqhoctaplt
            var parKQHocTap = f["KQHocTap"];
            int KQHocTap = parKQHocTap != null ? int.Parse(f["KQHocTap"].ToString()) : 0;
            //cogangvuotkho
            var parCoGangVuotKho = f["CoGangVuotKho"];
            int CoGangVuotKho = parCoGangVuotKho != null ? int.Parse(f["CoGangVuotKho"].ToString()) : 0;
            //nckhlt
            var parNCKH = f["NCKH"];
            int NCKH = parNCKH != null ? int.Parse(f["NCKH"].ToString()) : 0;
            //tinhoclt
            var parTinHoc = f["TinHoc"];
            int TinHoc = parTinHoc != null ? int.Parse(f["TinHoc"].ToString()) : 0;
            //ngoaingult
            var parNgoaiNgu = f["NgoaiNgu"];
            int NgoaiNgu = parNgoaiNgu != null ? int.Parse(f["NgoaiNgu"].ToString()) : 0;

            int? TongTieuChi1 = DiHocDayDu + KQHocTap + CoGangVuotKho + NCKH + TinHoc + NgoaiNgu;

            TongTieuChi1 = TongTieuChi1 <= 20 ? TongTieuChi1 : 20;

            //tieu chi 2
            //khongviphammlt
            var parKhongViPham = f["KhongViPham"];
            int KhongViPham = parKhongViPham != null ? int.Parse(f["KhongViPham"].ToString()) : 0;
            //GiuGinAnNinhlt
            var parGiuGinAnNinh = f["GiuGinAnNinh"];
            int GiuGinAnNinh = parGiuGinAnNinh != null ? int.Parse(f["GiuGinAnNinh"].ToString()) : 0;
            //GiuVeSinhlt
            var parGiuVeSinh = f["GiuVeSinh"];
            int GiuVeSinh = parGiuVeSinh != null ? int.Parse(f["GiuVeSinh"].ToString()) : 0;

            int? TongTieuChi2 = KhongViPham + GiuGinAnNinh + GiuVeSinh;

            TongTieuChi2 = TongTieuChi2 <= 25 ? TongTieuChi2 : 25;
            List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
            var lstPQND = db.sp_laydiemsukien(a).ToList();
            obj = lstPQND;

            int? ThamGiaHD = obj[0].TONGDIEM;
            ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;

            //llcapbomon
            var parLLCapboMon = f["LLCapboMon"];
            int LLCapboMon = parLLCapboMon != null ? int.Parse(f["LLCapboMon"].ToString()) : 0;
            //llcapkhoa
            var parLLCapKhoa = f["LLCapKhoa"];
            int LLCapKhoa = parLLCapKhoa != null ? int.Parse(f["LLCapKhoa"].ToString()) : 0;
            //ktdoankhoa
            var parKTDoanKhoa = f["KTDoanKhoa"];
            int KTDoanKhoa = parKTDoanKhoa != null ? int.Parse(f["KTDoanKhoa"].ToString()) : 0;
            //ktcaptruong
            var parKTCapTruong = f["KTCapTruong"];
            int KTCapTruong = parKTCapTruong != null ? int.Parse(f["KTCapTruong"].ToString()) : 0;
            //ktcapcaohon
            var parKTCapCaoHon = f["KTCapCaoHon"];
            int KTCapCaoHon = parKTCapCaoHon != null ? int.Parse(f["KTCapCaoHon"].ToString()) : 0;


            int? TongTieuChi3 = ThamGiaHD + LLCapboMon + LLCapKhoa + KTDoanKhoa + KTCapTruong + KTCapCaoHon;

            TongTieuChi3 = TongTieuChi3 <= 20 ? TongTieuChi3 : 20;


            // tieu chhi 4
            //kovpplnn
            var parKhongViPhamPLNN = f["KhongViPhamPLNN"];
            int KhongViPhamPLNN = parKhongViPhamPLNN != null ? int.Parse(f["KhongViPhamPLNN"].ToString()) : 0;
            //cotinhthangiupdo
            var parCoTinhThanGiupDo = f["CoTinhThanGiupDo"];
            int CoTinhThanGiupDo = parCoTinhThanGiupDo != null ? int.Parse(f["CoTinhThanGiupDo"].ToString()) : 0;
            //thamgiadoi
            var parThamGiaDoi = f["ThamGiaDoi"];
            int ThamGiaDoi = parThamGiaDoi != null ? int.Parse(f["ThamGiaDoi"].ToString()) : 0;

            int? TongTieuChi4 = KhongViPhamPLNN + CoTinhThanGiupDo + ThamGiaDoi;

            TongTieuChi4 = TongTieuChi4 <= 25 ? TongTieuChi4 : 25;
            // tieu chi 5
            //loptruong
            var parLopTruong = f["LopTruong"];
            int LopTruong = parLopTruong != null ? int.Parse(f["LopTruong"].ToString()) : 0;
            //cansulop
            var parCanSuLop = f["CanSuLop"];
            int CanSuLop = parCanSuLop != null ? int.Parse(f["CanSuLop"].ToString()) : 0;

            //cacthanhtichdacbiet
            var parCacThanhTichDacBiet = f["CacThanhTichDacBiet"];
            int CacThanhTichDacBiet = parCacThanhTichDacBiet != null ? int.Parse(f["CacThanhTichDacBiet"].ToString()) : 0;

            int? TongTieuChi5 = LopTruong + CanSuLop + CacThanhTichDacBiet;

            TongTieuChi5 = TongTieuChi5 <= 10 ? TongTieuChi5 : 10;

            int? Tong = TongTieuChi1 + TongTieuChi2 + TongTieuChi3 + TongTieuChi4 + TongTieuChi5;

            string xuatsac = "Xuất sắc";
            string tot = "Tốt";
            string kha = "Khá";
            string Tb = "Trung bình";
            string yeu = "Yếu";
            string kem = "Kém";
            string sxeploai = "";
            if (Tong > 90)
            {
                sxeploai = xuatsac;
            }
            else if (Tong >= 80)
            {
                sxeploai = tot;
            }
            else if (Tong >= 65)
            {
                sxeploai = kha;
            }
            else if (Tong >= 50)
            {
                sxeploai = Tb;
            }
            else if (Tong >= 35)
            {
                sxeploai = yeu;
            }
            else if (Tong < 35)
            {
                sxeploai = kem;
            }

            var model = db.DANHGIARENLUYENs;
            ObjectParameter returnId = new ObjectParameter("id", typeof(int)); //Create Object parameter to receive a output value.It will behave like output parameter  
            db.ds_themdanhgiadiemrenluyen1(a, DiHocDayDu, KQHocTap, CoGangVuotKho, NCKH, TinHoc, NgoaiNgu, TongTieuChi1, KhongViPham, GiuGinAnNinh, GiuVeSinh, TongTieuChi2, ThamGiaHD, LLCapboMon, LLCapKhoa, KTDoanKhoa, KTCapTruong, KTCapCaoHon, TongTieuChi3, KhongViPhamPLNN, CoTinhThanGiupDo, ThamGiaDoi, TongTieuChi4, LopTruong, CanSuLop, CacThanhTichDacBiet, TongTieuChi5, Tong, sxeploai, returnId);
           
            return RedirectToAction("DanhGiaThanhCong", new {ID = returnId.Value});

        }
        [HttpGet]
        public ActionResult DanhGiaThanhCong(int? ID)
        {
            var data = db.DANHGIARENLUYENs.SingleOrDefault(n => n.ID == ID);
            string a = Session["masv"].ToString();
            List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
            var lstPQND = db.sp_laydiemsukien(a).ToList();
            obj = lstPQND;

            int? ThamGiaHD = obj[0].TONGDIEM;
            ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;
            ViewBag.ThamGiaHD = ThamGiaHD;

            if (data.iTongdiem != null)
            {
                int? Tong = data.iTongdiem;
                ViewBag.Tong = Tong;
            }


            return View(data);
        }
        public ActionResult DanhSachHoatThamGiaHDPartial()
        {



            if (Session["masv"] != null)
            {

                string a = Session["masv"].ToString();

               
                List<sp_DanhSachSuKien_Result> obj = new List<sp_DanhSachSuKien_Result>();
                var lstPQND = db.sp_DanhSachSuKien(a).ToList();
                obj = lstPQND;
                

               


                return PartialView("_DanhSachHoatThamGiaHDPartial", obj.ToList());
            }

            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        //sinh vien đánh giá điểm rèn luyện 
        // lop truong cham diem sinh vien

        [HttpGet]
        public ActionResult LTDanhGiaDiemRenLuyenSV()
        {
            string a = Session["Lop"].ToString();

            if (Session["masv"] != null)
            {



                List<sd_sinhviendanhgia_Result> obj = new List<sd_sinhviendanhgia_Result>();
            var lstPQND = db.sd_sinhviendanhgia(a).ToList();
            obj = lstPQND;


                return View(obj.ToList());
            }

            return RedirectToAction("DangNhap", "TaiKhoan");

        }
        public ActionResult ChiTietSVDDG(int ID)
        {
            DANHGIARENLUYEN danhgiarenluyen = db.DANHGIARENLUYENs.SingleOrDefault(m => m.ID == ID);
            string masv = danhgiarenluyen.FK_sMaSVID;
            List<dk_locsinhviendanhgialt_Result> dk = new List<dk_locsinhviendanhgialt_Result>();
            var dkloc = db.dk_locsinhviendanhgialt(masv).ToList();
            dk = dkloc;
            if (dk.Count == 0)
            {

              


                int? Tong = danhgiarenluyen.iTongdiem;
                ViewBag.Tong = Tong;
                ViewBag.IDCT = ID;
                if (danhgiarenluyen == null)
                {
                    Response.StatusCode = 404;
                    return null;

                }
                return View(danhgiarenluyen);
            }
            else
            {
                return RedirectToAction("LTDanhGiaDiemRenLuyenSV", "QuanLyDiemRenLuyen");

            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ChiTietSVDDG(IEnumerable<HttpPostedFileBase> files, FormCollection f, int ID)
        {

            DANHGIARENLUYEN dg = db.DANHGIARENLUYENs.SingleOrDefault(m => m.ID == ID);
            int IDSV = dg.ID;

            string masv = dg.FK_sMaSVID;
            //tieu chi 1
            //dihocdaydult
                var parDiHocDayDu = f["DiHocDayDuLT"];
                int DiHocDayDu = parDiHocDayDu != null ? int.Parse(f["DiHocDayDuLT"].ToString()) : 0;
                //kqhoctaplt
                var parKQHocTap = f["KQHocTapLT"];
                int KQHocTap = parKQHocTap != null ? int.Parse(f["KQHocTapLT"].ToString()) : 0;
                //cogangvuotkho
                var parCoGangVuotKho= f["CoGangVuotKhoLT"];
                int CoGangVuotKho = parCoGangVuotKho != null ? int.Parse(f["CoGangVuotKhoLT"].ToString()) : 0;
                //nckhlt
                var parNCKH = f["NCKHLT"];
                int NCKH = parNCKH != null ? int.Parse(f["NCKHLT"].ToString()) : 0;
                //tinhoclt
                var parTinHoc = f["TinHocLT"];
                int TinHoc = parTinHoc != null ? int.Parse(f["TinHocLT"].ToString()) : 0;
                //ngoaingult
                var parNgoaiNgu = f["NgoaiNguLT"];
                int NgoaiNgu = parNgoaiNgu != null ? int.Parse(f["NgoaiNguLT"].ToString()) : 0;
           
                int? TongTieuChi1 = DiHocDayDu + KQHocTap + CoGangVuotKho + NCKH + TinHoc + NgoaiNgu;

                TongTieuChi1 = TongTieuChi1 <= 20 ? TongTieuChi1 : 20;

                //tieu chi 2
                //khongviphammlt
                var parKhongViPham = f["KhongViPhamLT"];
                int KhongViPham = parKhongViPham != null ? int.Parse(f["KhongViPhamLT"].ToString()) : 0;
                //GiuGinAnNinhlt
                var parGiuGinAnNinh = f["GiuGinAnNinhLT"];
                int GiuGinAnNinh = parGiuGinAnNinh != null ? int.Parse(f["GiuGinAnNinhLT"].ToString()) : 0;
                //GiuVeSinhlt
                var parGiuVeSinh = f["GiuVeSinhLT"];
                int GiuVeSinh = parGiuVeSinh != null ? int.Parse(f["GiuVeSinhLT"].ToString()) : 0;
          
                int? TongTieuChi2 = KhongViPham + GiuGinAnNinh + GiuVeSinh;

                TongTieuChi2 = TongTieuChi2 <= 25 ? TongTieuChi2 : 25;
                List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
                var lstPQND = db.sp_laydiemsukien(masv).ToList();
                obj = lstPQND;

                int? ThamGiaHD = obj[0].TONGDIEM;
                ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;

                //llcapbomon
                var parLLCapboMon = f["LLCapboMonLT"];
                int LLCapboMon = parLLCapboMon != null ? int.Parse(f["LLCapboMonLT"].ToString()) : 0;
                //llcapkhoa
                var parLLCapKhoa= f["LLCapKhoaLT"];
                int LLCapKhoa = parLLCapKhoa != null ? int.Parse(f["LLCapKhoaLT"].ToString()) : 0;
                //ktdoankhoa
                var parKTDoanKhoa = f["KTDoanKhoaLT"];
                int KTDoanKhoa = parKTDoanKhoa != null ? int.Parse(f["KTDoanKhoaLT"].ToString()) : 0;
                //ktcaptruong
                var parKTCapTruong = f["KTCapTruongLT"];
                int KTCapTruong = parKTCapTruong != null ? int.Parse(f["KTCapTruongLT"].ToString()) : 0;
                //ktcapcaohon
                var parKTCapCaoHon = f["KTCapCaoHonLT"];
                int KTCapCaoHon = parKTCapCaoHon != null ? int.Parse(f["KTCapCaoHonLT"].ToString()) : 0;

          
                int? TongTieuChi3 = ThamGiaHD + LLCapboMon + LLCapKhoa + KTDoanKhoa + KTCapTruong + KTCapCaoHon;

                TongTieuChi3 = TongTieuChi3 <= 20 ? TongTieuChi3 : 20;


                // tieu chhi 4
                //kovpplnn
                var parKhongViPhamPLNN = f["KhongViPhamPLNNLT"];
                int KhongViPhamPLNN = parKhongViPhamPLNN != null ? int.Parse(f["KhongViPhamPLNNLT"].ToString()) : 0;
                //cotinhthangiupdo
                var parCoTinhThanGiupDo = f["CoTinhThanGiupDoLT"];
                int CoTinhThanGiupDo = parCoTinhThanGiupDo != null ? int.Parse(f["CoTinhThanGiupDoLT"].ToString()) : 0;
                //thamgiadoi
                var parThamGiaDoi = f["ThamGiaDoiLT"];
                int ThamGiaDoi = parThamGiaDoi != null ? int.Parse(f["ThamGiaDoiLT"].ToString()) : 0;
           
                int? TongTieuChi4 = KhongViPhamPLNN + CoTinhThanGiupDo + ThamGiaDoi;

                TongTieuChi4 = TongTieuChi4 <= 25 ? TongTieuChi4 : 25;
                // tieu chi 5
                //loptruong
                var parLopTruong = f["LopTruongLT"];
                int LopTruong = parLopTruong != null ? int.Parse(f["LopTruongLT"].ToString()) : 0;
                //cansulop
                var parCanSuLop = f["CanSuLopLT"];
                int CanSuLop = parCanSuLop != null ? int.Parse(f["CanSuLopLT"].ToString()) : 0;

                //cacthanhtichdacbiet
                var parCacThanhTichDacBiet = f["CacThanhTichDacBietLT"];
                int CacThanhTichDacBiet = parCacThanhTichDacBiet != null ? int.Parse(f["CacThanhTichDacBietLT"].ToString()) : 0;

           
            int? TongTieuChi5 = LopTruong + CanSuLop + CacThanhTichDacBiet;

            TongTieuChi5 = TongTieuChi5 <= 10 ? TongTieuChi5 : 10;

            int? Tong = TongTieuChi1 + TongTieuChi2 + TongTieuChi3 + TongTieuChi4 + TongTieuChi5;

            string xuatsac = "Xuất sắc";
            string tot = "Tốt";
            string kha = "Khá";
            string Tb = "Trung bình";
            string yeu = "Yếu";
            string kem = "Kém";
            string sxeploai = "";
            if (Tong > 90)
            {
                sxeploai = xuatsac;
            }
            else if (Tong >= 80)
            {
                sxeploai = tot;
            }
            else if (Tong >= 65)
            {
                sxeploai = kha;
            }
            else if (Tong >= 50)
            {
                sxeploai = Tb;
            }
            else if (Tong >= 35)
            {
                sxeploai = yeu;
            }
            else if (Tong < 35)
            {
                sxeploai = kem;
            }

            var model = db.DANHGIARENLUYENs;
            ObjectParameter returnId = new ObjectParameter("id", typeof(int));
            db.sp_ThemDanhGiaDiemRenLuyenLT1(IDSV, masv, DiHocDayDu, KQHocTap, CoGangVuotKho, NCKH, TinHoc, NgoaiNgu, TongTieuChi1, KhongViPham, GiuGinAnNinh, GiuVeSinh, TongTieuChi2, ThamGiaHD, LLCapboMon, LLCapKhoa, KTDoanKhoa, KTCapTruong, KTCapCaoHon, TongTieuChi3, KhongViPhamPLNN, CoTinhThanGiupDo, ThamGiaDoi, TongTieuChi4, LopTruong, CanSuLop, CacThanhTichDacBiet, TongTieuChi5, Tong, sxeploai, returnId);

           
            return RedirectToAction("DanhGiaThanhCongLT", new { ID = returnId.Value });
        }
        public ActionResult DanhGiaThanhCongLT(int? ID)
        {
            var data = db.DANHGIARENLUYENLOPTRUONGs.SingleOrDefault(n => n.ID == ID);
            string masv = data.FK_sMaSVID;
            List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
            var lstPQND = db.sp_laydiemsukien(masv).ToList();
            obj = lstPQND;

            int? ThamGiaHD = obj[0].TONGDIEM;
            ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;
            ViewBag.ThamGiaHD = ThamGiaHD;
            int? TongTieuChi1 = data.TongTieuChi1;
            int? TongTieuChi2 = data.TongTieuChi2;
            int? TongTieuChi3 = data.TongTieuChi3;
            int? TongTieuChi4 = data.TongTieuChi4;
            int? TongTieuChi5 = data.TongTieuChi5;


            if (data.iTongdiem != null)
            {
                int? Tong = data.iTongdiem;
                ViewBag.Tong = Tong;
            }
            ViewBag.TongTieuChi1 = TongTieuChi1;
            ViewBag.TongTieuChi2 = TongTieuChi2;
            ViewBag.TongTieuChi3 = TongTieuChi3;
            ViewBag.TongTieuChi4 = TongTieuChi4;
            ViewBag.TongTieuChi5 = TongTieuChi5;

            return View(data);
        }


        [HttpGet]
        public ActionResult LTDanhGiaDiemRenLuyenGV()
        {
            string a = Session["Lop"].ToString();

            if (Session["masv"] != null)
            {



                List<ds_sinhviendanhgiaGV_Result> obj = new List<ds_sinhviendanhgiaGV_Result>();
                var lstPQND = db.ds_sinhviendanhgiaGV(a).ToList();
                obj = lstPQND;


                return View(obj.ToList());
            }

            return RedirectToAction("DangNhap", "TaiKhoan");

        }


        public ActionResult ChiTietSVLT(string MA)
        {
            DANHGIARENLUYENLOPTRUONG dglt = db.DANHGIARENLUYENLOPTRUONGs.SingleOrDefault(m => m.FK_sMaSVID == MA);
            string masv1 = dglt.FK_sMaSVID;
            List<dk_locsinhviendanhgiagv_Result> dk = new List<dk_locsinhviendanhgiagv_Result>();
            var dkloc = db.dk_locsinhviendanhgiagv(masv1).ToList();
            dk = dkloc;
            if (dk.Count == 0)
            {


                List<hienthidsdgsvdglt_Result> dbo = new List<hienthidsdgsvdglt_Result>();
                var data = db.hienthidsdgsvdglt(MA).ToList();
                dbo = data;
                DANHGIARENLUYEN dg = db.DANHGIARENLUYENs.SingleOrDefault(m => m.FK_sMaSVID == MA);
                int? Tongtieuchi1 = dg.TongTieuChi1;
                int? Tongtieuchi2 = dg.TongTieuChi2;
                int? Tongtieuchi3 = dg.TongTieuChi3;
                int? Tongtieuchi4 = dg.TongTieuChi4;
                int? Tongtieuchi5 = dg.TongTieuChi5;
                int? Tong = dg.iTongdiem;
                ViewBag.Tongtieuchi1 = Tongtieuchi1;
                ViewBag.Tongtieuchi2 = Tongtieuchi2;
                ViewBag.Tongtieuchi3 = Tongtieuchi3;
                ViewBag.Tongtieuchi4 = Tongtieuchi4;
                ViewBag.Tongtieuchi5 = Tongtieuchi5;
                ViewBag.Tong = Tong;

                int? ID = dglt.ID;
                int? Tongtieuchi1lt = dglt.TongTieuChi1;
                int? Tongtieuchi2lt = dglt.TongTieuChi2;
                int? Tongtieuchi3lt = dglt.TongTieuChi3;
                int? Tongtieuchi4lt = dglt.TongTieuChi4;
                int? Tongtieuchi5lt = dglt.TongTieuChi5;
                int? Tonglt = dglt.iTongdiem;
                ViewBag.Tongtieuchi1lt = Tongtieuchi1lt;
                ViewBag.Tongtieuchi2lt = Tongtieuchi2lt;
                ViewBag.Tongtieuchi3lt = Tongtieuchi3lt;
                ViewBag.Tongtieuchi4lt = Tongtieuchi4lt;
                ViewBag.Tongtieuchi5lt = Tongtieuchi5lt;
                ViewBag.Tonglt = Tonglt;
                Session["id"] = dglt.ID;
                Session["masinhvien"] = dglt.FK_sMaSVID;


                return View(data);
                }
            else
            {
                return RedirectToAction("LTDanhGiaDiemRenLuyenGV", "QuanLyDiemRenLuyen");

            }

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ChiTietSVLT(IEnumerable<HttpPostedFileBase> files, FormCollection f, string MASV)
        {

            string ID = Session["id"].ToString();
            int? id = int.Parse(ID.ToString());
            string masv = Session["masinhvien"].ToString();

            string a = Session["masv"].ToString();
            //tieu chi 1
            //dihocdaydult
            var parDiHocDayDu = f["DiHocDayDuGV"];
            int DiHocDayDu = parDiHocDayDu != null ? int.Parse(f["DiHocDayDuGV"].ToString()) : 0;
            //kqhoctaplt
            var parKQHocTap = f["KQHocTapGV"];
            int KQHocTap = parKQHocTap != null ? int.Parse(f["KQHocTapGV"].ToString()) : 0;
            //cogangvuotkho
            var parCoGangVuotKho = f["CoGangVuotKhoGV"];
            int CoGangVuotKho = parCoGangVuotKho != null ? int.Parse(f["CoGangVuotKhoGV"].ToString()) : 0;
            //nckhlt
            var parNCKH = f["NCKHGV"];
            int NCKH = parNCKH != null ? int.Parse(f["NCKHGV"].ToString()) : 0;
            //tinhoclt
            var parTinHoc = f["TinHocGV"];
            int TinHoc = parTinHoc != null ? int.Parse(f["TinHocGV"].ToString()) : 0;
            //ngoaingult
            var parNgoaiNgu = f["NgoaiNguGV"];
            int NgoaiNgu = parNgoaiNgu != null ? int.Parse(f["NgoaiNguGV"].ToString()) : 0;

            int? TongTieuChi1 = DiHocDayDu + KQHocTap + CoGangVuotKho + NCKH + TinHoc + NgoaiNgu;

            TongTieuChi1 = TongTieuChi1 <= 20 ? TongTieuChi1 : 20;

            //tieu chi 2
            //khongviphammlt
            var parKhongViPham = f["KhongViPhamGV"];
            int KhongViPham = parKhongViPham != null ? int.Parse(f["KhongViPhamGV"].ToString()) : 0;
            //GiuGinAnNinhlt
            var parGiuGinAnNinh = f["GiuGinAnNinhGV"];
            int GiuGinAnNinh = parGiuGinAnNinh != null ? int.Parse(f["GiuGinAnNinhGV"].ToString()) : 0;
            //GiuVeSinhlt
            var parGiuVeSinh = f["GiuVeSinhGV"];
            int GiuVeSinh = parGiuVeSinh != null ? int.Parse(f["GiuVeSinhGV"].ToString()) : 0;

            int? TongTieuChi2 = KhongViPham + GiuGinAnNinh + GiuVeSinh;

            TongTieuChi2 = TongTieuChi2 <= 25 ? TongTieuChi2 : 25;
            List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
            var lstPQND = db.sp_laydiemsukien(masv).ToList();
            obj = lstPQND;

            int? ThamGiaHD = obj[0].TONGDIEM;
            ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;

            //llcapbomon
            var parLLCapboMon = f["LLCapboMonGV"];
            int LLCapboMon = parLLCapboMon != null ? int.Parse(f["LLCapboMonGV"].ToString()) : 0;
            //llcapkhoa
            var parLLCapKhoa = f["LLCapKhoaGV"];
            int LLCapKhoa = parLLCapKhoa != null ? int.Parse(f["LLCapKhoaGV"].ToString()) : 0;
            //ktdoankhoa
            var parKTDoanKhoa = f["KTDoanKhoaGV"];
            int KTDoanKhoa = parKTDoanKhoa != null ? int.Parse(f["KTDoanKhoaGV"].ToString()) : 0;
            //ktcaptruong
            var parKTCapTruong = f["KTCapTruongGV"];
            int KTCapTruong = parKTCapTruong != null ? int.Parse(f["KTCapTruongGV"].ToString()) : 0;
            //ktcapcaohon
            var parKTCapCaoHon = f["KTCapCaoHonGV"];
            int KTCapCaoHon = parKTCapCaoHon != null ? int.Parse(f["KTCapCaoHonGV"].ToString()) : 0;


            int? TongTieuChi3 = ThamGiaHD + LLCapboMon + LLCapKhoa + KTDoanKhoa + KTCapTruong + KTCapCaoHon;

            TongTieuChi3 = TongTieuChi3 <= 20 ? TongTieuChi3 : 20;


            // tieu chhi 4
            //kovpplnn
            var parKhongViPhamPLNN = f["KhongViPhamPLNNGV"];
            int KhongViPhamPLNN = parKhongViPhamPLNN != null ? int.Parse(f["KhongViPhamPLNNGV"].ToString()) : 0;
            //cotinhthangiupdo
            var parCoTinhThanGiupDo = f["CoTinhThanGiupDoGV"];
            int CoTinhThanGiupDo = parCoTinhThanGiupDo != null ? int.Parse(f["CoTinhThanGiupDoGV"].ToString()) : 0;
            //thamgiadoi
            var parThamGiaDoi = f["ThamGiaDoiGV"];
            int ThamGiaDoi = parThamGiaDoi != null ? int.Parse(f["ThamGiaDoiGV"].ToString()) : 0;

            int? TongTieuChi4 = KhongViPhamPLNN + CoTinhThanGiupDo + ThamGiaDoi;

            TongTieuChi4 = TongTieuChi4 <= 25 ? TongTieuChi4 : 25;
            // tieu chi 5
            //loptruong
            var parLopTruong = f["LopTruongGV"];
            int LopTruong = parLopTruong != null ? int.Parse(f["LopTruongGV"].ToString()) : 0;
            //cansulop
            var parCanSuLop = f["CanSuLopGV"];
            int CanSuLop = parCanSuLop != null ? int.Parse(f["CanSuLopGV"].ToString()) : 0;

            //cacthanhtichdacbiet
            var parCacThanhTichDacBiet = f["CacThanhTichDacBietGV"];
            int CacThanhTichDacBiet = parCacThanhTichDacBiet != null ? int.Parse(f["CacThanhTichDacBietGV"].ToString()) : 0;


            int? TongTieuChi5 = LopTruong + CanSuLop + CacThanhTichDacBiet;

            TongTieuChi5 = TongTieuChi5 <= 10 ? TongTieuChi5 : 10;

            int? Tong = TongTieuChi1 + TongTieuChi2 + TongTieuChi3 + TongTieuChi4 + TongTieuChi5;

            string xuatsac = "Xuất sắc";
            string tot = "Tốt";
            string kha = "Khá";
            string Tb = "Trung bình";
            string yeu = "Yếu";
            string kem = "Kém";
            string sxeploai = "";
            if (Tong > 90)
            {
                sxeploai = xuatsac;
            }
            else if (Tong >= 80)
            {
                sxeploai = tot;
            }
            else if (Tong >= 65)
            {
                sxeploai = kha;
            }
            else if (Tong >= 50)
            {
                sxeploai = Tb;
            }
            else if (Tong >= 35)
            {
                sxeploai = yeu;
            }
            else if (Tong < 35)
            {
                sxeploai = kem;
            }

            var model = db.DANHGIARENLUYENs;
            ObjectParameter returnId = new ObjectParameter("id", typeof(int));
          
            db.sp_ThemDanhGiaDiemRenLuyenGV1(id, masv ,a, DiHocDayDu, KQHocTap, CoGangVuotKho, NCKH, TinHoc, NgoaiNgu, TongTieuChi1, KhongViPham, GiuGinAnNinh, GiuVeSinh, TongTieuChi2, ThamGiaHD, LLCapboMon, LLCapKhoa, KTDoanKhoa, KTCapTruong, KTCapCaoHon, TongTieuChi3, KhongViPhamPLNN, CoTinhThanGiupDo, ThamGiaDoi, TongTieuChi4, LopTruong, CanSuLop, CacThanhTichDacBiet, TongTieuChi5, Tong, sxeploai, returnId);

            return RedirectToAction("DanhGiaThanhCongGV", new { ID = returnId.Value });

        }

        public ActionResult DanhGiaThanhCongGV(int? ID)
        {
            var data = db.DANHGIARENLUYENTHAYCOes.SingleOrDefault(n => n.ID == ID);
            string masv = Session["masinhvien"].ToString();
            List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
            var lstPQND = db.sp_laydiemsukien(masv).ToList();
            obj = lstPQND;

            int? ThamGiaHD = obj[0].TONGDIEM;
            ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;
            ViewBag.ThamGiaHD = ThamGiaHD;
           int? TongTieuChi1 = data.TongTieuChi1;
            int? TongTieuChi2 = data.TongTieuChi2;
            int? TongTieuChi3 = data.TongTieuChi3;
            int? TongTieuChi4 = data.TongTieuChi4;
            int? TongTieuChi5 = data.TongTieuChi5;
        

            if (data.iTongdiem != null)
            {
                int? Tong = data.iTongdiem;
                ViewBag.Tong = Tong;
            }
            ViewBag.TongTieuChi1 = TongTieuChi1;
            ViewBag.TongTieuChi2 = TongTieuChi2;
            ViewBag.TongTieuChi3 = TongTieuChi3;
            ViewBag.TongTieuChi4 = TongTieuChi4;
            ViewBag.TongTieuChi5 = TongTieuChi5;

            return View(data);
        }

        // chinhsuadanhgiarenluyenthayco


        [HttpGet]
        public ActionResult DanhsachChinhSuaDGGV()
        {
            
          
            if (Session["TenNguoiDung"] != null)
            {



                List<dsdanhgiadiemrenluyenGV1_Result> obj = new List<dsdanhgiadiemrenluyenGV1_Result>();
                var lstPQND = db.dsdanhgiadiemrenluyenGV1().ToList();
                obj = lstPQND;


                return View(obj.ToList());
            }

            return RedirectToAction("DangNhap", "TaiKhoan");

        }
        [HttpGet]
        public ActionResult ChinhSuaDGGV( int? ID)
        {

            DANHGIARENLUYENTHAYCO danhgiarenluyen = db.DANHGIARENLUYENTHAYCOes.SingleOrDefault(m => m.ID == ID);
                int? Tong = danhgiarenluyen.iTongdiem;
                ViewBag.Tong = Tong;
                ViewBag.IDCT = ID;
                  Session["masinhvien"] = danhgiarenluyen.FK_sMaSVID;
            if (danhgiarenluyen == null)
                {
                    Response.StatusCode = 404;
                    return null;

                }
                return View(danhgiarenluyen);
           


          
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ChinhSuaDGGV(IEnumerable<HttpPostedFileBase> files, FormCollection f, int ID)
        {

          
            int? id = int.Parse(ID.ToString());
            string masv = Session["masinhvien"].ToString();

            string a = Session["masv"].ToString();
            //tieu chi 1
            //dihocdaydult
            var parDiHocDayDu = f["DiHocDayDuGV"];
            int DiHocDayDu = parDiHocDayDu != null ? int.Parse(f["DiHocDayDuGV"].ToString()) : 0;
            //kqhoctaplt
            var parKQHocTap = f["KQHocTapGV"];
            int KQHocTap = parKQHocTap != null ? int.Parse(f["KQHocTapGV"].ToString()) : 0;
            //cogangvuotkho
            var parCoGangVuotKho = f["CoGangVuotKhoGV"];
            int CoGangVuotKho = parCoGangVuotKho != null ? int.Parse(f["CoGangVuotKhoGV"].ToString()) : 0;
            //nckhlt
            var parNCKH = f["NCKHGV"];
            int NCKH = parNCKH != null ? int.Parse(f["NCKHGV"].ToString()) : 0;
            //tinhoclt
            var parTinHoc = f["TinHocGV"];
            int TinHoc = parTinHoc != null ? int.Parse(f["TinHocGV"].ToString()) : 0;
            //ngoaingult
            var parNgoaiNgu = f["NgoaiNguGV"];
            int NgoaiNgu = parNgoaiNgu != null ? int.Parse(f["NgoaiNguGV"].ToString()) : 0;

            int? TongTieuChi1 = DiHocDayDu + KQHocTap + CoGangVuotKho + NCKH + TinHoc + NgoaiNgu;

            TongTieuChi1 = TongTieuChi1 <= 20 ? TongTieuChi1 : 20;

            //tieu chi 2
            //khongviphammlt
            var parKhongViPham = f["KhongViPhamGV"];
            int KhongViPham = parKhongViPham != null ? int.Parse(f["KhongViPhamGV"].ToString()) : 0;
            //GiuGinAnNinhlt
            var parGiuGinAnNinh = f["GiuGinAnNinhGV"];
            int GiuGinAnNinh = parGiuGinAnNinh != null ? int.Parse(f["GiuGinAnNinhGV"].ToString()) : 0;
            //GiuVeSinhlt
            var parGiuVeSinh = f["GiuVeSinhGV"];
            int GiuVeSinh = parGiuVeSinh != null ? int.Parse(f["GiuVeSinhGV"].ToString()) : 0;

            int? TongTieuChi2 = KhongViPham + GiuGinAnNinh + GiuVeSinh;

            TongTieuChi2 = TongTieuChi2 <= 25 ? TongTieuChi2 : 25;
            List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
            var lstPQND = db.sp_laydiemsukien(masv).ToList();
            obj = lstPQND;

            int? ThamGiaHD = obj[0].TONGDIEM;
            ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;

            //llcapbomon
            var parLLCapboMon = f["LLCapboMonGV"];
            int LLCapboMon = parLLCapboMon != null ? int.Parse(f["LLCapboMonGV"].ToString()) : 0;
            //llcapkhoa
            var parLLCapKhoa = f["LLCapKhoaGV"];
            int LLCapKhoa = parLLCapKhoa != null ? int.Parse(f["LLCapKhoaGV"].ToString()) : 0;
            //ktdoankhoa
            var parKTDoanKhoa = f["KTDoanKhoaGV"];
            int KTDoanKhoa = parKTDoanKhoa != null ? int.Parse(f["KTDoanKhoaGV"].ToString()) : 0;
            //ktcaptruong
            var parKTCapTruong = f["KTCapTruongGV"];
            int KTCapTruong = parKTCapTruong != null ? int.Parse(f["KTCapTruongGV"].ToString()) : 0;
            //ktcapcaohon
            var parKTCapCaoHon = f["KTCapCaoHonGV"];
            int KTCapCaoHon = parKTCapCaoHon != null ? int.Parse(f["KTCapCaoHonGV"].ToString()) : 0;


            int? TongTieuChi3 = ThamGiaHD + LLCapboMon + LLCapKhoa + KTDoanKhoa + KTCapTruong + KTCapCaoHon;

            TongTieuChi3 = TongTieuChi3 <= 20 ? TongTieuChi3 : 20;


            // tieu chhi 4
            //kovpplnn
            var parKhongViPhamPLNN = f["KhongViPhamPLNNGV"];
            int KhongViPhamPLNN = parKhongViPhamPLNN != null ? int.Parse(f["KhongViPhamPLNNGV"].ToString()) : 0;
            //cotinhthangiupdo
            var parCoTinhThanGiupDo = f["CoTinhThanGiupDoGV"];
            int CoTinhThanGiupDo = parCoTinhThanGiupDo != null ? int.Parse(f["CoTinhThanGiupDoGV"].ToString()) : 0;
            //thamgiadoi
            var parThamGiaDoi = f["ThamGiaDoiGV"];
            int ThamGiaDoi = parThamGiaDoi != null ? int.Parse(f["ThamGiaDoiGV"].ToString()) : 0;

            int? TongTieuChi4 = KhongViPhamPLNN + CoTinhThanGiupDo + ThamGiaDoi;

            TongTieuChi4 = TongTieuChi4 <= 25 ? TongTieuChi4 : 25;
            // tieu chi 5
            //loptruong
            var parLopTruong = f["LopTruongGV"];
            int LopTruong = parLopTruong != null ? int.Parse(f["LopTruongGV"].ToString()) : 0;
            //cansulop
            var parCanSuLop = f["CanSuLopGV"];
            int CanSuLop = parCanSuLop != null ? int.Parse(f["CanSuLopGV"].ToString()) : 0;

            //cacthanhtichdacbiet
            var parCacThanhTichDacBiet = f["CacThanhTichDacBietGV"];
            int CacThanhTichDacBiet = parCacThanhTichDacBiet != null ? int.Parse(f["CacThanhTichDacBietGV"].ToString()) : 0;


            int? TongTieuChi5 = LopTruong + CanSuLop + CacThanhTichDacBiet;

            TongTieuChi5 = TongTieuChi5 <= 10 ? TongTieuChi5 : 10;

            int? Tong = TongTieuChi1 + TongTieuChi2 + TongTieuChi3 + TongTieuChi4 + TongTieuChi5;

            string xuatsac = "Xuất sắc";
            string tot = "Tốt";
            string kha = "Khá";
            string Tb = "Trung bình";
            string yeu = "Yếu";
            string kem = "Kém";
            string sxeploai = "";
            if (Tong > 90)
            {
                sxeploai = xuatsac;
            }
            else if (Tong >= 80)
            {
                sxeploai = tot;
            }
            else if (Tong >= 65)
            {
                sxeploai = kha;
            }
            else if (Tong >= 50)
            {
                sxeploai = Tb;
            }
            else if (Tong >= 35)
            {
                sxeploai = yeu;
            }
            else if (Tong < 35)
            {
                sxeploai = kem;
            }

            var model = db.DANHGIARENLUYENs;
          

            db.sp_updateDanhGiaDiemRenLuyenGV1(id, DiHocDayDu, KQHocTap, CoGangVuotKho, NCKH, TinHoc, NgoaiNgu, TongTieuChi1, KhongViPham, GiuGinAnNinh, GiuVeSinh, TongTieuChi2, ThamGiaHD, LLCapboMon, LLCapKhoa, KTDoanKhoa, KTCapTruong, KTCapCaoHon, TongTieuChi3, KhongViPhamPLNN, CoTinhThanGiupDo, ThamGiaDoi, TongTieuChi4, LopTruong, CanSuLop, CacThanhTichDacBiet, TongTieuChi5, Tong, sxeploai);

            return RedirectToAction("ChinhSuaThanhCongGV", new {ID=ID});

        }


        public ActionResult ChinhSuaThanhCongGV(int? ID)
        {
            var data = db.DANHGIARENLUYENTHAYCOes.SingleOrDefault(n => n.ID == ID);
            string masv = Session["masinhvien"].ToString();
            List<sp_laydiemsukien_Result> obj = new List<sp_laydiemsukien_Result>();
            var lstPQND = db.sp_laydiemsukien(masv).ToList();
            obj = lstPQND;

            int? ThamGiaHD = obj[0].TONGDIEM;
            ThamGiaHD = ThamGiaHD <= 12 ? ThamGiaHD : 12;
            ViewBag.ThamGiaHD = ThamGiaHD;
            int? TongTieuChi1 = data.TongTieuChi1;
            int? TongTieuChi2 = data.TongTieuChi2;
            int? TongTieuChi3 = data.TongTieuChi3;
            int? TongTieuChi4 = data.TongTieuChi4;
            int? TongTieuChi5 = data.TongTieuChi5;


            if (data.iTongdiem != null)
            {
                int? Tong = data.iTongdiem;
                ViewBag.Tong = Tong;
            }
            ViewBag.TongTieuChi1 = TongTieuChi1;
            ViewBag.TongTieuChi2 = TongTieuChi2;
            ViewBag.TongTieuChi3 = TongTieuChi3;
            ViewBag.TongTieuChi4 = TongTieuChi4;
            ViewBag.TongTieuChi5 = TongTieuChi5;

            return View(data);
        }










    }




}