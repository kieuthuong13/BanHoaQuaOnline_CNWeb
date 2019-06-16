using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHoaQuaOnline.Models;
using PagedList.Mvc;
using PagedList;

namespace BanHoaQuaOnline.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyBanQua db = new QuanLyBanQua();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<NONGSAN> lstKQTK = db.NONGSANs.Where(n => n.TenNongSan.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.NONGSANs.OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
        }


        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<NONGSAN> lstKQTK = db.NONGSANs.Where(n => n.TenNongSan.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.NONGSANs.OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
        }
    }
}