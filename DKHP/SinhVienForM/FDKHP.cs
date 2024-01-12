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
    public partial class FDKHP : Form
    {
        DKHPEntities2 db = new DKHPEntities2();
        List<LopHocPhan> dslhp = new List<LopHocPhan>();
        List<DangKy> dsDK = new List<DangKy>();
        DangKy dangky;
        private int MaNguoiDung;
        public FDKHP(int MaNguoiDung)
        {
            this.MaNguoiDung = MaNguoiDung;
            InitializeComponent();
        }
        
        public void loadLHP(List<LopHocPhan> x)
        {
            DanhSach.Rows.Clear();
            DanhSach.Columns.Clear();
            //tao column bang code
            DanhSach.Columns.Add("MaHP", "Mã Học Phần");
            DanhSach.Columns.Add("TenHP", "Tên Học Phần");
            DanhSach.Columns.Add("SoTC", "Số Tín Chỉ");
            DanhSach.Columns.Add("SoTiet", "Số Tiết");
            DanhSach.Columns.Add("TKB", "Lịch Học");
            DanhSach.Columns.Add("SoSVHT", "Đã Đăng Ký");
            DanhSach.Columns.Add("SoSVTD", "Tối Đa");


            foreach (LopHocPhan a in x)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DanhSach);
                row.Cells[0].Value = a.MaHP.ToString();
                row.Cells[1].Value = a.TenHP;
                row.Cells[2].Value = a.SoTinChi;
                row.Cells[3].Value = a.SoTiet;
                row.Cells[4].Value = "Thứ:" + a.ThoiKhoaBieu1.Thu + "Tiết: " + a.ThoiKhoaBieu1.TietBatDau + "-" + a.ThoiKhoaBieu1.TietKetThuc;
                row.Cells[5].Value = a.SoSVHienTai;
                row.Cells[6].Value = a.SoSVToiDa;


                DanhSach.Rows.Add(row);
            }
        }
        public void loadLHPDK()
        {
            DanhSachDangKy.Rows.Clear();
            DanhSachDangKy.Columns.Clear();
            //tao column bang code
            DanhSachDangKy.Columns.Add("MaHP", "Mã Học Phần");
            DanhSachDangKy.Columns.Add("TenHP", "Tên Học Phần");
            DanhSachDangKy.Columns.Add("SoTC", "Số Tín Chỉ");
            DanhSachDangKy.Columns.Add("SoTiet", "Số Tiết");
            DanhSachDangKy.Columns.Add("TKB", "Lịch Học");
            DanhSachDangKy.Columns.Add("SoSVHT", "Đã Đăng Ký");
            DanhSachDangKy.Columns.Add("SoSVTD", "Tối Đa");

            var SinhVien = db.DangKies.Where(s => s.SinhVien.MaSV == MaNguoiDung);
            foreach (DangKy a in SinhVien)
            {

                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DanhSachDangKy);
                row.Cells[0].Value = a.MaHP.ToString();
                row.Cells[1].Value = a.LopHocPhan.TenHP;
                row.Cells[2].Value = a.LopHocPhan.SoTinChi;
                row.Cells[3].Value = a.LopHocPhan.SoTiet;
                row.Cells[4].Value = "Thứ:" + a.LopHocPhan.ThoiKhoaBieu1.Thu + "Tiết: " +
                    a.LopHocPhan.ThoiKhoaBieu1.TietBatDau + "-" + a.LopHocPhan.ThoiKhoaBieu1.TietKetThuc;
                row.Cells[5].Value = a.LopHocPhan.SoSVHienTai;
                row.Cells[6].Value = a.LopHocPhan.SoSVToiDa;


                DanhSachDangKy.Rows.Add(row);
            }
        }
        

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (DanhSach.CurrentRow != null)
            {
                DataGridViewRow selectedRow = DanhSach.Rows[DanhSach.CurrentRow.Index];
                string maHP = selectedRow.Cells["MaHP"].Value.ToString();

                if (!DaDangKy(maHP))
                {
                    LopHocPhan lopHocPhan = db.LopHocPhans.Find(int.Parse(maHP));
                    dangky = new DangKy();
                    dangky.MaHP = int.Parse(maHP);
                    dangky.MaSV = MaNguoiDung;
                    dangky.NamHoc = lopHocPhan.NamHoc;


                    db.DangKies.Add(dangky);
                    db.SaveChanges();

                    lopHocPhan.SoSVHienTai++;
                    db.SaveChanges();

                    loadLHP(dslhp);
                    loadLHPDK();
                    MessageBox.Show($"Đang ký thành công lớp học phần {lopHocPhan.TenHP}");
                }
                else
                {
                    MessageBox.Show("Bạn đã đăng ký lớp học phần này rồi.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp học phần để đăng ký.");
            }
        }
        private bool DaDangKy(string maHP)
        {
            int maSV = MaNguoiDung;
            int maHocPhan = int.Parse(maHP);
            return db.DangKies.Any(dk => dk.MaSV == maSV && dk.MaHP == maHocPhan && dk.NamHoc == DateTime.Now.Year);
        }
        private void btnHuyDK_Click(object sender, EventArgs e)
        {
           
        }

        private void FDKHP_Load(object sender, EventArgs e)
        {
            dslhp = db.LopHocPhans.ToList();
            loadLHP(dslhp);
            loadLHPDK();
        }

        private void DanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DanhSachDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHuyDK_Click_1(object sender, EventArgs e)
        {
            if (DanhSach.CurrentRow != null)
            {
                DataGridViewRow selectedRow = DanhSach.Rows[DanhSach.CurrentRow.Index];
                string maHP = selectedRow.Cells["MaHP"].Value.ToString();

                if (DaDangKy(maHP))
                {

                    int parsedMaHP = int.Parse(maHP);

                    var dangKy = db.DangKies
                        .Where(dk => dk.MaSV == MaNguoiDung && dk.MaHP == parsedMaHP && dk.NamHoc == DateTime.Now.Year)
                        .FirstOrDefault();
                    var relatedRecords = db.KetQuaHocTaps.Where(kq => kq.MaHP == parsedMaHP);
                    db.KetQuaHocTaps.RemoveRange(relatedRecords);

                    if (dangKy != null)
                    {
                        db.DangKies.Remove(dangKy);
                        db.SaveChanges();

                        LopHocPhan lopHocPhan = db.LopHocPhans.Find(int.Parse(maHP));
                        lopHocPhan.SoSVHienTai--;
                        db.SaveChanges();

                        loadLHP(dslhp);
                        loadLHPDK();

                        MessageBox.Show($"Đã hủy đăng ký cho mã học phần {maHP}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy đăng ký cho mã học phần {maHP}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa đăng ký lớp học phần này, không thể hủy đăng ký.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một lớp học phần để hủy đăng ký.");
            }
        }
    }
}
