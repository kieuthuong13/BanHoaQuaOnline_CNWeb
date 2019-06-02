namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONHANG")]
    public partial class DONHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONHANG()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }
        [Display(Name = "Mã hóa đơn")]
        [Key]
        public int MaHoaDon { get; set; }

        [Display(Name = "Đã thanh toán")]
        public int? DaThanhToan { get; set; }

        [Display(Name = "Tình trạng giao hàng")]
        public int? TinhTrangGiao { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime? NgayDat { get; set; }

        [Display(Name = "Ngày giao")]
        public DateTime? NgayGiao { get; set; }

        [Display(Name = "Mã khách hàng")]
        public int? MaKhachHang { get; set; }

        [Display(Name = "Mã nhân viên")]
        public int? MaNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
