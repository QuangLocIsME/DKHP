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
    public partial class FSuaDiem : Form
    {

        DKHPEntities2 db = new DKHPEntities2();
        List<KetQuaHocTap> danhSachDiem = new List<KetQuaHocTap>();

        KetQuaHocTap ketQuaHocTap = null;
        private string MaSV;
        private string TenHP;
        private DataGridView DanhSach;
        public FSuaDiem(string MaSV, string TenHP, DataGridView DanhSach)
        {
            InitializeComponent();
            this.MaSV = MaSV;
            this.TenHP = TenHP;
            this.DanhSach = DanhSach;
        }

        private void txtName_Click(object sender, EventArgs e)
        {

        }

        private void FSuaDiem_Load(object sender, EventArgs e)
        {
            LopHocPhan lopHocPhan = db.LopHocPhans.FirstOrDefault(s => s.TenHP.ToString() == TenHP);
            SinhVien sinhVien = db.SinhViens.FirstOrDefault(sv => sv.MaSV.ToString() == MaSV.ToString());
            if (sinhVien != null)
            {
                string tenSv = sinhVien.HoTen;
                string TenHP = lopHocPhan.TenHP.ToString();
                txtName.Text = tenSv;
                txtLophocPhan.Text = TenHP;
            }

            KetQuaHocTap ketQuaHocTap = db.KetQuaHocTaps.FirstOrDefault(kq => kq.MaSV == sinhVien.MaSV && kq.DangKy.LopHocPhan.TenHP.ToString() == TenHP);

            if (ketQuaHocTap != null)
            {
                txtDiemKT.Text = ketQuaHocTap.DiemKT.ToString();
                txtDiemGK.Text = ketQuaHocTap.DiemGK.ToString();
                txtDiemCK.Text = ketQuaHocTap.DiemCK.ToString();
            }

            txtDiemKT.Focus();
        }

        private void btnLưu_Click(object sender, EventArgs e)
        {
            decimal diemKT = decimal.Parse(txtDiemKT.Text);
            decimal diemGK = decimal.Parse(txtDiemGK.Text);
            decimal diemCK = decimal.Parse(txtDiemCK.Text);
            if (diemKT < 0 || diemKT > 10 || diemGK < 0 || diemGK > 10 || diemCK < 0 || diemCK > 10)
            {
                MessageBox.Show("Điểm nhập vào không hợp lệ . Vui lòng nhập lại (0-10)!");
                return;
            }

            SinhVien sinhVien = db.SinhViens.FirstOrDefault(sv => sv.MaSV.ToString() == MaSV.ToString());
            KetQuaHocTap ketQuaHocTap = db.KetQuaHocTaps.FirstOrDefault(kq => kq.MaSV == sinhVien.MaSV && kq.DangKy.LopHocPhan.TenHP.ToString() == TenHP);
            ketQuaHocTap.DiemKT = decimal.Parse(txtDiemKT.Text);
            ketQuaHocTap.DiemGK = decimal.Parse(txtDiemGK.Text);
            ketQuaHocTap.DiemCK = decimal.Parse(txtDiemCK.Text);

            db.SaveChanges();
            this.Close();

            danhSachDiem = db.KetQuaHocTaps.ToList();
            loadDiem(DanhSach, danhSachDiem);

            DanhSach.Refresh();
        }
        public void loadDiem(DataGridView danhSach, List<KetQuaHocTap> x)
        {
            DanhSach.Rows.Clear();
            DanhSach.Columns.Clear();
            //tao column bang code
            DanhSach.Columns.Add("MaSV", "Mã Sinh Viên");
            DanhSach.Columns.Add("HoTen", "Tên Sinh Viên");
            DanhSach.Columns.Add("LopHocPhan", "Lớp Học Phần");
            DanhSach.Columns.Add("NamHoc", "Năm Học");
            DanhSach.Columns.Add("DiemKT", "Điểm Kiểm Tra");
            DanhSach.Columns.Add("DiemGK", "Điểm Giữa Kì");
            DanhSach.Columns.Add("DiemCK", "Điểm Cuối Kì");
            DanhSach.Columns.Add("DiemTB", "DiemTB");



            foreach (KetQuaHocTap a in x)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DanhSach);
                row.Cells[0].Value = a.MaSV.ToString();
                row.Cells[1].Value = a.DangKy.SinhVien.HoTen;
                row.Cells[2].Value = a.DangKy.LopHocPhan.TenHP.ToString();
                row.Cells[3].Value = a.NamHoc.ToString();
                row.Cells[4].Value = a.DiemKT.ToString();
                row.Cells[5].Value = a.DiemGK.ToString();
                row.Cells[6].Value = a.DiemCK.ToString();
                row.Cells[7].Value = a.DiemTB.ToString();

                DanhSach.Rows.Add(row);
            }
        }
    }
}
