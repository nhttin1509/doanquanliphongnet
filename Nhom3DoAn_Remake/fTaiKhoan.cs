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
    public partial class fTaiKhoan : Form
    {
        public fTaiKhoan()
        {
            InitializeComponent();
            btnSua1.Enabled = false;
        }


        void LoadAccountList()
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                dtgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (rdKhach.Checked)
                {
                    dtgvAccount.DataSource = from a in db.TaiKhoans
                                             select new
                                             {
                                                 Tài_Khoản = a.UserName,
                                                 Mật_Khẩu = a.Pass,
                                                 a.SDT,
                                                 a.CMND,
                                                 TIền = a.TIEN,
                                             };
                }
                else
                {
                    dtgvAccount.DataSource = from a in db.ADMINs
                                             select new
                                             {
                                                 Tài_Khoản = a.UserName,
                                                 Mật_Khẩu = a.Pass
                                             };
                }
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtsotiennap_TextChanged(object sender, EventArgs e)
        {
            string s = txtsotiennap.Text;
            foreach (char i in s)
            {
                if (!(i >= '0' && i <= '9'))
                {
                    MessageBox.Show("Nhập sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtsotiennap.Clear();
                    txtsotiennap.Focus();
                }
            }
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            txtsotiennap.Text = "50000";
            txtSoTien.Text = "50000";
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            txtsotiennap.Text = "500000";
            txtSoTien.Text = "500000";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn10_Click(object sender, EventArgs e)
        {
            txtsotiennap.Text = "10000";
            txtSoTien.Text = "10000";
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            txtsotiennap.Text = "100000";
            txtSoTien.Text = "100000";
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            txtsotiennap.Text = "200000";
            txtSoTien.Text = "200000";
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            txtsotiennap.Text = "20000";
            txtSoTien.Text = "20000";
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
                return;

            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string user = txtTaiKhoan.Text,
                      pass = txtMatKhau.Text,
                      cmnd = txtCMND.Text,
                      sdt = txtSDT.Text,
                      tien = txtSoTien.Text; 
                if (pass == "")
                    pass = "123";
                if (rdKhach.Checked)
                {
                    TaiKhoan insert = new TaiKhoan();
                    insert.UserName = user;
                    insert.Pass = pass;
                    insert.CMND = cmnd;
                    insert.SDT = sdt;
                    insert.TIEN = tien;

                    db.TaiKhoans.InsertOnSubmit(insert);
                }
                else
                {
                    ADMIN insert = new ADMIN();
                    insert.UserName = user;
                    insert.Pass = pass;
                    db.ADMINs.InsertOnSubmit(insert);
                }
                db.SubmitChanges();
                MessageBox.Show("Đã tạo thành công", "Thông báo");
                LoadAccountList();
            }
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
            txtSoTien.Clear();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                if (rdKhach.Checked)
                {
                    string user = dtgvAccount.SelectedCells[0].OwningRow.Cells["Tài_Khoản"].Value.ToString();
                    TaiKhoan delete = db.TaiKhoans.Where(a => a.UserName.Equals(user)).SingleOrDefault();
                    db.TaiKhoans.DeleteOnSubmit(delete);
                }
                else
                {
                    string user = dtgvAccount.SelectedCells[0].OwningRow.Cells["Tài_Khoản"].Value.ToString();
                    ADMIN delete = db.ADMINs.Where(a => a.UserName.Equals(user)).SingleOrDefault();
                    db.ADMINs.DeleteOnSubmit(delete);
                }
                db.SubmitChanges();
                MessageBox.Show("Đã xóa thành công", "Thông báo");
                LoadAccountList();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext()) {

                if (rdKhach.Checked) {
                    dtgvAccount.DataSource = from a in db.TaiKhoans select a;
                }
                else if (rdAdmin.Checked)
                {
                    dtgvAccount.DataSource = from a in db.ADMINs select a;
                }
            }
            btnSua1.Enabled=true;
          
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string user = txtTaiKhoan.Text;
                if (String.IsNullOrEmpty(user))
                {
                    LoadAccountList();
                }
                else
                {
                    if (rdKhach.Checked)
                    {
                        dtgvAccount.DataSource = db.TaiKhoans.Where(a => a.UserName.Equals(user));
                        dtgvAccount.DataSource = from a in db.TaiKhoans
                                                 where a.UserName == user
                                                 select new
                                                 {
                                                     Tài_Khoản = a.UserName,
                                                     Mật_Khẩu = a.Pass,
                                                     a.SDT,
                                                     a.CMND,
                                                     TIền = a.TIEN
                                                 };
                    }
                    else
                    {
                        dtgvAccount.DataSource = db.ADMINs.Where(a => a.UserName.Equals(user));
                        dtgvAccount.DataSource = from a in db.ADMINs
                                                 where a.UserName == user
                                                 select new
                                                 {
                                                     Tài_Khoản = a.UserName,
                                                     Mật_Khẩu = a.Pass,
                                                    
                                                 };
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNap_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string user = txtTaiKhoan.Text;
                double tien = double.Parse(txtsotiennap.Text);
                TaiKhoan edit = db.TaiKhoans.Where(a => a.UserName.Equals(user)).SingleOrDefault();

                if (String.IsNullOrEmpty(edit.TIEN)) edit.TIEN = "0";
                edit.TIEN = (double.Parse(edit.TIEN) + tien).ToString();
                db.SubmitChanges();
                rdKhach.Checked = true;
                btnTim_Click(sender, e);
            }
        }


        private void rdKhach_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rdAdmin_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                if (rdKhach.Checked)
                {

                    string user = dtgvAccount.SelectedCells[0].OwningRow.Cells["UserName"].Value.ToString();
                    string pass = dtgvAccount.SelectedCells[0].OwningRow.Cells["Pass"].Value    .ToString();
                    string sdt = dtgvAccount.SelectedCells[0].OwningRow.Cells["SDT"].Value == null ?
                        null : (string)dtgvAccount.SelectedCells[0].OwningRow.Cells["SDT"].Value;
                    string cmnd = dtgvAccount.SelectedCells[0].OwningRow.Cells["CMND"].Value == null ?
                        null : (string)dtgvAccount.SelectedCells[0].OwningRow.Cells["CMND"].Value;
                    
                    
                    TaiKhoan edit = db.TaiKhoans.Where(a => a.UserName.Equals(user)).SingleOrDefault();

                    edit.UserName = user;
                    edit.Pass = pass;
                    edit.SDT = sdt;
                    edit.CMND = cmnd;
                    db.SubmitChanges();

                }
                else if(rdAdmin.Checked)
                {
                    string user = dtgvAccount.SelectedCells[0].OwningRow.Cells["Tài_Khoản"].Value.ToString();
                    string pass = dtgvAccount.SelectedCells[0].OwningRow.Cells["Mật_Khẩu"].Value.ToString();

                    ADMIN edit = db.ADMINs.Where(a => a.UserName.Equals(user)).SingleOrDefault();

                    edit.UserName = user;
                    edit.Pass = pass;
                    db.SubmitChanges();
                }
                MessageBox.Show("Đã sửa thành công", "Thông báo");
                btnTim_Click(sender, e);
            }
            btnSua1.Enabled = false;
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCMND_TextChanged(object sender, EventArgs e)
        {
            string s = txtCMND.Text;
            if (s.Length > 12)
            {
                MessageBox.Show("Nhập dư", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCMND.Clear();
                txtCMND.Focus();
            }
            foreach (char i in s)
            {
                if (!(i >= '0' && i <= '9'))
                {
                    MessageBox.Show("Nhập sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCMND.Clear();
                    txtCMND.Focus();
                }
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string s = txtSDT.Text;
            foreach (char i in s)
            {
                if (s[0] != '0')
                {
                    MessageBox.Show("Nhập sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Clear();
                    txtSDT.Focus();
                }
                if (!(i >= '0' && i <= '9'))
                {
                    MessageBox.Show("Nhập sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSDT.Clear();
                    txtSDT.Focus();
                }
            }
            if (s.Length > 10)
            {
                MessageBox.Show("Nhập dư", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Clear();
                txtSDT.Focus();
            }

        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            string s = txtSoTien.Text;
            foreach (char i in s)
            {
                if (!(i >= '0' && i <= '9'))
                {
                    MessageBox.Show("Nhập sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoTien.Clear();
                    txtSoTien.Focus();
                }
            }
        }
    }
}
