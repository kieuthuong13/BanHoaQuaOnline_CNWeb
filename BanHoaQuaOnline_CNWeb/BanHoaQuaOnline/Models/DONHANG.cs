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

        [Key]
        public int MaHoaDon { get; set; }

        public int? DaThanhToan { get; set; }

        public int? TinhTrangGiao { get; set; }

        public DateTime? NgayDat { get; set; }

        public DateTime? NgayGiao { get; set; }

        public int? MaKhachHang { get; set; }

        public int? MaNhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
