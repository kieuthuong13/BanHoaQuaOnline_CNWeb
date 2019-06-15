namespace BanHoaQuaOnline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDONHANG")]
    public partial class CTDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaNongSan { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoaDon { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public virtual DONHANG DONHANG { get; set; }

        public virtual NONGSAN NONGSAN { get; set; }
    }
}
