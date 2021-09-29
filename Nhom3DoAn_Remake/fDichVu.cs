using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom3DoAn_Remake
{
    public partial class fDichVu : Form
    {
        public fDichVu()
        {
            InitializeComponent();
            LoadThucAnList();
            LoadThucUongList();
            btnSua1.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        void LoadThucAnList()
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                dtgvThucAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvThucAn.DataSource = from a in db.THUCANs
                                        select new
                                        {
                                            Mã = a.MA,
                                            Tên = a.TEN,
                                            Giá = a.GIA
                                        };
            }
        }
        void LoadThucUongList()
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                dtgvThucUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvThucUong.DataSource = from a in db.THUCUONGs
                                          select new
                                          {
                                              Mã = a.MA,
                                              Tên = a.TEN,
                                              Giá = a.GIA
                                          };
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            string s = txtGia.Text;
            foreach (char i in s)
                if (!(i >= '0' && i <= '9'))
                {
                    MessageBox.Show("Nhập sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGia.Clear();
                    txtGia.Focus();
                }
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            string s = txtGia.Text;
            foreach (char i in s)
            {
                if (!(i >= '0' && i <= '9'))
                {
                    MessageBox.Show("Nhập sai", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGia.Clear();
                    txtGia.Focus();
                }
            }
        }

        private void txtTenLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoai.Text))
                return;
            if (string.IsNullOrEmpty(txtGia.Text))
                return;
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string ma = txtMa.Text, ten = txtTenLoai.Text, gia = txtGia.Text;
                if (rdThucAn.Checked)
                {
                    THUCAN insert = new THUCAN();
                    insert.MA = ma;
                    insert.TEN = ten;
                    insert.GIA = double.Parse(gia);
                    db.THUCANs.InsertOnSubmit(insert);
                    MessageBox.Show("Đã thêm thành công món " + ten, "Thông báo");
                    db.SubmitChanges();
                    LoadThucAnList();
                }
                else if (rdThucUong.Checked)
                {
                    THUCUONG insert = new THUCUONG();
                    insert.MA = ma;
                    insert.TEN = ten;
                    insert.GIA = double.Parse(gia);
                    db.THUCUONGs.InsertOnSubmit(insert);
                    MessageBox.Show("Đã thêm thành công món " + ten, "Thông báo");
                    db.SubmitChanges();
                    LoadThucUongList();
                }


            }
            txtMa.Clear();
            txtTenLoai.Clear();
            txtGia.Clear();
            txtTenLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string ma = txtMa.Text, ten = txtTenLoai.Text, gia = txtGia.Text;
                if (rdThucAn.Checked)
                {
                    string user = dtgvThucAn.SelectedCells[0].OwningRow.Cells["Ma"].Value.ToString();
                    THUCAN delete = db.THUCANs.Where(a => a.MA.Equals(user)).SingleOrDefault();
                    db.THUCANs.DeleteOnSubmit(delete);

                    MessageBox.Show("Đã xóa món" + ten + " thành công", "Thông báo");
                    db.SubmitChanges();
                    LoadThucAnList();
                }
                else if (rdThucUong.Checked)
                {
                    string user = dtgvThucUong.SelectedCells[0].OwningRow.Cells["Ma"].Value.ToString();
                    THUCUONG delete = db.THUCUONGs.Where(a => a.MA.Equals(user)).SingleOrDefault();
                    db.THUCUONGs.DeleteOnSubmit(delete);
                    MessageBox.Show("Đã xóa món" + ten + " thành công", "Thông báo");
                    db.SubmitChanges();
                    LoadThucUongList();
                }
            }
            txtMa.Clear();
            txtTenLoai.Clear();
            txtGia.Clear();
        }

        private void rdThucUong_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdThucAn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void fDichVu_Load(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                string user = txtTenLoai.Text;
                if (rdThucAn.Checked)
                {
                    if (String.IsNullOrEmpty(user))
                    {
                        LoadThucAnList();

                    }
                    else
                    {
                        dtgvThucAn.DataSource = from a in db.THUCANs
                                                where a.TEN == user
                                                select new
                                                {
                                                    Mã = a.MA,
                                                    Tên = a.TEN,
                                                    Giá = a.GIA
                                                };
                    }
                }
                else if (rdThucUong.Checked)
                {
                    if (String.IsNullOrEmpty(user))
                    {
                        LoadThucUongList();

                    }
                    else
                    {
                        dtgvThucUong.DataSource = from a in db.THUCUONGs
                                                  where a.TEN == user
                                                  select new
                                                  {
                                                      Mã = a.MA,
                                                      Tên = a.TEN,
                                                      Giá = a.GIA
                                                  };
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua1.Enabled = true;

            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                if (rdThucAn.Checked)
                {
                    dtgvThucAn.DataSource = from a in db.THUCANs select a;
                }
                else if (rdThucUong.Checked)
                {
                    dtgvThucUong.DataSource = from a in db.THUCUONGs select a;
                }
            }
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            using (DataPhongNetDataContext db = new DataPhongNetDataContext())
            {
                if (rdThucAn.Checked)
                {
                    string ma = dtgvThucAn.SelectedCells[0].OwningRow.Cells["MA"].Value.ToString();
                    string ten = dtgvThucAn.SelectedCells[0].OwningRow.Cells["TEN"].Value.ToString();
                    string gia = dtgvThucAn.SelectedCells[0].OwningRow.Cells["GIA"].Value.ToString();
                    THUCAN edit = db.THUCANs.Where(a => a.MA.Equals(ma)).SingleOrDefault();
                    edit.MA = ma;
                    edit.TEN = ten;
                    edit.GIA = double.Parse(gia);
                    db.SubmitChanges();
                }
                else if (rdThucUong.Checked)
                {
                    string ma = dtgvThucUong.SelectedCells[0].OwningRow.Cells["MA"].Value.ToString();
                    string ten = dtgvThucUong.SelectedCells[0].OwningRow.Cells["TEN"].Value.ToString();
                    string gia = dtgvThucUong.SelectedCells[0].OwningRow.Cells["GIA"].Value.ToString();
                    THUCUONG edit = db.THUCUONGs.Where(a => a.MA.Equals(ma)).SingleOrDefault();
                    edit.MA = ma;
                    edit.TEN = ten;
                    edit.GIA = double.Parse(gia);
                    db.SubmitChanges();

                }
                MessageBox.Show("Đã sửa thành công", "Thông báo");
                btnTim_Click(sender, e);
            }
        }
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;
        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP);

            Thread Listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    MessageBox.Show("Client gọi món: " + message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }
   
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
        
    }
}
