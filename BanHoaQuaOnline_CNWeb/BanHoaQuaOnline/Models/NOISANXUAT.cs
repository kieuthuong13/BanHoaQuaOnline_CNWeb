namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NOISANXUAT")]
    public partial class NOISANXUAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NOISANXUAT()
        {
            NONGSANs = new HashSet<NONGSAN>();
        }
        [Display(Name = "Mã nơi sản xuất")]
        [Key]
        public int MaNoiSX { get; set; }

        [Display(Name = "Tên nơi sản xuất")]
        [StringLength(100)]
        public string TenNoiSX { get; set; }

        [Display(Name = "Quốc gia")]
        [StringLength(100)]
        public string QuocGia { get; set; }

        [Display(Name = "Số điẹn thoại")]
        [StringLength(100)]
        public string DienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NONGSAN> NONGSANs { get; set; }
    }
}
