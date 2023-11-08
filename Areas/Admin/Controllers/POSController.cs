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
        string LayMaHD()
        {
            var maMax = db.HoaDons.ToList().Select(n => n.MaHoaDon).Max();
            int maHD = int.Parse(maMax.Substring(2)) + 1;
            string HD = String.Concat("000", maHD.ToString());
            return HD.Substring(maHD.ToString().Length - 1);
        }
        /// //////////////////////////////////////////////////////////////////
        //THÊM ĐƠN HÀNG VÀO HÓA ĐƠN & CHI TIẾT HÓA ĐƠN
        [HttpPost]
        public ActionResult Index(string submit)
        {
            if (submit == "order" && Session["MyArray"] != null)
            {
                HoaDon hd = new HoaDon();
                hd.MaHoaDon = LayMaHD();
                hd.TrangThai = 0;
                hd.NgayLapHD = DateTime.Now;
                db.HoaDons.Add(hd);
                db.SaveChanges();
                foreach (var item in Session["MyArray"] as IEnumerable<Donhang>)
                {

                    ChiTietHoaDon ct = new ChiTietHoaDon();
                    ct.MaHoaDon = hd.MaHoaDon;
                    ct.MaSP = item.ma_san_pham;
                    ct.SoLuongSP = item.soluong;
                    db.ChiTietHoaDons.Add(ct);
                }
                db.SaveChanges();
                TempData["SuccessMessage"] = "Thanh toán thành công!";
                Session["MyArray"] = null;
                ViewData["listOrdered"] = null;
            }
            return RedirectToAction("Index");
        }
    }
}