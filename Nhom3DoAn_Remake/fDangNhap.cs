using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom3DoAn_Remake
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
            txtTenTaiKhoan.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenTaiKhoan.Text, pass = txtMatKhau.Text;
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                var r = from a in db.ADMINs
                        where a.UserName == user
                        && a.Pass == pass
                        select a;
                if (r.Any())
                {
                    fUngDungQuanLiPhongNet frmUngDung = new fUngDungQuanLiPhongNet();
                    this.Hide();
                    frmUngDung.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenTaiKhoan.Clear();
                    txtMatKhau.Clear();
                    txtTenTaiKhoan.Focus();
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
