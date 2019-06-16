namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            DONHANGs = new HashSet<DONHANG>();
        }

        [DisplayName("Mã nhân viên")]
        [Key]
        public int MaNhanVien { get; set; }

        [DisplayName("Tên nhân viên")]
        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [DisplayName("Tên đăng nhập")]
        [StringLength(100)]
        public string TenDangNhap { get; set; }

        [DisplayName("Mật khẩu")]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [DisplayName("Giới tính")]
        [StringLength(100)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string SoCMND { get; set; }

        [DisplayName("Điện thoại")]
        [StringLength(100)]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
