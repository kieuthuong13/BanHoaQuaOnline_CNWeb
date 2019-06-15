using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanHoaQuaOnline.Models
{
    public class GioHang
    {
        QuanLyBanQua db = new QuanLyBanQua();
        public int idMaQua { get; set; }
        public string iTenSP { get; set; }
        public string iHinhAnh { get; set; }
        public int iDonGia { get; set; }
        public int iSoLuong { get; set; }
        public int ThanhTien
        {
            get { return iSoLuong * iDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MaSach)
        {
            idMaQua = MaSach;
            NONGSAN qua = db.NONGSANs.Single(n => n.MaNongSan == idMaQua);
            iTenSP = qua.TenNongSan;
            iHinhAnh = qua.AnhMinhHoa;
            iDonGia = int.Parse(qua.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}