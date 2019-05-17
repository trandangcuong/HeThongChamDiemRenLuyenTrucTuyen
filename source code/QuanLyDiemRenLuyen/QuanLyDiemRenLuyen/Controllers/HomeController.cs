using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDiemRenLuyen.Models;

namespace QuanLyDiemRenLuyen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var message = new MessageModel();
            message.Welcom = "Xìn Chào bạn đến với Hệ Thống Quản Lý Điểm Rèn Luyện - Đại Học Thủ Dầu Một";

            return View(message);
        }
    }
}