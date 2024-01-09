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
    public partial class FDiem : Form
    {
        DKHPEntities db = new DKHPEntities();
        private int MaNguoiDung;
        List<SinhVien> dssv = new List<SinhVien>();
        List<KetQuaHocTap> danhSachDiem = new List<KetQuaHocTap>();
        KetQuaHocTap ketQuaHocTap = null;
        public FDiem(int MaNguoiDung)
        {
            InitializeComponent();
            this.MaNguoiDung = MaNguoiDung;
        }

        private void FDiem_Load(object sender, EventArgs e)
        {

        }
        public void LoadDiem(List<KetQuaHocTap> x) 
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


            var lopHocPhanCuaGiangVienIds = db.GiangViens
                .Where(gv => gv.MaGV == MaNguoiDung)
                .SelectMany(gv => gv.Days.Select(day => day.LopHocPhan.MaHP))
                .ToList();

            var ketQuaHocTapList = db.KetQuaHocTaps
                .Where(kq => lopHocPhanCuaGiangVienIds.Contains(kq.DangKy.LopHocPhan.MaHP))
                .ToList();
            foreach (var a in ketQuaHocTapList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DanhSach);
                row.Cells[0].Value = a.MaSV.ToString();
                row.Cells[1].Value = a.DangKy.SinhVien.HoTen;
                row.Cells[2].Value = a.DangKy.LopHocPhan.TenHP.ToString();
                //row.Cells[3].Value = a.NamHoc.ToString+ a.DangKy.LopHocPhan.HocKy;
                row.Cells[3].Value = a.NamHoc.ToString() + " Học Kì " + a.DangKy.LopHocPhan.HocKy;
                row.Cells[4].Value = a.DiemKT.ToString();
                row.Cells[5].Value = a.DiemGK.ToString();
                row.Cells[6].Value = a.DiemCK.ToString();
                row.Cells[7].Value = a.DiemTB.ToString();

                DanhSach.Rows.Add(row);
            }
        }
    }
}
