namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NONGSAN")]
    public partial class NONGSAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NONGSAN()
        {
            CTDONHANGs = new HashSet<CTDONHANG>();
        }
        [Display(Name = "Mã nông sản")]
        [Key]
        public int MaNongSan { get; set; }

        [Display(Name = "Tên nông sản")]
        [StringLength(100)]
        public string TenNongSan { get; set; }

        [Display(Name = "Ảnh minh họa")]
        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        [Display(Name = "Giá bán")]
        public int? GiaBan { get; set; }

        [Display(Name = "Đơn vị tính")]
        [StringLength(100)]
        public string DonViTinh { get; set; }

        [Display(Name = "Số lượng còn")]
        public int? SoLuongCon { get; set; }

        [Display(Name = "Ngày nhập")]
        public DateTime? NgayNhap { get; set; }

        [Display(Name = "Nhiệt độ bảo quản")]
        public int? NhietDoBaoQuan { get; set; }

        [Display(Name = "Mã loại")]
        public int? MaLoai { get; set; }

        [Display(Name = "Mã nơi sản xuất")]
        public int? MaNoiSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual LOAINONGSAN LOAINONGSAN { get; set; }

        public virtual NOISANXUAT NOISANXUAT { get; set; }
    }
}
