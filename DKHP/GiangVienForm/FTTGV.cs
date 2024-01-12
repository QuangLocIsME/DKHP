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
    public partial class FTTGV : Form
    {
        DKHPEntities2 db = new DKHPEntities2();
        private int MaNguoiDung;
        public FTTGV(int MaNguoiDung)
        {
            this.MaNguoiDung = MaNguoiDung;
            InitializeComponent();
        }

        private void FTTGV_Load(object sender, EventArgs e)
        {
            var gv = db.GiangViens.Where(r => r.MaGV == MaNguoiDung).ToList();
            if (gv.Any())
            {
                var giangVien = gv.First();
                var khoa = giangVien.KHOA;
                txtmagv.Text = giangVien.MaGV.ToString();
                txttengv.Text = giangVien.HoTen.ToString();
                txtngaysinh.Text = giangVien.NgaySinh.ToShortDateString();
                txtgioitinh.Text = giangVien.GioiTinh.ToString();
                txtkhoa.Text = khoa.TenKhoa.ToString();

            }




        }

        private void txtmagv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
