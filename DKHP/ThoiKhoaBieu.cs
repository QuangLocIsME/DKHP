//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DKHP
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThoiKhoaBieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThoiKhoaBieu()
        {
            this.LopHocPhans = new HashSet<LopHocPhan>();
        }
    
        public int MaTKB { get; set; }
        public int Thu { get; set; }
        public int TietBatDau { get; set; }
        public int SoTiet { get; set; }
        public string PhongHoc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHocPhan> LopHocPhans { get; set; }
    }
}