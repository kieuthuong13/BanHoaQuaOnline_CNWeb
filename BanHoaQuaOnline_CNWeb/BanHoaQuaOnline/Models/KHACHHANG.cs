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
        [Display(Name = "Mã khách hàng")]
        [Key]
        public int MaKhachHang { get; set; }

        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "{0} không được để trống!")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(100)]
        public string MatKhau { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(100)]
        public string DienThoai { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} không được để trống!")]
        [StringLength(100)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANGs { get; set; }
    }
}
