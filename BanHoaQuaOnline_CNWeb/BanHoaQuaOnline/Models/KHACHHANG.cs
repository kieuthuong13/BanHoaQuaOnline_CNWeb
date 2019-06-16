namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [DisplayName ("Mã khách hàng")]
        [Key]
        public int MaKhachHang { get; set; }

        [DisplayName ("Tên khách hàng")]
        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [DisplayName("Tài khoản")]
        [StringLength(100)]
        public string TaiKhoan { get; set; }

        [DisplayName("Mật khẩu")]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [DisplayName("Điện thoại")]
        [StringLength(100)]
        public string DienThoai { get; set; }

        [DisplayName("Địa chỉ")]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
