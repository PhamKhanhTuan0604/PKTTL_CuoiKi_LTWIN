namespace QLSinhVien
{
    partial class frmTangCa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.txtLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTinh = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGio = new System.Windows.Forms.TextBox();
            this.dgvHS = new System.Windows.Forms.DataGridView();
            this.STTdgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDTangCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGioTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LuongTC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qLNhanVienDataSetTangCaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNhanVienDataSetTangCa = new QLSinhVien.QLNhanVienDataSetTangCa();
            this.tangCaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tangCaTableAdapter = new QLSinhVien.QLNhanVienDataSetTangCaTableAdapters.TangCaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNhanVienDataSetTangCaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNhanVienDataSetTangCa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tangCaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã NV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID tăng ca";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy   HH:mm";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(544, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(221, 27);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.UseWaitCursor = true;
            this.dateTimePicker1.Value = new System.DateTime(2024, 5, 21, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(376, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày, Giờ bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(376, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày, Giờ kết thúc";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy   HH:mm";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(544, 103);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(221, 27);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.Value = new System.DateTime(2024, 5, 21, 20, 22, 8, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(126, 52);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(206, 27);
            this.txtMaNV.TabIndex = 4;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.Location = new System.Drawing.Point(126, 100);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(206, 27);
            this.txtTenNV.TabIndex = 5;
            // 
            // txtLuong
            // 
            this.txtLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLuong.Location = new System.Drawing.Point(948, 52);
            this.txtLuong.Name = "txtLuong";
            this.txtLuong.Size = new System.Drawing.Size(177, 27);
            this.txtLuong.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(805, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Lương Tăng Ca";
            // 
            // btnTinh
            // 
            this.btnTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinh.ForeColor = System.Drawing.Color.Red;
            this.btnTinh.Location = new System.Drawing.Point(491, 178);
            this.btnTinh.Name = "btnTinh";
            this.btnTinh.Size = new System.Drawing.Size(274, 66);
            this.btnTinh.TabIndex = 9;
            this.btnTinh.Text = "TÍNH";
            this.btnTinh.UseVisualStyleBackColor = true;
            this.btnTinh.Click += new System.EventHandler(this.btnTinh_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(805, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số Giờ Tăng Ca";
            // 
            // txtGio
            // 
            this.txtGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGio.Location = new System.Drawing.Point(948, 100);
            this.txtGio.Name = "txtGio";
            this.txtGio.Size = new System.Drawing.Size(177, 27);
            this.txtGio.TabIndex = 11;
            // 
            // dgvHS
            // 
            this.dgvHS.AutoGenerateColumns = false;
            this.dgvHS.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTdgv,
            this.IDTangCa,
            this.MaNV,
            this.SoGioTC,
            this.LuongTC});
            this.dgvHS.DataSource = this.qLNhanVienDataSetTangCaBindingSource;
            this.dgvHS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvHS.Location = new System.Drawing.Point(0, 278);
            this.dgvHS.Name = "dgvHS";
            this.dgvHS.RowHeadersWidth = 51;
            this.dgvHS.RowTemplate.Height = 24;
            this.dgvHS.Size = new System.Drawing.Size(1196, 284);
            this.dgvHS.TabIndex = 12;
            this.dgvHS.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHS_CellClick_1);
            // 
            // STTdgv
            // 
            this.STTdgv.DataPropertyName = "STT";
            this.STTdgv.HeaderText = "STT";
            this.STTdgv.MinimumWidth = 6;
            this.STTdgv.Name = "STTdgv";
            this.STTdgv.Width = 125;
            // 
            // IDTangCa
            // 
            this.IDTangCa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDTangCa.DataPropertyName = "IDTangCa";
            this.IDTangCa.HeaderText = "IDTangCa";
            this.IDTangCa.MinimumWidth = 6;
            this.IDTangCa.Name = "IDTangCa";
            // 
            // MaNV
            // 
            this.MaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "MaNV";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            // 
            // SoGioTC
            // 
            this.SoGioTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SoGioTC.DataPropertyName = "SoGIoTC";
            this.SoGioTC.HeaderText = "số giờ tăng ca";
            this.SoGioTC.MinimumWidth = 6;
            this.SoGioTC.Name = "SoGioTC";
            // 
            // LuongTC
            // 
            this.LuongTC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LuongTC.DataPropertyName = "LuongTC";
            this.LuongTC.HeaderText = "lương tăng ca";
            this.LuongTC.MinimumWidth = 6;
            this.LuongTC.Name = "LuongTC";
            // 
            // qLNhanVienDataSetTangCaBindingSource
            // 
            this.qLNhanVienDataSetTangCaBindingSource.DataSource = this.qLNhanVienDataSetTangCa;
            this.qLNhanVienDataSetTangCaBindingSource.Position = 0;
            // 
            // qLNhanVienDataSetTangCa
            // 
            this.qLNhanVienDataSetTangCa.DataSetName = "QLNhanVienDataSetTangCa";
            this.qLNhanVienDataSetTangCa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tangCaBindingSource
            // 
            this.tangCaBindingSource.DataMember = "TangCa";
            this.tangCaBindingSource.DataSource = this.qLNhanVienDataSetTangCaBindingSource;
            // 
            // tangCaTableAdapter
            // 
            this.tangCaTableAdapter.ClearBeforeFill = true;
            // 
            // frmTangCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1196, 562);
            this.Controls.Add(this.dgvHS);
            this.Controls.Add(this.txtGio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnTinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLuong);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTangCa";
            this.Text = "frmTangCa";
            this.Load += new System.EventHandler(this.frmTangCa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNhanVienDataSetTangCaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNhanVienDataSetTangCa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tangCaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGio;
        private System.Windows.Forms.DataGridView dgvHS;
        private System.Windows.Forms.BindingSource qLNhanVienDataSetTangCaBindingSource;
        private QLNhanVienDataSetTangCa qLNhanVienDataSetTangCa;
        private System.Windows.Forms.BindingSource tangCaBindingSource;
        private QLNhanVienDataSetTangCaTableAdapters.TangCaTableAdapter tangCaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTdgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDTangCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGioTC;
        private System.Windows.Forms.DataGridViewTextBoxColumn LuongTC;
    }
}