using QLBH_MCDONALDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_MCDONALDS.Areas.Admin.Controllers
{
    public class PhongBepController : Controller
    {
        private QLCuaHangMcDonaldEntities db = new QLCuaHangMcDonaldEntities();
        // GET: Admin/PhongBep
        public ActionResult Index()
        {
            return View(db.ChiTietHoaDons.ToList());
        }
        public ActionResult Serve(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            hoaDon.TrangThai = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}