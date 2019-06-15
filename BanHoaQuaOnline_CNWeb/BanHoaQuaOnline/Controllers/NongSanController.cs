using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BanHoaQuaOnline.Models;


namespace BanHoaQuaOnline.Controllers
{
    public class NongSanController : Controller
    {
        QuanLyBanQua db = new QuanLyBanQua();
        // GET: NongSan
        public ActionResult Index(int? page)
        {
            //tạo biến số sản phẩm trên trang
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.NONGSANs.OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult HoaQuaNhap(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.NONGSANs.Where(n => n.MaLoai == 1).OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult HoaQuaDacSan(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.NONGSANs.Where(n => n.MaLoai == 2).OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult RauCuSach(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.NONGSANs.Where(n => n.MaLoai == 3).OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DoKho(int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(db.NONGSANs.Where(n => n.MaLoai == 4).OrderBy(n => n.TenNongSan).ToPagedList(pageNumber, pageSize));
        }
        public PartialViewResult LoaiMoiPartial()
        {
            var lstLoaiMoi = db.LOAINONGSANs.Take(4).ToList();
            return PartialView(lstLoaiMoi);
        }

        //public PartialViewResult QuaMoiPartial()
        //{
        //    //cách 1 :
        //    //List<NONGSAN> lst = db.NONGSANs.ToList();

        //    //cách 2 : 
        //    //List<NONGSAN> lst = db.Database.SqlQuery<NONGSAN>("Select + From NongSan").ToList();

        //    //cách của Thương
        //    var lstQuaMoi = db.NONGSANs.Take(10).ToList();
        //    return PartialView(lstQuaMoi);
        //}

        //public PartialViewResult QuaMoiDSPartial()
        //{
        //    return PartialView(db.NONGSANs.Where(n => n.MaLoai == 2).ToList());
        //}

        //public PartialViewResult QuaMoiNhapPartial()
        //{
        //    return PartialView(db.NONGSANs.Where(n => n.MaLoai == 1).ToList());
        //}

        //public PartialViewResult RauCuPartial()
        //{
        //    return PartialView(db.NONGSANs.Where(n => n.MaLoai == 3).ToList());
        //}

        //public PartialViewResult DoKhoPartial()
        //{
        //    return PartialView(db.NONGSANs.Where(n => n.MaLoai == 4).ToList());
        //}

        public PartialViewResult QuaBanChayPartial()
        {
            var lstQuaMoi = db.NONGSANs.Take(3).ToList();
            return PartialView(lstQuaMoi);
        }



        //ví dụ của thầy

        public ActionResult List()
        {
            List<NONGSAN> lst = db.Database.SqlQuery<NONGSAN>("select + " +
            "From nongsan pro" + "Left join ").ToList<NONGSAN>();
            return View(lst);
        }
        //thên
        public ActionResult Add(NONGSAN cat)
        {
            db.NONGSANs.Add(cat);
            db.SaveChanges();
            return View();
        }
        //sửa
        public ActionResult Edit(NONGSAN cat)
        {
            NONGSAN ns = db.NONGSANs.Find(cat.MaNongSan);
            ns.TenNongSan = cat.TenNongSan;

            db.SaveChanges();
            return View();
        }
        //xóa
        public ActionResult Delete(int cat)
        {
            NONGSAN ns = db.NONGSANs.Find(cat);
            db.NONGSANs.Remove(ns);
            return View();
        }
    }
}