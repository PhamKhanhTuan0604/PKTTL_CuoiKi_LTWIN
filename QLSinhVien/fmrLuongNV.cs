using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhVien
{
    public partial class fmrLuongNV : Form
    {
        private static string Phanquyen;
        public fmrLuongNV(string _phanquyen)
        {
            InitializeComponent();
            Phanquyen = _phanquyen;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mahs = txtMaHS.Text;
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            NhanVien hs = db.NhanViens.Where(p => p.MaNV == mahs).SingleOrDefault();

            double luongcb = double.Parse(txtDiemTB.Text);
            double songay = double.Parse(txt_Ngaylam.Text);
            double phucap = double.Parse(txtPhucap.Text);

            if (!double.TryParse(txtDiemTB.Text, out luongcb))
            {
                MessageBox.Show("Vui long nhap so", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!double.TryParse(txt_Ngaylam.Text, out songay))
            {
                MessageBox.Show("Vui long nhap so", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtPhucap.Text , out phucap))
            {
                MessageBox.Show("Vui long nhap so", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double tong;
            tong = luongcb * 100000 * songay + phucap * 2;
            txtXuat.Text = tong.ToString();
            hs.TongLuongThang = float.Parse( txtXuat.Text);

            db.SubmitChanges();
            loadDSHocSinh();
        }

        

        private void fmrLuongNV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNhanVienDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.qLNhanVienDataSet.NhanVien);
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTKhoan == Phanquyen).FirstOrDefault();
            if (tk != null)
            {
                // Nếu tên tài khoản trùng với quyền "user", ẩn các nút
                if (tk.TenTKhoan == "user")
                {
                    btnThem.Visible = false;
                   
                    groupBox1.Visible = false;

                }
                // Nếu tên tài khoản trùng với quyền "admin", hiển thị tất cả các nút
                else if (tk.TenTKhoan == "admin")
                {
                    btnThem.Visible = true;
                   
                    groupBox1.Visible = true;
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
                dgvHS.DataSource = db.NhanViens.ToList()
                    .Select((p, index) => new {
                        STT = index + 1,
                        p.MaNV,
                        p.TenNV,
                        p.SoHD,
                        p.Luong,
                        p.PhuCap,
                        p.TongLuongThang
                    }).ToList();
            else dgvHS.DataSource = db.NhanViens.Where(p => p.MaPhongBan == malop).ToList()
                .Select((p, index) => new {
                    STT = index + 1,
                    p.MaNV,
                    p.TenNV,
                    p.SoHD,
                    p.Luong, 
                    p.PhuCap,
                    p.TongLuongThang
                }).ToList();
        }

     

        private void dgvHS_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int indexRow = e.RowIndex;
            if (indexRow < 0) return;
            string mahs = dgvHS[1, indexRow].Value.ToString();

            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            NhanVien hs = db.NhanViens.Where(p => p.MaNV == mahs).SingleOrDefault();
            txtMaHS.Text = hs.MaNV;
            txtHoTen.Text = hs.TenNV;
            txtDiaChi.Text = hs.DiaChi;
            txt_SoHD.Text = hs.SoHD.ToString();
            txtPhucap.Text = hs.PhuCap.ToString();
            txtDiemTB.Text = hs.Luong.ToString();
        }
    }
}
