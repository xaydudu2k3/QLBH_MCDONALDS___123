﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace QLBH_MCDONALDS.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class QLCuaHangMcDonaldEntities : DbContext
{
    public QLCuaHangMcDonaldEntities()
        : base("name=QLCuaHangMcDonaldEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<ChiTietDonNhapHang> ChiTietDonNhapHangs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<DanhMucCheBien> DanhMucCheBiens { get; set; }

    public virtual DbSet<DonNhapHang> DonNhapHangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<LoaiSP> LoaiSPs { get; set; }

    public virtual DbSet<NguyenLieu> NguyenLieux { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

}

}

