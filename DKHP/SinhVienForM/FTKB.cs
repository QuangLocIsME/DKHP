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
    public partial class FTKB : Form
    {
        DKHPEntities2 db = new DKHPEntities2();
        List<LopHocPhan> dslhp = new List<LopHocPhan>();
        private int MaNguoiDung;
        public FTKB(int MaNguoiDung)
        {
            this.MaNguoiDung = MaNguoiDung;
            InitializeComponent();
        }
        public void loadTKB(List<LopHocPhan> lhp)
        {

            DanhSach.Rows.Clear();
            DanhSach.Columns.Clear();

            DanhSach.Columns.Add("MonHoc", "Môn Học");
            DanhSach.Columns.Add("Thu", "Thứ");
            DanhSach.Columns.Add("Tiet", "Tiết");
            DanhSach.Columns.Add("Room", "Phòng Học");

            var sv = db.DangKies.Where(s => s.MaSV == MaNguoiDung).ToList();

            foreach (var a in sv)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DanhSach);

                row.Cells[0].Value = a.LopHocPhan.TenHP.ToString();
                row.Cells[1].Value = a.LopHocPhan.ThoiKhoaBieu1.Thu.ToString();
                row.Cells[2].Value = a.LopHocPhan.ThoiKhoaBieu1.TietBatDau + "-" + a.LopHocPhan.ThoiKhoaBieu1.TietKetThuc;
                row.Cells[3].Value = a.LopHocPhan.ThoiKhoaBieu1.PhongHoc;

                DanhSach.Rows.Add(row);
            }
        }
        public void loadCmbHocKi()
        {
            var hocKiValues = db.LopHocPhans.Select(x => x.HocKy).ToList();
            cmbHocKi.DataSource = hocKiValues;

            if (hocKiValues.Count > 0)
            {
                cmbHocKi.SelectedIndex = 0;
            }
        }
        public void loadCmbNamHoc()
        {
            var namHocValues = db.LopHocPhans.Select(x => x.NamHoc).ToList();
            cmbNamHoc.DataSource = namHocValues;

            if (namHocValues.Count > 0)
            {
                cmbNamHoc.SelectedIndex = 0;
            }
        }
        public void hocKi()
        {
            if (cmbHocKi.SelectedIndex != -1)
            {
                string selectedHocKi = cmbHocKi.SelectedItem.ToString();

                List<LopHocPhan> lhp = db.LopHocPhans
                    .Where(a => a.HocKy.ToString() == selectedHocKi)
                    .ToList();

                loadTKB(lhp);
            }
        }
        public void namHoc()
        {
            if (cmbNamHoc.SelectedIndex != -1)
            {
                string selectedNamHoc = cmbNamHoc.SelectedItem.ToString();

                List<LopHocPhan> lhp = db.LopHocPhans
                    .Where(a => a.NamHoc.ToString() == selectedNamHoc)
                    .ToList();

                loadTKB(lhp);
            }
        }

        private void FTKB_Load(object sender, EventArgs e)
        {
            loadTKB(new List<LopHocPhan>());
            loadCmbHocKi();
            loadCmbNamHoc();
        }
        private void cmbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            hocKi();
        }
        private void cmbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            namHoc();
        }
    }
}
