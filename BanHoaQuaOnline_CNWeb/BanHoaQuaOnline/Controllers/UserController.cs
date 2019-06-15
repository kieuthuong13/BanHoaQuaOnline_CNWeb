using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHoaQuaOnline.Models;


namespace BanHoaQuaOnline.Controllers
{
    public class UserController : Controller
    {
        QuanLyBanQua db = new QuanLyBanQua();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DangKy(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                //insert dữ liệu vào bảng khách hàng
                db.KHACHHANGs.Add(kh); // cái này chỉ lưu vào models thôi
                //lưu vào cơ sở dữ liệu 
                db.SaveChanges();

            }
            return View();
        }

        //đăng nhập
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string TaiKhoan = f["txtTaiKhoan"].ToString();
            string MatKhau = f.Get("txtMatKhau").ToString();
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TaiKhoan == TaiKhoan && n.MatKhau == MatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
                Session["TaiKhoan"] = kh;
                return View();
            }
            ViewBag.ThongBao = "Đăng nhập thất bại!";
            return View();
        }
    }
}