using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Ictshop.Models
{
    public partial class Qlbanhang : DbContext
    {
        public Qlbanhang()
            : base("name=Qlbanhang1")
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Hangsanxuat> Hangsanxuats { get; set; }
        public virtual DbSet<Hedieuhanh> Hedieuhanhs { get; set; }
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietdonhang>()
                .Property(e => e.Dongia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Chitietdonhang>()
                .Property(e => e.Thanhtien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donhang>()
                .HasMany(e => e.Chitietdonhangs)
                .WithRequired(e => e.Donhang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hangsanxuat>()
                .Property(e => e.Tenhang)
                .IsFixedLength();

            modelBuilder.Entity<Hedieuhanh>()
                .Property(e => e.Tenhdh)
                .IsFixedLength();

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Dienthoai)
                .IsFixedLength();

            modelBuilder.Entity<Nguoidung>()
                .Property(e => e.Matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Giatien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Chitietdonhangs)
                .WithRequired(e => e.Sanpham)
                .WillCascadeOnDelete(false);
        }
    }
}
