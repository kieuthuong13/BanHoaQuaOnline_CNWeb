namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAINONGSAN")]
    public partial class LOAINONGSAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAINONGSAN()
        {
            NONGSANs = new HashSet<NONGSAN>();
        }

        [Key]
        public int MaLoai { get; set; }

        [StringLength(100)]
        public string TenLoai { get; set; }

        [StringLength(1000)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NONGSAN> NONGSANs { get; set; }
    }
}
