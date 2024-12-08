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
    public partial class frmHocSinh : Form
    {
        public static string quyen;

        public frmHocSinh(string phanquyen)
        {
            InitializeComponent();
            quyen = phanquyen;
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTKhoan == quyen).FirstOrDefault();
            if (tk != null)
            {
                // Nếu tên tài khoản trùng với quyền "user", ẩn các nút
                if (tk.TenTKhoan == "user")
                {
                    btnThem.Visible = false;
                    btnIn.Visible = false;
                    btnLamMoi.Visible = false;
                    btnSua.Visible = false;
                    btnTim.Visible = false;
                    btnXoa.Visible = false;
                    groupBox1.Visible = false;
                    
                }
                // Nếu tên tài khoản trùng với quyền "admin", hiển thị tất cả các nút
                else if (tk.TenTKhoan == "admin")
                {
                    btnThem.Visible = true;
                    btnIn.Visible = true;
                    btnLamMoi.Visible = true;
                    btnSua.Visible = true;
                    btnTim.Visible = true;
                    btnXoa.Visible = true;
                    groupBox1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.");
            }
            loadDSLop();
            loadDSHocSinh();
           
        }
        private void loadDSHocSinh(string malop="")
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            if (malop=="")
            dgvHS.DataSource = db.NhanViens.ToList()
                .Select((p, index) => new {STT=index+1, p.MaNV, p.TenNV,
                    NgaySinh = string.Format("{0:dd-MM-yyyy}", p.NgaySinh),
                    p.DiaChi, p.Luong}).ToList();
            else dgvHS.DataSource = db.NhanViens.Where(p=> p.MaPhongBan ==malop).ToList()
                .Select((p, index) => new { STT = index + 1,p.MaNV,p.TenNV,
                    NgaySinh = string.Format("{0:dd-MM-yyyy}", p.NgaySinh), p.DiaChi,p.Luong}).ToList();
        }

        private void loadDSLop()
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            List<PhongBan> lst =  db.PhongBans.OrderBy(p => p.MaPhongBan).ToList();
            PhongBan l = new PhongBan();  l.MaPhongBan = ""; l.TenPhongBan = "Tất cả";
            lst.Insert(0, l);
            cbbLop.DataSource = lst;
            cbbLop.DisplayMember = "TenPhongBan";
            cbbLop.ValueMember = "MaPhongBan";
        }

        private void cbbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDSHocSinh(cbbLop.SelectedValue.ToString());

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
            txtDiemTB.Text = hs.Luong.ToString();
            cbbLop.SelectedValue = hs.MaPhongBan;
            dtpNgaySinh.Value = (DateTime)hs.NgaySinh;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if( !kiemtraMaLop()) return;    
            string mahs = txtMaHS.Text;
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            NhanVien hs = db.NhanViens.Where(p => p.MaNV == mahs).SingleOrDefault();
            if(hs != null)
            {
                MessageBox.Show("Trùng mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            hs = new NhanVien();
            hs.MaNV = txtMaHS.Text;
            hs.TenNV = txtHoTen.Text;
            hs.DiaChi = txtDiaChi.Text;
            hs.Luong = float.Parse(txtDiemTB.Text);
            hs.NgaySinh = dtpNgaySinh.Value;
            hs.MaPhongBan = cbbLop.SelectedValue.ToString();
            db.NhanViens.InsertOnSubmit(hs);
            db.SubmitChanges();

            loadDSHocSinh(cbbLop.SelectedValue.ToString());
        }

        private bool kiemtraMaLop()
        {
            if (cbbLop.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Chưa chọn phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mahs = txtMaHS.Text;
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            NhanVien hs = db.NhanViens.Where(p => p.MaNV == mahs).SingleOrDefault();
            if (hs == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.NhanViens.DeleteOnSubmit(hs);
            db.SubmitChanges();
            loadDSHocSinh(cbbLop.SelectedValue.ToString());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!kiemtraMaLop()) return;
            string mahs = txtMaHS.Text;
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            NhanVien hs = db.NhanViens.Where(p => p.MaNV == mahs).SingleOrDefault();
            if (hs == null)
            {
                MessageBox.Show("Mã nhân viên chưa tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            hs.TenNV = txtHoTen.Text;
            hs.DiaChi = txtDiaChi.Text;
            hs.Luong = float.Parse(txtDiemTB.Text);
            hs.NgaySinh = dtpNgaySinh.Value;
            hs.MaPhongBan = cbbLop.SelectedValue.ToString();
            db.SubmitChanges();
            loadDSHocSinh(cbbLop.SelectedValue.ToString());
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            string hoten = txtHoTen.Text;
            if(hoten == "")
            {
                dgvHS.DataSource = db.NhanViens.Where(p => p.MaPhongBan == cbbLop.SelectedValue.ToString()).ToList()
                .Select((p, index) => new {STT = index + 1, p.MaNV,p.TenNV,
                    NgaySinh = string.Format("{0:dd-MM-yyyy}", p.NgaySinh),
                    p.DiaChi,p.Luong
                }).ToList();
            }
            else
            {
                dgvHS.DataSource = db.NhanViens.Where(p => p.TenNV.Contains(hoten)).ToList()
                .Select((p, index) => new {
                    STT = index + 1,p.MaNV,p.TenNV,
                    NgaySinh = string.Format("{0:dd-MM-yyyy}", p.NgaySinh),
                    p.DiaChi, p.Luong
                }).ToList();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadDSHocSinh(cbbLop.SelectedValue.ToString());
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //frmHienThi frm = new frmHienThi(cbbLop.SelectedValue.ToString(), cbbLop.Text);
            frmHienThiReport frm = new frmHienThiReport(cbbLop.SelectedValue.ToString(), cbbLop.Text);
            frm.ShowDialog();
        }

      
    }
}
