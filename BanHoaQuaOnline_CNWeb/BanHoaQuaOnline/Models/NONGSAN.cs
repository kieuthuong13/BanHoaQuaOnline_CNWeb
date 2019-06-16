namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [DisplayName ("Mã nông sản")]
        [Key]
        public int MaNongSan { get; set; }

        [DisplayName ("Tên nông sản")]
        [Required]
        [StringLength(100)]
        public string TenNongSan { get; set; }

        [DisplayName ("Ảnh minh họa")]
        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        [DisplayName ("Giá bán")]
        public int? GiaBan { get; set; }

        [DisplayName ("Đơn vị tính")]
        [StringLength(100)]
        public string DonViTinh { get; set; }

        [DisplayName("Số lượng còn")]
        public int? SoLuongCon { get; set; }

        [DisplayName("Ngày nhập")]
        public DateTime? NgayNhap { get; set; }

        [DisplayName("Nhiệt độ bảo quản")]
        public int? NhietDoBaoQuan { get; set; }

        [DisplayName("Mã loại")]
        public int? MaLoai { get; set; }

        [DisplayName("Mã nơi sản xuất")]
        public int? MaNoiSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual LOAINONGSAN LOAINONGSAN { get; set; }

        public virtual NOISANXUAT NOISANXUAT { get; set; }
    }
}
