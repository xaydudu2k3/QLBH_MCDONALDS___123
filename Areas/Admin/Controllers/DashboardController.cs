using QLBH_MCDONALDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_MCDONALDS.Areas.Admin.Controllers
{

    public class DashboardController : Controller
    {
        private QLCuaHangMcDonaldEntities db = new QLCuaHangMcDonaldEntities();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.SL_Loaisp = new SelectList(db.LoaiSPs, "MaLoai");
            ViewBag.soLSP = db.LoaiSPs.Count();

            ViewBag.SL_sp = new SelectList(db.SanPhams, "MaSP");
            ViewBag.soSP = db.SanPhams.Count();

            ViewBag.SL_HangDoiHD = new SelectList(db.HoaDons.Where(h => h.TrangThai == 0), "MaHoaDon");
            ViewBag.soHangDoi = db.HoaDons.Count(h => h.TrangThai == 0);

            DateTime ngayHomNay = DateTime.Today;

            var tongSoTien = (from hd in db.HoaDons
                              join chd in db.ChiTietHoaDons on hd.MaHoaDon equals chd.MaHoaDon
                              join sp in db.SanPhams on chd.MaSP equals sp.MaSP
                              where hd.NgayLapHD == ngayHomNay
                              select chd.SoLuongSP * sp.Gia).Sum();
            ViewBag.TongSoTienHomNay = tongSoTien;

            return View();
        }
    }
}