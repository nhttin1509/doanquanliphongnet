using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom3DoAn_Remake
{
    public partial class fChat : Form
    {
        public fChat()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            Label lbTime = new Label();
            DateTime dt = DateTime.Now;
            lbTime.Text = dt.ToLongTimeString().ToString();

            if (String.IsNullOrEmpty(txtChat.Text))
                return;
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            txtChat.Text = lbTime.Text + " [Admin]: " + txtChat.Text + "\n \n";
            AddMessage(txtChat.Text);
            txtChat.Clear();
            txtChat.Focus();
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
        void Send(Socket client)
        {
            if (txtChat.Text != string.Empty)
                client.Send(Serialize(txtChat.Text));
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

                    AddMessage(changeMessage(message));
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem()
            {
                Text = s
            });
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
        string changeMessage(string s)
        {
            Label lbTime = new Label();
            DateTime dt = DateTime.Now;
            lbTime.Text = dt.ToLongTimeString().ToString();
            return lbTime.Text + " [Client]: " + s + "\n \n";
        }

        private void fChat_Shown(object sender, EventArgs e)
        {
            getIPv4 a = new getIPv4();
            lbIP.Text = a.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (String.IsNullOrEmpty(lbIP.Text))
                lbIP.Text = a.GetLocalIPv4(NetworkInterfaceType.Ethernet);

        }
    }
}
