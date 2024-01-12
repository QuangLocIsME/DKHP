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
    public partial class GVTKB : Form
    {
        DKHPEntities2 db = new DKHPEntities2();
        private int MaNguoiDung;
        public GVTKB(int MaNguoiDung)
        {
            InitializeComponent();
            this.MaNguoiDung = MaNguoiDung;
        }

        private void GVTKB_Load(object sender, EventArgs e)
        {
            loadTKB();

        }
        public void loadTKB()
        {

            DanhSach.Rows.Clear();
            DanhSach.Columns.Clear();

            DanhSach.Columns.Add("MonHoc", "Môn Học");
            DanhSach.Columns.Add("Thu", "Thứ");
            DanhSach.Columns.Add("Tiet", "Tiết");
            DanhSach.Columns.Add("Room", "Phòng Học");

            var gv = db.GiangViens.Where(g => g.MaGV == MaNguoiDung).ToList();

            foreach (var a in gv)
            {
                foreach (var day in a.Days)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DanhSach);

                    row.Cells[0].Value = day.LopHocPhan.TenHP;
                    row.Cells[1].Value = day.LopHocPhan.ThoiKhoaBieu1.Thu.ToString();
                    row.Cells[2].Value = day.LopHocPhan.ThoiKhoaBieu1.TietBatDau + "-" + day.LopHocPhan.ThoiKhoaBieu1.TietKetThuc;
                    row.Cells[3].Value = day.LopHocPhan.ThoiKhoaBieu1.PhongHoc;

                    DanhSach.Rows.Add(row);
                }
            }
        }
    }
}
