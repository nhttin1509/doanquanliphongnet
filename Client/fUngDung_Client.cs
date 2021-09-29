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
    public partial class fUngDung_Client : Form
    {
        private int a, b, c=99;
        public fUngDung_Client()
        {
            InitializeComponent();
            timer1.Start();
        }

        public string getTen;

        private void fUngDung_Client_Load(object sender, EventArgs e)
        {

        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            fChat_Client fChat = new fChat_Client();

            this.Hide();
            fChat.ShowDialog();
            this.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            fDichVu_Client fDich = new fDichVu_Client();
            this.Hide();
            fDich.ShowDialog();
            this.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void fUngDung_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fUngDung_Client_Shown(object sender, EventArgs e)
        {

            txtNguoidung.Text = getTen;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /* a = int.Parse(lbGiay.Text); //miligiay
             b = int.Parse(lbGiay.Text); //giay
             c = int.Parse(lbPhut.Text); //phut*/
            a = 0;
            b = 0;
           // c = 0;
            a--;
            if (a < 0)
            {
                a = 59;
                b--;
                if (b < 0)
                {
                    b = 59;
                    c--;
                }
            }
            if (a < 10)
            {
                lbGiay.Text = "0" + a;
            }
            else
                lbGiay.Text = a + "";
            if (b < 10)
            {
                lbGiay.Text = "0" + b;
            }
            else
                lbGiay.Text = b + "";
            if (c < 10)
            {
                lbPhut.Text = "0" + c;
            }
            else
                lbPhut.Text = c + "";

            if (a == 0 && b == 0 && c == 0)
            {
                timer1.Stop();
                MessageBox.Show("Hết giờ");
            }
        }
    }
}

