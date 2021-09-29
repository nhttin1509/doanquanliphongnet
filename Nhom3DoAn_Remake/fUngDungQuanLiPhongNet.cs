using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom3DoAn_Remake
{
    public partial class fUngDungQuanLiPhongNet : Form
    {
        public fUngDungQuanLiPhongNet()
        {
            InitializeComponent();
            loadMayList();
            timer1.Start();
            btnSua1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.lbTime.Text = dt.ToLongTimeString().ToString() + "\n" + dt.ToShortDateString().ToString();
        }

        private void fUngDungQuanLiPhongNet_Load(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                    dtgvMay.DataSource = from a in db.MAYs select a;
            }
            btnSua1.Enabled = true;
        }

        private void btnXoaMay_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                
                    string user = dtgvMay.SelectedCells[0].OwningRow.Cells["Máy"].Value.ToString();
                    MAY delete = db.MAYs.Where(a => a.MAY1.Equals(user)).SingleOrDefault();
                    db.MAYs.DeleteOnSubmit(delete);
                db.SubmitChanges();
                MessageBox.Show("Đã xóa thành công", "Thông báo");
                loadMayList();
            }
        }

        private void dtgvMay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            fDichVu frmDichVu = new fDichVu();
            this.Hide();
            frmDichVu.ShowDialog();
            this.Show();
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            fChat frmChat = new fChat();
            this.Hide();
            frmChat.ShowDialog();
            this.Show();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan frmTk = new fTaiKhoan();
            this.Hide();
            frmTk.ShowDialog();
            this.Show();
        }

        private void fUngDungQuanLiPhongNet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnThemMay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMay.Text))
                return;

            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string loai = txtLoai.Text,
                      ten = txtMay.Text,
                      user = txtTaikhoan.Text,
                      gia="";
                if (loai == "THƯỜNG") gia = txtgThuong.Text;
                else if (loai == "VIP") gia = txtgVip.Text;
                MAY insert = new MAY();
                insert.LOAI = loai;
                insert.MAY1 = ten;
                insert.UserName = user;
                insert.GIA = gia;
              
                db.MAYs.InsertOnSubmit(insert);
                db.SubmitChanges();
            }
            MessageBox.Show("Đã tạo thành công", "Thông báo");
            loadMayList();
        }
       


        void loadMayList()
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                dtgvMay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvMay.DataSource = from a in db.MAYs
                                             select new
                                             {
                                                 Loại = a.LOAI,
                                                 Máy = a.MAY1,
                                                 Trạng_Thái = a.TRANGTHAI,
                                                 Tài_Khoản = a.UserName
                                             };
                
            }
        }

        private void txtgThuong_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void fUngDungQuanLiPhongNet_Shown(object sender, EventArgs e)
        {
          
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string may = dtgvMay.SelectedCells[0].OwningRow.Cells["MAY1"].Value.ToString();
                string loai = dtgvMay.SelectedCells[0].OwningRow.Cells["LOAI"].Value.ToString();

                MAY edit = db.MAYs.Where(a => a.MAY1.Equals(may)).SingleOrDefault();

                edit.MAY1 = may;
                edit.LOAI = loai;
                db.SubmitChanges();
                MessageBox.Show("Đã sửa thành công", "Thông báo");
                loadMayList();
            }
            btnSua1.Enabled = false;
        }
    }
}
