namespace Ictshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaAdmin { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Matkhau { get; set; }
    }
}
