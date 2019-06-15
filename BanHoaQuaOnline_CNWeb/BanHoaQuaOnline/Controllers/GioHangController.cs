using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanHoaQuaOnline.Models;

namespace BanHoaQuaOnline.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanQua db = new QuanLyBanQua();
        // GET: GioHang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //nếu giỏ hàng chưa tồn tại, tiến hành khởi tạo list giỏ hàng
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //thêm giỏ hàng
        public ActionResult AddGioHang(int idMaQua, string strURL)
        {
            NONGSAN qua = db.NONGSANs.SingleOrDefault(n => n.MaNongSan == idMaQua);
            if (qua == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra nông sản
            GioHang SanPham = lstGioHang.Find(n => n.idMaQua == idMaQua);
            if (SanPham == null)
            {
                SanPham = new GioHang(idMaQua);
                lstGioHang.Add(SanPham);
                return Redirect(strURL);
            }
            else
            {
                SanPham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        //cập nhật giỏ hàng
        public ActionResult EditGioHang(int iMaSP, FormCollection f)
        {
            //kiểm tra
            //nếu get sai mã sẩn phẩm thì trả về trang lỗi 404
            NONGSAN qua = db.NONGSANs.SingleOrDefault(n => n.MaNongSan == iMaSP);
            if (qua == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();

            //kiểm tra sp có tồn tại trong giỏ hàng
            GioHang SanPham = lstGioHang.SingleOrDefault(n => n.idMaQua == iMaSP);
            if (SanPham != null)
            {
                SanPham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }

        //xóa giỏ hàng
        public ActionResult DeleteGioHang(int iMaSP)
        {
            //kiểm tra
            //nếu get sai mã sẩn phẩm thì trả về trang lỗi 404
            NONGSAN qua = db.NONGSANs.SingleOrDefault(n => n.MaNongSan == iMaSP);
            if (qua == null)
            {
                Response.SubStatusCode = 404;
                return null;
            }
            //lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //kiểm tra sp có tồn tại trong giỏ hàng
            GioHang SanPham = lstGioHang.SingleOrDefault(n => n.idMaQua == iMaSP);
            if (SanPham != null)
            {
                lstGioHang.RemoveAll(n => n.idMaQua == iMaSP);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "NongSan");
            }
            return RedirectToAction("GioHang");
        }

        //xây dụng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "NongSan");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        //tính tổng số lượng và tổng tiền
        private int TongSoLuong()
        {
            int TongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                TongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return TongSoLuong;
        }

        //tính tiền
        private int TongTien()
        {
            int TongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                TongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return TongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "NongSan");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }


        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "NongSan");
            }
            //Thêm đơn hàng
            DONHANG dh = new DONHANG();
            KHACHHANG kh = (KHACHHANG)Session["TaiKhoan"];
            List<GioHang> gh = LayGioHang();
            dh.MaKhachHang = kh.MaKhachHang;
            dh.NgayDat = DateTime.Now;
            db.DONHANGs.Add(dh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                CTDONHANG ctDH = new CTDONHANG();
                //NONGSAN ns = new NONGSAN();
                ctDH.MaHoaDon = dh.MaHoaDon;
                ctDH.MaNongSan = item.idMaQua;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (int)item.iDonGia;
                db.CTDONHANGs.Add(ctDH);
                //db.NONGSANs.Add(ns);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "NongSan");
        }
    }
}