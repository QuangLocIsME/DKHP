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
    public partial class FLogin : Form
    {
        DKHPEntities db = new DKHPEntities();
        public FLogin()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            txtUser.TabIndex = 1;
            txtPassword.TabIndex = 2;
            btnlogin.TabIndex = 3;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUser.Text) || !string.IsNullOrWhiteSpace(txtUser.Text))
            {
                if (!string.IsNullOrEmpty(txtPassword.Text) || !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    if (db.Accounts.Any(u => u.Username == txtUser.Text
                    && u.Password == txtPassword.Text))
                    {
                        var user = db.Accounts.FirstOrDefault(u => u.Username == txtUser.Text && u.Password == txtPassword.Text);
                        if (user != null && user.Role == 3)
                        {

                            MessageBox.Show($"Sinh viên đăng nhập thành công");
                            FTrangchu ftrangchu = new FTrangchu(user.MaNguoiDung);
                            this.Hide();
                            ftrangchu.ShowDialog();

                        }
                        if (user != null && user.Role == 1)
                        {
                            MessageBox.Show($"Admin đăng nhập thành công ");
                            FKhoa fKhoa = new FKhoa();
                            this.Hide();
                            fKhoa.ShowDialog();
                        }
                        if (user != null && user.Role == 2)
                        {
                            MessageBox.Show($"Giảng viên nhập thành công  ");
                            FGV fgv = new FGV(user.MaNguoiDung);
                            this.Hide();
                            fgv.ShowDialog();
                        }


                    }
                    else if (db.Accounts.Any(u => u.Username == txtUser.Text))
                    {
                        if (db.Accounts.Any(p => p.Password != txtPassword.Text))
                        {
                            MessageBox.Show("Vui lòng kiểm tra lại mật khẩu , mật khẩu không hợp lệ !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại username , username không hợp lệ");

                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập hợp lệ !");
            }
        }

        private void btnlogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked) 
            {
                DKHP.Properties.Settings.Default.UserName = txtUser.Text;
                DKHP.Properties.Settings.Default.UserName = txtPassword.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUser.Text = DKHP.Properties.Settings.Default.UserName;
            txtPassword.Text = DKHP.Properties.Settings.Default.Password;
        }
    }
}
