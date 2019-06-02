using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanHoaQuaOnline.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Models.QuanLyBanQua db = new Models.QuanLyBanQua();

        #region MY FUNCTION
        private bool CheckLogin()
        {
            try
            {
                Models.NHANVIEN nv = Session["ThongTinDangNhap"] as Models.NHANVIEN;
                if (db.NHANVIENs.Find(nv.MaNhanVien) != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        public ActionResult Index()
        {
            if (CheckLogin())
            {
                return View();
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        [HttpGet]
        public ActionResult LOGIN()
        {
            Session["ThongTinDangNhap"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult LOGIN(Models.NHANVIEN val)
        {
            if (val != null)
            {
                string password = db.Database.SqlQuery<string>("SELECT TOP 1 MatKhau FROM NHANVIEN WHERE TenDangNhap = N'" + val.TenDangNhap + "'").SingleOrDefault();
                if (string.Equals(password, val.MatKhau) && !string.IsNullOrWhiteSpace(password))
                {
                    Session["ThongTinDangNhap"] = db.Database.SqlQuery<Models.NHANVIEN>("SELECT TOP 1 * FROM NHANVIEN WHERE TenDangNhap = N'" + val.TenDangNhap + "'").SingleOrDefault();
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult NONGSAN()
        {
            if (CheckLogin())
            {
                return View(db.NONGSANs.ToList());
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        public ActionResult LOAINONGSAN()
        {
            if (CheckLogin())
            {
                return View(db.LOAINONGSANs.ToList());
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        public ActionResult NOISANXUAT()
        {
            if (CheckLogin())
            {
                return View(db.NOISANXUATs.ToList());
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        public ActionResult NHANVIEN()
        {
            if (CheckLogin())
            {
                return View(db.NHANVIENs.ToList());
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        public ActionResult KHACHHANG()
        {
            if (CheckLogin())
            {
                return View(db.KHACHHANGs.ToList());
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        public ActionResult DONHANG()
        {
            if (CheckLogin())
            {
                return View(db.DONHANGs.ToList());
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        public ActionResult CTDONHANG()
        {
            if (CheckLogin())
            {
                return View(db.CTDONHANGs.ToList());
            }
            return RedirectToAction("LOGIN", "Admin");
        }
        //Nông sản
        [HttpGet]
        public ActionResult _Edit_NONGSAN(string id)
        {
            if (CheckLogin())
            {
                // nếu không truyền dữ liệu vào biến id -> tạo mới bản ghi
                if (string.IsNullOrWhiteSpace(id))
                {
                    return View();
                }

                // còn nếu truyền dữ liệu vào biến id -> update bản ghi
                int tam = 0;
                if (int.TryParse(id, out tam))
                {
                    Models.NONGSAN val = db.Database.SqlQuery<Models.NONGSAN>("SELECT * FROM NONGSAN WHERE MaNongSan = " + tam).SingleOrDefault();
                    return View(val);
                }

                // ngoại lệ chưa xác định -> chuyển về trang danh sách NONGSAN
                return RedirectToAction("NONGSAN", "Admin");
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        [HttpPost]
        public ActionResult _Edit_NONGSAN(Models.NONGSAN _value = null)
        {
            // lấy thông tin đã thay đổi của NONGSAN từ "View Edit HttpPost NONGSAN"
            db.NONGSANs.AddOrUpdate(_value);
            db.SaveChanges();
            return RedirectToAction("NONGSAN", "Admin");
        }
        //xóa
        public ActionResult _Delete_NONGSAN(string id)
        {
            // xóa liên kết đến bảng NONGSAN
            db.Database.ExecuteSqlCommand("DELETE CTDONHANG WHERE MaNongSan = " + id);

            // xóa bản ghi NONGSAN
            db.Database.ExecuteSqlCommand("DELETE NONGSAN WHERE MaNongSan = " + id);

            db.SaveChanges();
            return RedirectToAction("NONGSAN", "Admin");
        }

        //Nơi sản xuất_Sửa_Thêm
        [HttpGet]
        public ActionResult _Edit_NOISANXUAT(string id)
        {
            if (CheckLogin())
            {
                // nếu không truyền dữ liệu vào biến id -> tạo mới bản ghi
                if (string.IsNullOrWhiteSpace(id))
                {
                    return View();
                }

                // còn nếu truyền dữ liệu vào biến id -> update bản ghi
                int tam = 0;
                if (int.TryParse(id, out tam))
                {
                    Models.NOISANXUAT val = db.Database.SqlQuery<Models.NOISANXUAT>("SELECT * FROM NOISANXUAT WHERE MaNoiSX = " + tam).SingleOrDefault();
                    return View(val);
                }

                // ngoại lệ chưa xác định -> chuyển về trang danh sách NOISANXUAT
                return RedirectToAction("NOISANXUAT", "Admin");
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        [HttpPost]
        public ActionResult _Edit_NOISANXUAT(Models.NOISANXUAT _value = null)
        {
            // lấy thông tin đã thay đổi của NOISANXUAT từ "View Edit HttpPost NOISANXUAT"
            db.NOISANXUATs.AddOrUpdate(_value);
            db.SaveChanges();
            return RedirectToAction("NOISANXUAT", "Admin");
        }

        //xóa
        public ActionResult _Delete_NOISANXUAT(string id)
        {
            // xóa liên kết đến bảng NONGSAN
            db.Database.ExecuteSqlCommand("DELETE NONGSAN WHERE MaNoiSX = " + id);

            // xóa bản ghi NOISANXUAT
            db.Database.ExecuteSqlCommand("DELETE NOISANXUAT WHERE MaNoiSX = " + id);

            db.SaveChanges();
            return RedirectToAction("NOISANXUAT", "Admin");
        }

        //Loại nông sản_Sửa_Thêm
        [HttpGet]
        public ActionResult _Edit_LOAINONGSAN(string id)
        {
            if (CheckLogin())
            {
                // nếu không truyền dữ liệu vào biến id -> tạo mới bản ghi
                if (string.IsNullOrWhiteSpace(id))
                {
                    return View();
                }

                // còn nếu truyền dữ liệu vào biến id -> update bản ghi
                int tam = 0;
                if (int.TryParse(id, out tam))
                {
                    Models.LOAINONGSAN val = db.Database.SqlQuery<Models.LOAINONGSAN>("SELECT * FROM LOAINONGSAN WHERE MaLoai = " + tam).SingleOrDefault();
                    return View(val);
                }

                // ngoại lệ chưa xác định -> chuyển về trang danh sách LOAINONGSAN
                return RedirectToAction("LOAINONGSAN", "Admin");
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        [HttpPost]
        public ActionResult _Edit_LOAINONGSAN(Models.LOAINONGSAN _value = null)
        {
            // lấy thông tin đã thay đổi của LOAINONGSAN từ "View Edit HttpPost LOAINONGSAN"
            db.LOAINONGSANs.AddOrUpdate(_value);
            db.SaveChanges();
            return RedirectToAction("LOAINONGSAN", "Admin");
        }

        //xóa
        public ActionResult _Delete_LOAINONGSAN(string id)
        {
            // xóa liên kết đến bảng NONGSAN
            db.Database.ExecuteSqlCommand("DELETE NONGSAN WHERE MaLoai = " + id);

            // xóa bản ghi LOAINONGSAN
            db.Database.ExecuteSqlCommand("DELETE LOAINONGSAN WHERE MaLoai = " + id);

            db.SaveChanges();
            return RedirectToAction("LOAINONGSAN", "Admin");
        }

        //Nhân viên_Sửa_Thêm
        [HttpGet]
        public ActionResult _Edit_NHANVIEN(string id)
        {
            if (CheckLogin())
            {
                // nếu không truyền dữ liệu vào biến id -> tạo mới bản ghi
                if (string.IsNullOrWhiteSpace(id))
                {
                    return View();
                }

                // còn nếu truyền dữ liệu vào biến id -> update bản ghi
                int tam = 0;
                if (int.TryParse(id, out tam))
                {
                    Models.NHANVIEN val = db.Database.SqlQuery<Models.NHANVIEN>("SELECT * FROM NHANVIEN WHERE MaNhanVien = " + tam).SingleOrDefault();
                    return View(val);
                }

                // ngoại lệ chưa xác định -> chuyển về trang danh sách NHANVIEN
                return RedirectToAction("NHANVIEN", "Admin");
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        [HttpPost]
        public ActionResult _Edit_NHANVIEN(Models.NHANVIEN _value = null)
        {
            // lấy thông tin đã thay đổi của NHANVIEN từ "View Edit HttpPost NHANVIEN"
            db.NHANVIENs.AddOrUpdate(_value);
            db.SaveChanges();
            return RedirectToAction("NHANVIEN", "Admin");
        }

        //xóa
        public ActionResult _Delete_NHANVIEN(string id)
        {
            // xóa liên kết đến bảng DONHANG
            db.Database.ExecuteSqlCommand("DELETE DONHANG WHERE MaNhanVien = " + id);

            // xóa bản ghi NHANVIEN
            db.Database.ExecuteSqlCommand("DELETE NHANVIEN WHERE MaNhanVien = " + id);

            db.SaveChanges();
            return RedirectToAction("NHANVIEN", "Admin");
        }

        //Khách hàng_Sửa_Thêm
        [HttpGet]
        public ActionResult _Edit_KHACHHANG(string id)
        {
            if (CheckLogin())
            {
                // nếu không truyền dữ liệu vào biến id -> tạo mới bản ghi
                if (string.IsNullOrWhiteSpace(id))
                {
                    return View();
                }

                // còn nếu truyền dữ liệu vào biến id -> update bản ghi
                int tam = 0;
                if (int.TryParse(id, out tam))
                {
                    Models.KHACHHANG val = db.Database.SqlQuery<Models.KHACHHANG>("SELECT * FROM KHACHHANG WHERE MaKhachHang = " + tam).SingleOrDefault();
                    return View(val);
                }

                // ngoại lệ chưa xác định -> chuyển về trang danh sách KHACHHANG
                return RedirectToAction("KHACHHANG", "Admin");
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        [HttpPost]
        public ActionResult _Edit_KHACHHANG(Models.KHACHHANG _value = null)
        {
            // lấy thông tin đã thay đổi của KHACHHANG từ "View Edit HttpPost KHACHHANG"
            db.KHACHHANGs.AddOrUpdate(_value);
            db.SaveChanges();
            return RedirectToAction("KHACHHANG", "Admin");
        }

        //xóa
        public ActionResult _Delete_KHACHHANGN(string id)
        {
            // xóa liên kết đến bảng KHACHHANG_NGANHANG
            //db.Database.ExecuteSqlCommand("DELETE KHACHHANG_NGANHANG WHERE MaKhachHang = " + id);

            // xóa bản ghi DONHANG
            db.Database.ExecuteSqlCommand("DELETE DONHANG WHERE MaKhachHang = " + id);
            // xóa bản ghi KHACHHANG
            db.Database.ExecuteSqlCommand("DELETE KHACHHANG WHERE MaKhachHang = " + id);

            db.SaveChanges();
            return RedirectToAction("KHACHHANG", "Admin");
        }

        //Đơn hàng_Sửa_Thêm
        [HttpGet]
        public ActionResult _Edit_DONHANG(string id)
        {
            if (CheckLogin())
            {
                // nếu không truyền dữ liệu vào biến id -> tạo mới bản ghi
                if (string.IsNullOrWhiteSpace(id))
                {
                    return View();
                }

                // còn nếu truyền dữ liệu vào biến id -> update bản ghi
                int tam = 0;
                if (int.TryParse(id, out tam))
                {
                    Models.DONHANG val = db.Database.SqlQuery<Models.DONHANG>("SELECT * FROM DONHANG WHERE MaHoaDon = " + tam).SingleOrDefault();
                    return View(val);
                }

                // ngoại lệ chưa xác định -> chuyển về trang danh sách DONHANG
                return RedirectToAction("DONHANG", "Admin");
            }
            return RedirectToAction("LOGIN", "Admin");
        }

        [HttpPost]
        public ActionResult _Edit_DONHANG(Models.DONHANG _value = null)
        {
            // lấy thông tin đã thay đổi của KHACHHANG từ "View Edit HttpPost DONHANG"
            db.DONHANGs.AddOrUpdate(_value);
            db.SaveChanges();
            return RedirectToAction("DONHANG", "Admin");
        }

        //xóa
        public ActionResult _Delete_DONHANG(string id)
        {
            // xóa bản ghi CTDONHANG
            db.Database.ExecuteSqlCommand("DELETE CTDONHANG WHERE MaHoaDon = " + id);

            // xóa bản ghi DONHANG
            db.Database.ExecuteSqlCommand("DELETE DONHANG WHERE MaHoaDon = " + id);

            db.SaveChanges();
            return RedirectToAction("DONHANG", "Admin");
        }
    }
}