using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using QLBH_MCDONALDS.Models;
using System.Globalization;

namespace QLBH_MCDONALDS.Areas.Admin.Controllers
{
    public class BaoCaoController : Controller
    {
        private QLCuaHangMcDonaldEntities db = new QLCuaHangMcDonaldEntities();
        // GET: Admin/BaoCao
        public ActionResult Index()
        {
            return View(new List<ChiTietHoaDon>());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DateTime? start, DateTime? end)
        {
            ViewBag.start = Request["start-date"];
            ViewBag.end = Request["end-date"];
            if (Request["start-date"] == null || Request["end-date"] == null) return View(new List<ChiTietHoaDon>());
            start = DateTime.Parse(Request["start-date"]);
            end = DateTime.Parse(Request["end-date"]);
            var list = db.ChiTietHoaDons
                .Include(x => x.HoaDon)
                .Where(x => x.HoaDon.NgayLapHD >= start && x.HoaDon.NgayLapHD <= end)
                .Include(x => x.SanPham).ToList();
            return View(list);
        }
    }
}