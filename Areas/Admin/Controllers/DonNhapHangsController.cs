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
    public class DonNhapHangsController : Controller
    {
        private QLCuaHangMcDonaldEntities db = new QLCuaHangMcDonaldEntities();

        // GET: Admin/DonNhapHangs
        public ActionResult Index()
        {
            var donNhapHangs = db.DonNhapHangs.Include(d => d.NhaCungCap);
            return View(donNhapHangs.ToList());
        }

        //GET: Admin/DonNhapHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNhapHang donNhapHang = db.DonNhapHangs.Find(id);
            if (donNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(donNhapHang);
        }




        // GET: Admin/DonNhapHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");
            return View();
        }

        // POST: Admin/DonNhapHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,MaNCC,NgayNhapHang")] DonNhapHang donNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.DonNhapHangs.Add(donNhapHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", donNhapHang.MaNCC);
            return View(donNhapHang);
        }

        // GET: Admin/DonNhapHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNhapHang donNhapHang = db.DonNhapHangs.Find(id);
            if (donNhapHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", donNhapHang.MaNCC);
            return View(donNhapHang);
        }

        // POST: Admin/DonNhapHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,MaNCC,NgayNhapHang")] DonNhapHang donNhapHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donNhapHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", donNhapHang.MaNCC);
            return View(donNhapHang);
        }

        // GET: Admin/DonNhapHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonNhapHang donNhapHang = db.DonNhapHangs.Find(id);
            if (donNhapHang == null)
            {
                return HttpNotFound();
            }
            return View(donNhapHang);
        }

        // POST: Admin/DonNhapHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonNhapHang donNhapHang = db.DonNhapHangs.Find(id);
            db.DonNhapHangs.Remove(donNhapHang);
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
