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
    
    public partial class Lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lop()
        {
            this.SinhViens = new HashSet<SinhVien>();
        }
    
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public Nullable<int> MaNganh { get; set; }
        public Nullable<int> GiangVien { get; set; }
    
        public virtual GiangVien GiangVien1 { get; set; }
        public virtual Nganh Nganh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
