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
    public class ChiTietDonNhapHangsController : Controller
    {
        private QLCuaHangMcDonaldEntities db = new QLCuaHangMcDonaldEntities();

        // GET: Admin/ChiTietDonNhapHangs
        public ActionResult Index()
        {
            var chiTietDonNhapHangs = db.ChiTietDonNhapHangs.Include(c => c.DonNhapHang).Include(c => c.NguyenLieu);
            return View(chiTietDonNhapHangs.ToList());
        }

        // GET: Admin/ChiTietDonNhapHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonNhapHang chiTietDonNhapHang = db.ChiTietDonNhapHangs.Find(id);
            if (chiTietDonNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonNhapHang);
        }

        // GET: Admin/ChiTietDonNhapHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDonHang = new SelectList(db.DonNhapHangs, "MaDonHang", "MaNCC");
            ViewBag.MaNL = new SelectList(db.NguyenLieux, "MaNL", "TenNL");
            return View();
        }

        // POST: Admin/ChiTietDonNhapHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,MaNL,SoLuongNguyenLieu")] ChiTietDonNhapHang chiTietDonNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonNhapHangs.Add(chiTietDonNhapHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDonHang = new SelectList(db.DonNhapHangs, "MaDonHang", "MaNCC", chiTietDonNhapHang.MaDonHang);
            ViewBag.MaNL = new SelectList(db.NguyenLieux, "MaNL", "TenNL", chiTietDonNhapHang.MaNL);
            return View(chiTietDonNhapHang);
        }

        // GET: Admin/ChiTietDonNhapHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonNhapHang chiTietDonNhapHang = db.ChiTietDonNhapHangs.Find(id);
            if (chiTietDonNhapHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDonHang = new SelectList(db.DonNhapHangs, "MaDonHang", "MaNCC", chiTietDonNhapHang.MaDonHang);
            ViewBag.MaNL = new SelectList(db.NguyenLieux, "MaNL", "TenNL", chiTietDonNhapHang.MaNL);
            return View(chiTietDonNhapHang);
        }

        // POST: Admin/ChiTietDonNhapHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,MaNL,SoLuongNguyenLieu")] ChiTietDonNhapHang chiTietDonNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDonNhapHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDonHang = new SelectList(db.DonNhapHangs, "MaDonHang", "MaNCC", chiTietDonNhapHang.MaDonHang);
            ViewBag.MaNL = new SelectList(db.NguyenLieux, "MaNL", "TenNL", chiTietDonNhapHang.MaNL);
            return View(chiTietDonNhapHang);
        }

        // GET: Admin/ChiTietDonNhapHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonNhapHang chiTietDonNhapHang = db.ChiTietDonNhapHangs.Find(id);
            if (chiTietDonNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonNhapHang);
        }

        // POST: Admin/ChiTietDonNhapHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietDonNhapHang chiTietDonNhapHang = db.ChiTietDonNhapHangs.Find(id);
            db.ChiTietDonNhapHangs.Remove(chiTietDonNhapHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
