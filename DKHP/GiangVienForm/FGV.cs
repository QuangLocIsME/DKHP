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
    public partial class FGV : Form
    {
        DKHPEntities2 db = new DKHPEntities2();
        private int MaNguoiDung;
        public FGV(int MaNguoiDung)
        {
            InitializeComponent();
            this.MaNguoiDung = MaNguoiDung;
        }

        private void FGV_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FTTGV fttgv = new FTTGV(MaNguoiDung);
            loadForm(fttgv);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FChinhDiem fdiem = new FChinhDiem(MaNguoiDung);
            loadForm(fdiem);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            GVTKB fTKBGV = new GVTKB(MaNguoiDung);
            loadForm(fTKBGV);
        }
        public void loadForm(Form formToShow)
        {
            formToShow.TopLevel = false;
            formToShow.FormBorderStyle = FormBorderStyle.None;
            formToShow.Dock = DockStyle.Fill;
            main.Controls.Clear();
            main.Controls.Add(formToShow);
            formToShow.Show();

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FLogin flogin = new FLogin();
            flogin.ShowDialog();
        }
    }
}
