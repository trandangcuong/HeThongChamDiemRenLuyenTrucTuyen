using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDiemRenLuyen.Models
{
    public class XemDiem
    {
        public string MaSV { get; set; }
        public int NamHoc { get; set; }
        public int HocKy { get; set; }
        public int? TongTC1 { get; set; }
        public int? TongTC2 { get; set; }
        public int? TongTC3 { get; set; }
        public int? TongTC4 { get; set; }
        public int? TongTC5 { get; set; }
        public int? tongdiem { get; set; }
        public string xeploai { get; set; }
        public DateTime? ngaylap { get; set; }
    }
}