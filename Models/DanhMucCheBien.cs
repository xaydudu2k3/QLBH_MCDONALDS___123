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
    using System.Collections.Generic;
    
    public partial class DanhMucCheBien
    {
        public string MaNL { get; set; }
        public string MaSP { get; set; }
        public Nullable<double> DonViChuyenDoi { get; set; }
    
        public virtual NguyenLieu NguyenLieu { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
