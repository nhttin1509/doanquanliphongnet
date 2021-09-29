namespace Client
{
    partial class fDichVu_Client
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtgvThucUong = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvThucAn = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGui = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThucUong)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThucAn)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(6, 57);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(203, 58);
            this.txtMessage.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nhập tên món";
            // 
            // dtgvThucUong
            // 
            this.dtgvThucUong.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgvThucUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThucUong.Location = new System.Drawing.Point(3, 8);
            this.dtgvThucUong.Name = "dtgvThucUong";
            this.dtgvThucUong.RowHeadersWidth = 51;
            this.dtgvThucUong.Size = new System.Drawing.Size(208, 457);
            this.dtgvThucUong.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvThucUong);
            this.panel2.Location = new System.Drawing.Point(252, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 468);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(317, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Thức uống";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(89, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thức ăn";
            // 
            // dtgvThucAn
            // 
            this.dtgvThucAn.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgvThucAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThucAn.Location = new System.Drawing.Point(0, 8);
            this.dtgvThucAn.Name = "dtgvThucAn";
            this.dtgvThucAn.RowHeadersWidth = 51;
            this.dtgvThucAn.Size = new System.Drawing.Size(208, 457);
            this.dtgvThucAn.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnGui);
            this.panel3.Controls.Add(this.txtMessage);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(495, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 192);
            this.panel3.TabIndex = 8;
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(43, 121);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(124, 68);
            this.btnGui.TabIndex = 15;
            this.btnGui.Text = "Gọi món";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvThucAn);
            this.panel1.Location = new System.Drawing.Point(24, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 468);
            this.panel1.TabIndex = 4;
            // 
            // fDichVu_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 664);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "fDichVu_Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DichVu";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThucUong)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThucAn)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgvThucUong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvThucAn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGui;
    }
}