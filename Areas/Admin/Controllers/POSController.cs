using Newtonsoft.Json.Linq;
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
        public ActionResult Index(string id, string MaSp)
        {

            List<SanPham> sp = db.SanPhams.Where(s => s.MaSP == MaSp).ToList();

            if (MaSp != null)
            {
                var sanPham = db.SanPhams
             .Where(s => s.MaSP == MaSp)
             .Select(s => new
             {
                 masp = s.MaSP,
                 TenSanPham = s.TenSP,
                 giatien = s.Gia
             })
             .FirstOrDefault(); // Lấy ra sản phẩm đầu tiên hoặc null nếu không tìm thấy

                if (Session["MyArray"] != null)
                {

                    // Ép kiểu Session["MyArray"] về kiểu mảng bạn đã lưu(ở đây là string[])
                    List<Donhang> retrieveobject = (List<Donhang>)Session["MyArray"];

                    bool contains = retrieveobject.Any(donhang => donhang.ma_san_pham == MaSp);

                    if (contains)
                    {
                        Donhang donhangToUpdate = retrieveobject.First(donhang => donhang.ma_san_pham == MaSp);
                        donhangToUpdate.soluong += 1;
                        Session["MyArray"] = retrieveobject;
                        ViewData["listOrdered"] = retrieveobject;
                    }
                    else
                    {
                        Donhang san_p = new Donhang
                        {
                            san_pham = sanPham.TenSanPham,
                            ma_san_pham = sanPham.masp,
                            gia = (int)sanPham.giatien,
                            soluong = 1,
                        };



                        retrieveobject.Add(san_p);
                        Session["MyArray"] = retrieveobject;
                    }
                }



                else
                {

                    List<Donhang> retrieveobject = new List<Donhang>();
                    Donhang san_p = new Donhang
                    {
                        san_pham = sanPham.TenSanPham,
                        ma_san_pham = sanPham.masp,
                        gia = (int)sanPham.giatien,
                        soluong = 1,
                    };
                    retrieveobject.Add(san_p);
                    Session["MyArray"] = retrieveobject;
                    
                }
            }
            ViewData["listOrdered"] = Session["MyArray"];
            if (id == null || id == "All")
                return View(db.SanPhams.ToList());
            else
                return View(db.SanPhams.Where(s => s.MaLoai == id).ToList());


        }

        public ActionResult Delete_sp(string MaSp)
        {

            if (Session["MyArray"] != null)
            {

                // Ép kiểu Session["MyArray"] về kiểu mảng bạn đã lưu(ở đây là string[])
                List<Donhang> retrieveobject = (List<Donhang>)Session["MyArray"];


                Donhang donhangToRemove = retrieveobject.FirstOrDefault(donhang => donhang.ma_san_pham == MaSp);
                if (donhangToRemove != null)
                {
                    retrieveobject.Remove(donhangToRemove);
                    Session["MyArray"] = retrieveobject;
                    
                }
                ViewData["listOrdered"] = retrieveobject;
            }


            return RedirectToAction("Index");

        }
    }
}