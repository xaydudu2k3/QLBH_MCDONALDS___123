using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBH_MCDONALDS.Models;

namespace QLBH_MCDONALDS.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {
        private QLCuaHangMcDonaldEntities db = new QLCuaHangMcDonaldEntities();
        // GET: Admin/HoaDon
        public ActionResult Index()
        {
            var list = db.ChiTietHoaDons.Include(x => x.SanPham).Include(x => x.HoaDon).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Index(string id)
        {

            ViewBag.show = true;
            if (id != null)
            {
                ViewBag.show = false;
            }
            HoaDon ct = db.HoaDons.Find(id);
            if(ct == null)
            {
                ViewBag.show = false;
            }
            else
            {
                ViewBag.show = true;
                ViewBag.HoaDon = ct;
                ViewBag.ChiTietDon = db.ChiTietHoaDons.Where(x => x.MaHoaDon == ct.MaHoaDon)
                    .Include(x=>x.SanPham).ToList();
            }
            var list = db.ChiTietHoaDons.Include(x => x.SanPham).Include(x => x.HoaDon).ToList();
            return View(list);
        }
        // GET: Admin/HoaDon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: Admin/HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
