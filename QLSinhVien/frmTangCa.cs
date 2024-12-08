using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLSinhVien
{
    public partial class frmTangCa : Form
    {
        private static string _quyen;
        public frmTangCa(string quyen)
        {
            InitializeComponent();
            _quyen = quyen;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy     HH:mm";

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy     HH:mm";
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            string mahs = txtMaNV.Text;
            using (dbQLSinhVienDataContext db = new dbQLSinhVienDataContext())
            {
                TangCa hs = db.TangCas.Where(p => p.IDTangCa == mahs).SingleOrDefault();
                if (hs == null)
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime startTime = dateTimePicker1.Value;
                DateTime endTime = dateTimePicker2.Value;

                if (endTime < startTime)
                {
                    MessageBox.Show("Thời gian kết thúc phải lớn hơn thời gian bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                TimeSpan overtime = endTime - startTime;
                int totalHours = (int)overtime.TotalHours;
                int totalMinutes = overtime.Minutes;
                double hours = (double)totalHours + (double)totalMinutes / 60;
                int gio = (int)hours;
                //txtGio.Text = $"     {totalHours} giờ  {totalMinutes} phút";
                int Tien = (int)hours * 1000;
                txtGio.Text = $"     {totalHours} giờ  {totalMinutes} phút";
                txtLuong.Text = Tien.ToString();

                try
                {

                    hs.SoGioTC = hs.SoGioTC + gio;
                    hs.LuongTC = hs.LuongTC + Tien;
                    db.SubmitChanges();
                    loadDSHocSinh();
                    MessageBox.Show("Cập nhật lương mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi cập nhật lương: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmTangCa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNhanVienDataSetTangCa.TangCa' table. You can move, or remove it, as needed.
            this.tangCaTableAdapter.Fill(this.qLNhanVienDataSetTangCa.TangCa);

            // this.TangCaTableAdapter.Fill(this.qLNhanVienDataSetTangCa.TangCa);
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTKhoan == _quyen).FirstOrDefault();
            if (tk != null)
            {
                // Nếu tên tài khoản trùng với quyền "user", ẩn các nút
                if (tk.TenTKhoan == "user")
                {
                    btnTinh.Visible = false;
                   

                }
                // Nếu tên tài khoản trùng với quyền "admin", hiển thị tất cả các nút
                else if (tk.TenTKhoan == "admin")
                {
                    btnTinh.Visible = true;
                 
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.");
            }

            loadDSHocSinh();
            
        }


        private void loadDSHocSinh(string malop = "")
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            if (malop == "")
                dgvHS.DataSource = db.TangCas.ToList()
                    .Select((p, index) => new
                    {
                        STT = index + 1,
                        p.IDTangCa,
                        p.MaNV,
                        p.SoGioTC,
                        p.LuongTC

                    }).ToList();

        }

        private void dgvHS_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            if (indexRow < 0) return;
            string mahs = dgvHS[1, indexRow].Value.ToString();

            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TangCa hs = db.TangCas.Where(p => p.IDTangCa == mahs).SingleOrDefault();
            txtMaNV.Text = hs.IDTangCa;
            txtTenNV.Text = hs.MaNV;
        }
    }
}
