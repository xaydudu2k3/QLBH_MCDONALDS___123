
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
    
public partial class HoaDon
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public HoaDon()
    {

        this.ChiTietHoaDons = new HashSet<ChiTietHoaDon>();

    }


    public string MaHoaDon { get; set; }

    public Nullable<System.DateTime> NgayLapHD { get; set; }

    public Nullable<int> TrangThai { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

}

}
