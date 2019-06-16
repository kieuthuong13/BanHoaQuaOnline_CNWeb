namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [DisplayName("Mã hóa đơn")]
        [Key]
        public int MaHoaDon { get; set; }

        [DisplayName("Đã thanh toán")]
        public int? DaThanhToan { get; set; }

        [DisplayName("Tình trạng giao")]
        public int? TinhTrangGiao { get; set; }

        [DisplayName("Ngày đặt")]
        public DateTime? NgayDat { get; set; }

        [DisplayName("Ngày giao")]
        public DateTime? NgayGiao { get; set; }

        [DisplayName("Mã khách hàng")]
        public int? MaKhachHang { get; set; }

        [DisplayName("Mã nhân viên")]
        public int? MaNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
