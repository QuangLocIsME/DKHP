using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKHP
{
    public partial class FTrangchu : Form
    {
        DKHPEntities2 db = new DKHPEntities2();
        private int MaNguoiDung;
        public FTrangchu(int MaNguoiDung)
        {

            this.MaNguoiDung = MaNguoiDung;
            InitializeComponent();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin flogin = new FLogin();
            flogin.ShowDialog();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            FThongtinSV FTTSV = new FThongtinSV(MaNguoiDung);
            loadForm(FTTSV);
            txtname.Text = "Student information";
        }

        private void FTrangchu_Load(object sender, EventArgs e)
        {

        }
        public void loadForm(Form formToShow)
        {
            formToShow.TopLevel = false;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Dock = DockStyle.Fill;
            panelformshow.Controls.Clear();
            panelformshow.Controls.Add(formToShow);
            formToShow.Show();

        }
        private void main_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndiem_Click(object sender, EventArgs e)
        {
            FKetQuaHocTap fdiem = new FKetQuaHocTap(MaNguoiDung);
            loadForm(fdiem);
            txtname.Text = "Grade";
        }

        private void btntkb_Click(object sender, EventArgs e)
        {
            FTKB ftkb = new FTKB(MaNguoiDung);
            loadForm(ftkb);
            txtname.Text = "Time Table";
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin flogin = new FLogin();
            flogin.ShowDialog();
        }

        private void btndkhp_Click(object sender, EventArgs e)
        {
            FDKHP fdkhp = new FDKHP(MaNguoiDung);
            loadForm(fdkhp);
            txtname.Text = "Course Registration";
        }
    }
}
