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
        DKHPEntities db = new DKHPEntities();
        private int MaNguoiDung;
        public FGV(int MaNguoiDung)
        {
            InitializeComponent();
        }

        private void FGV_Load(object sender, EventArgs e)
        {
           
        }
    }
}
