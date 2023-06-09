namespace Ictshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donhang")]
    public partial class Donhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donhang()
        {
            Chitietdonhangs = new HashSet<Chitietdonhang>();
        }

        [Key]
        public int Madon { get; set; }

        public DateTime? Ngaydat { get; set; }

        public int? Tinhtrang { get; set; }

        public int? MaNguoidung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }

        public virtual Nguoidung Nguoidung { get; set; }
    }
}
