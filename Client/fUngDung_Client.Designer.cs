namespace Client
{
    partial class fUngDung_Client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUngDung_Client));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNguoidung = new System.Windows.Forms.TextBox();
            this.txtTgTong = new System.Windows.Forms.TextBox();
            this.txtTgSuDung = new System.Windows.Forms.TextBox();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnMatKhau = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbGio = new System.Windows.Forms.Label();
            this.lbPhut = new System.Windows.Forms.Label();
            this.lbGiay = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Người dùng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời gian tổng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thời gian sử dụng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Thời gian còn lại";
            // 
            // txtNguoidung
            // 
            this.txtNguoidung.Location = new System.Drawing.Point(124, 33);
            this.txtNguoidung.Name = "txtNguoidung";
            this.txtNguoidung.Size = new System.Drawing.Size(100, 20);
            this.txtNguoidung.TabIndex = 4;
            this.txtNguoidung.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtTgTong
            // 
            this.txtTgTong.Location = new System.Drawing.Point(124, 58);
            this.txtTgTong.Name = "txtTgTong";
            this.txtTgTong.Size = new System.Drawing.Size(100, 20);
            this.txtTgTong.TabIndex = 5;
            // 
            // txtTgSuDung
            // 
            this.txtTgSuDung.Enabled = false;
            this.txtTgSuDung.Location = new System.Drawing.Point(124, 82);
            this.txtTgSuDung.Name = "txtTgSuDung";
            this.txtTgSuDung.Size = new System.Drawing.Size(100, 20);
            this.txtTgSuDung.TabIndex = 6;
            // 
            // btnChat
            // 
            this.btnChat.Location = new System.Drawing.Point(28, 145);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(87, 41);
            this.btnChat.TabIndex = 8;
            this.btnChat.Text = "Chat";
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.Location = new System.Drawing.Point(124, 145);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(100, 41);
            this.btnDichVu.TabIndex = 9;
            this.btnDichVu.Text = "Dịch Vụ";
            this.btnDichVu.UseVisualStyleBackColor = true;
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // btnMatKhau
            // 
            this.btnMatKhau.Location = new System.Drawing.Point(28, 193);
            this.btnMatKhau.Name = "btnMatKhau";
            this.btnMatKhau.Size = new System.Drawing.Size(87, 41);
            this.btnMatKhau.TabIndex = 10;
            this.btnMatKhau.Text = "Mật khẩu";
            this.btnMatKhau.UseVisualStyleBackColor = true;
            this.btnMatKhau.Click += new System.EventHandler(this.btnMatKhau_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Location = new System.Drawing.Point(123, 193);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(100, 41);
            this.btnDangXuat.TabIndex = 11;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbGio
            // 
            this.lbGio.AutoSize = true;
            this.lbGio.Location = new System.Drawing.Point(121, 109);
            this.lbGio.Name = "lbGio";
            this.lbGio.Size = new System.Drawing.Size(19, 13);
            this.lbGio.TabIndex = 12;
            this.lbGio.Text = "00";
            this.lbGio.Click += new System.EventHandler(this.label5_Click);
            // 
            // lbPhut
            // 
            this.lbPhut.AutoSize = true;
            this.lbPhut.Location = new System.Drawing.Point(146, 109);
            this.lbPhut.Name = "lbPhut";
            this.lbPhut.Size = new System.Drawing.Size(19, 13);
            this.lbPhut.TabIndex = 13;
            this.lbPhut.Text = "00";
            // 
            // lbGiay
            // 
            this.lbGiay.AutoSize = true;
            this.lbGiay.Location = new System.Drawing.Point(171, 109);
            this.lbGiay.Name = "lbGiay";
            this.lbGiay.Size = new System.Drawing.Size(19, 13);
            this.lbGiay.TabIndex = 14;
            this.lbGiay.Text = "00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = ":";
            // 
            // fUngDung_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 468);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbGiay);
            this.Controls.Add(this.lbPhut);
            this.Controls.Add(this.lbGio);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnMatKhau);
            this.Controls.Add(this.btnDichVu);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.txtTgSuDung);
            this.Controls.Add(this.txtTgTong);
            this.Controls.Add(this.txtNguoidung);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fUngDung_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fUngDung_Client_FormClosing);
            this.Load += new System.EventHandler(this.fUngDung_Client_Load);
            this.Shown += new System.EventHandler(this.fUngDung_Client_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNguoidung;
        private System.Windows.Forms.TextBox txtTgTong;
        private System.Windows.Forms.TextBox txtTgSuDung;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnMatKhau;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbGio;
        private System.Windows.Forms.Label lbPhut;
        private System.Windows.Forms.Label lbGiay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}