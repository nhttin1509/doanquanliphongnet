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

namespace Client
{
    public partial class fDichVu_Client : Form
    {
        public fDichVu_Client()
        {
            InitializeComponent();
            LoadThucAnList();
            LoadThucUongList();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            Label lbTime = new Label();
            DateTime dt = DateTime.Now;
            lbTime.Text = dt.ToLongTimeString().ToString();

            Send();
            MessageBox.Show("Đã gọi món " + txtMessage.Text + "\n \n");
           
        }
        IPEndPoint IP;
        Socket client;
        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        void Close()
        {
            client.Close();
        }
        void Send()
        {
            if (txtMessage.Text != string.Empty)
                client.Send(Serialize(txtMessage.Text));
        }
        void Receive()
        {

            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);


                    
                }
            }
            catch
            {
                Close();
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
    }
}

