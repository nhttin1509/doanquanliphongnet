﻿using System;
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
    public partial class fChat_Client : Form
    {
        public fChat_Client()
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

            Send();
            txtChat.Text = lbTime.Text + " [Client]: " + txtChat.Text + "\n \n";
            AddMessage(txtChat.Text);
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
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }
        void Close()
        {
            client.Close();
        }
        void Send()
        {
            if (txtChat.Text != string.Empty)
                client.Send(Serialize(txtChat.Text));
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


                    AddMessage(changeMessage(message));
                }
            }
            catch
            {
                Close();
            }
        }
        void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem()
            {
                Text = s
            });
            txtChat.Clear();
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
            return lbTime.Text + " [Admin]: " + s + "\n \n";
        }
    }
}
