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
        DKHPEntities db = new DKHPEntities();
        private int MaNguoiDung;
        public FTrangchu(int MaNguoiDung)
        {

            this.MaNguoiDung = MaNguoiDung;
            InitializeComponent();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {

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

    }
}
