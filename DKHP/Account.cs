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
    
    public partial class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int MaNguoiDung { get; set; }
    
        public virtual SinhVien SinhVien { get; set; }
        public virtual GiangVien GiangVien { get; set; }
        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}
