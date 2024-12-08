namespace QLSinhVien
{
    partial class frmXacThuc
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTenTKhoan = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.btnXacThuc = new System.Windows.Forms.Button();
            this.btnGuiLai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblThongbao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(163, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xác thực tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên tài khoản";
            // 
            // lblTenTKhoan
            // 
            this.lblTenTKhoan.AutoSize = true;
            this.lblTenTKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTKhoan.ForeColor = System.Drawing.Color.Red;
            this.lblTenTKhoan.Location = new System.Drawing.Point(232, 60);
            this.lblTenTKhoan.Name = "lblTenTKhoan";
            this.lblTenTKhoan.Size = new System.Drawing.Size(122, 20);
            this.lblTenTKhoan.TabIndex = 0;
            this.lblTenTKhoan.Text = "Tên tài khoản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã OTP";
            // 
            // txtOTP
            // 
            this.txtOTP.Location = new System.Drawing.Point(236, 107);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(161, 22);
            this.txtOTP.TabIndex = 1;
            // 
            // btnXacThuc
            // 
            this.btnXacThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacThuc.Location = new System.Drawing.Point(49, 194);
            this.btnXacThuc.Name = "btnXacThuc";
            this.btnXacThuc.Size = new System.Drawing.Size(110, 37);
            this.btnXacThuc.TabIndex = 2;
            this.btnXacThuc.Text = "Xác thực";
            this.btnXacThuc.UseVisualStyleBackColor = true;
            this.btnXacThuc.Click += new System.EventHandler(this.btnXacThuc_Click);
            // 
            // btnGuiLai
            // 
            this.btnGuiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiLai.Location = new System.Drawing.Point(207, 194);
            this.btnGuiLai.Name = "btnGuiLai";
            this.btnGuiLai.Size = new System.Drawing.Size(110, 37);
            this.btnGuiLai.TabIndex = 2;
            this.btnGuiLai.Text = "Gửi lại OTP";
            this.btnGuiLai.UseVisualStyleBackColor = true;
            this.btnGuiLai.Click += new System.EventHandler(this.btnGuiLai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(361, 194);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 37);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblThongbao
            // 
            this.lblThongbao.AutoSize = true;
            this.lblThongbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongbao.Location = new System.Drawing.Point(107, 147);
            this.lblThongbao.Name = "lblThongbao";
            this.lblThongbao.Size = new System.Drawing.Size(321, 18);
            this.lblThongbao.TabIndex = 0;
            this.lblThongbao.Text = "Vui lòng nhập mã OTP. Mã hiệu lực trong 5 phút";
            // 
            // frmXacThuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(505, 256);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnGuiLai);
            this.Controls.Add(this.btnXacThuc);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.lblTenTKhoan);
            this.Controls.Add(this.lblThongbao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmXacThuc";
            this.Text = "Xác thực tài khoản";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenTKhoan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Button btnXacThuc;
        private System.Windows.Forms.Button btnGuiLai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label lblThongbao;
    }
}