using QLBH_MCDONALDS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QLBH_MCDONALDS.Areas.Admin.Controllers
{
    public class POSController : Controller
    {
        private QLCuaHangMcDonaldEntities db = new QLCuaHangMcDonaldEntities();
        // GET: Admin/POS
        public ActionResult Index(string id)
        {
            ViewData["listOrdered"] = db.SanPhams.ToList();
            if (id == null || id == "All")
                return View(db.SanPhams.ToList());
            else
                return View(db.SanPhams.Where(s=>s.MaLoai==id).ToList());
        }
    }
}