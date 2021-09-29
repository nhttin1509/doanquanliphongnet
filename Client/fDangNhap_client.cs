using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class fDangNhap_client : Form
    {
        public fDangNhap_client()
        {
            InitializeComponent();
        }

        private void fDangNhap_client_Load(object sender, EventArgs e)
        {
            txtTenTaiKhoan.Focus();
        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenTaiKhoan.Text, pass = txtMatKhau.Text;
            using (DataPhongNetDataContext db = new DataPhongNetDataContext()) {

                var r = from a in db.TaiKhoans
                        where a.UserName == user
                        && a.Pass == pass 
                        select a; 
                if (r.Any())
                {
                    fUngDung_Client frmUngDung = new fUngDung_Client();
                    frmUngDung.getTen = txtTenTaiKhoan.Text;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
