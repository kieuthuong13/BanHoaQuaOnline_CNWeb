namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHACHHANG")]
    public partial class KHACHHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACHHANG()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [Key]
        public int MaKhachHang { get; set; }

        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string DienThoai { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
