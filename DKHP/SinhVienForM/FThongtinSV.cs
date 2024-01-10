using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKHP
{
    public partial class FThongtinSV : Form
    {
        DKHPEntities2 db = new DKHPEntities2();
        private int MaNguoiDung;
        public FThongtinSV(int MaNguoiDung)
        {
            this.MaNguoiDung = MaNguoiDung;
            InitializeComponent();
        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void FThongtinSV_Load(object sender, EventArgs e)
        {
            var sv = db.SinhViens.FirstOrDefault(s => s.MaSV == MaNguoiDung);
            if (sv != null)
            {
                txtmasinhvien.Text = sv.MaSV.ToString();
                txttensinhvien.Text = sv.HoTen;
                txtdiachi.Text = sv.DiaChi;
                txtngaysinh.Text = sv.NgaySinh.ToString();
                txtgioitinh.Text = sv.GioiTinh;
                txtquequan.Text = sv.QueQuan;
                var khoa = db.KHOAs.FirstOrDefault(s => s.MaKhoa == sv.MaKhoa);
                txttenkhoa.Text = khoa.TenKhoa;
                var lop = db.Lops.FirstOrDefault(s => s.MaLop == sv.MaLop);
                txttenlop.Text = lop.TenLop;
            }

        }
    }
}
