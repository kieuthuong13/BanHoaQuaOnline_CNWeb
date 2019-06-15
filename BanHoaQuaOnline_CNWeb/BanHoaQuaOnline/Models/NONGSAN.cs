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

        [Key]
        public int MaNongSan { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNongSan { get; set; }

        [StringLength(100)]
        public string AnhMinhHoa { get; set; }

        public int? GiaBan { get; set; }

        [StringLength(100)]
        public string DonViTinh { get; set; }

        public int? SoLuongCon { get; set; }

        public DateTime? NgayNhap { get; set; }

        public int? NhietDoBaoQuan { get; set; }

        public int? MaLoai { get; set; }

        public int? MaNoiSX { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDONHANG> CTDONHANGs { get; set; }

        public virtual LOAINONGSAN LOAINONGSAN { get; set; }

        public virtual NOISANXUAT NOISANXUAT { get; set; }
    }
}
