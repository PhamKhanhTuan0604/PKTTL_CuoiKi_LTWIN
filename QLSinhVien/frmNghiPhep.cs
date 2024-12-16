using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSinhVien
{
    public partial class frmNghiPhep : Form
    {
       /* public frmNghiPhep()
        {
            InitializeComponent();
        }*/
        string quyen;
        public frmNghiPhep(string _quyen)
        {
            InitializeComponent();
            quyen = _quyen;
        }

        #region Hien thi du lieu
        private void frmNghiPhep_Load(object sender, EventArgs e)
        { 
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTKhoan == frmDangNhap.tenTK).FirstOrDefault();
            if (tk != null)
            {
                // Nếu tên tài khoản trùng với quyền "user", ẩn các nút
                if (quyen == "user")
                {
                    btnXoa.Visible = false;
                    btnIn.Visible = false;
                }
                // Nếu tên tài khoản trùng với quyền "admin", hiển thị tất cả các nút
                else if (quyen == "admin")
                {
                    btnXoa.Visible = true;
                    btnIn.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.");
            }
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            dgvNghiPhep.DataSource = db.ChiTietNghiPheps.OrderBy(p => p.ID).
                Select(p => new {p.ID, p.MaNV, p.NgayNghi, p.LyDo}).ToList();
            if(db.ChiTietNghiPheps.ToList().Count > 0)
                hienThiDuLieuDong(0);
        }

        int row;
        private void dgvNghiPhep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //xac dinh hang chon
            row = e.RowIndex;
            if (row == -1) return;
            hienThiDuLieuDong(row);
        }

        private void hienThiDuLieuDong(int row)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            string id = dgvNghiPhep.Rows[row].Cells[0].Value.ToString();
            // Hien thi du lieu
            ChiTietNghiPhep nghi = db.ChiTietNghiPheps.Where(p => p.ID.ToString() == id).SingleOrDefault();
            if(nghi != null)
            {
                txtLyDo.Text = nghi.LyDo;
                // chuyen kieu date trong SQL sang DateTimePicker
                dtpNgayNghi.Value = Convert.ToDateTime(nghi.NgayNghi);
            }    
        }

        #endregion

        #region Nut chuc nang
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime ngaynghi = dtpNgayNghi.Value.Date;
            String lydo = txtLyDo.Text;
            //int id = int.Parse(txtID.Text);

            // Kiem tra co dien day du khong
            if(lydo == "" || DateTime.Now.Date > ngaynghi.Date)
            {
                //ngay nghi o qua khu => khong nghi duoc
                MessageBox.Show("Ngày nghỉ của bạn không hợp lệ. Mời thực hiện lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }   
            else
            {
                //Cho nghi
                // Kiem tra trung lap

                dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
                // Lay ma nhan vien
                NhanVien nv = db.NhanViens.Where(p => p.TenTKhoan == frmDangNhap.tenTK).SingleOrDefault();
                string maNV = nv.MaNV;
                //Ngay nghi giong va cung 1 nguoi thi khong xin nghi duoc
                ChiTietNghiPhep nghi = db.ChiTietNghiPheps.Where(p => p.NgayNghi == ngaynghi && p.MaNV == maNV).SingleOrDefault();
                if (nghi != null)
                {
                    // Trung ngay nghi => khong the them
                    MessageBox.Show("Ngày nghỉ của bạn bị trùng. Mời thực hiện lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                else
                {
                    // Khong trung => Them
                    nghi = new ChiTietNghiPhep();
                    nghi.MaNV = maNV;
                    nghi.NgayNghi = ngaynghi;
                    nghi.LyDo = lydo;
                    db.ChiTietNghiPheps.InsertOnSubmit(nghi);
                    db.SubmitChanges();
                    loadDuLieu();
                    MessageBox.Show("Xin nghỉ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }    

               
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Lay gia tri id o cot id
            string id = dgvNghiPhep.Rows[row].Cells[0].Value.ToString();
            int idnghi = int.Parse(id);

            // Kiem tra trung lap

            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            // ktra co ton tai xin nghi 
            ChiTietNghiPhep nghi = db.ChiTietNghiPheps.Where(p => p.ID == idnghi).SingleOrDefault();
            if (nghi == null)
            {
                 // khong trung => khong xoa
                 MessageBox.Show("Dữ liệu không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;

            }
            else
            {
                // Co ton tai => xoa
                db.ChiTietNghiPheps.DeleteOnSubmit(nghi);
                db.SubmitChanges();
                loadDuLieu();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Lay gia tri id o cot id
            string id = dgvNghiPhep.Rows[row].Cells[0].Value.ToString();
            int idnghi = int.Parse(id);

            DateTime ngaynghi = dtpNgayNghi.Value.Date;
            String lydo = txtLyDo.Text;

            // Kiem tra co dien day du khong
            if (lydo == "" || DateTime.Now > ngaynghi)
            {
                //ngay nghi o qua khu => khong nghi duoc
                MessageBox.Show("Ngày nghỉ của bạn không hợp lệ. Mời thực hiện lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {

                if(quyen == "user")
                {
                    // Kiem tra trung lap

                    dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
                    // Lay ma nhan vien
                    NhanVien nv = db.NhanViens.Where(p => p.TenTKhoan == frmDangNhap.tenTK).SingleOrDefault();
                    string maNV = nv.MaNV;
                    // ktra co ton tai xin nghi cua nhan vien do khong
                    ChiTietNghiPhep nghi = db.ChiTietNghiPheps.Where(p => p.ID == idnghi && p.MaNV == maNV).SingleOrDefault();
                    if (nghi == null)
                    {
                        // khong trung => khong sua
                        MessageBox.Show("Bạn chỉ được sửa xin nghỉ của mình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        // Co ton tai => sua
                        nghi.NgayNghi = ngaynghi;
                        nghi.LyDo = lydo;
                        db.SubmitChanges();
                        loadDuLieu();
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } 
                else if (quyen == "admin")
                {
                    // Kiem tra trung lap

                    dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
                    // Lay ma nhan vien
                    NhanVien nv = db.NhanViens.Where(p => p.TenTKhoan == frmDangNhap.tenTK).SingleOrDefault();
                    string maNV = nv.MaNV;
                    // ktra co ton tai xin nghi cua nhan vien do khong
                    ChiTietNghiPhep nghi = db.ChiTietNghiPheps.Where(p => p.ID == idnghi).SingleOrDefault();
                    if (nghi == null)
                    {
                        // khong trung => khong sua
                        MessageBox.Show("Xin nghỉ không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                    else
                    {
                        // Co ton tai => sua
                        nghi.NgayNghi = ngaynghi;
                        nghi.LyDo = lydo;
                        db.SubmitChanges();
                        loadDuLieu();
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }    
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            if (timkiem == "") loadDuLieu();
            else
            {
                dgvNghiPhep.DataSource = db.ChiTietNghiPheps.Where(p => p.MaNV.Contains(timkiem) || p.LyDo.Contains(timkiem)).Select(p => new { p.ID, p.MaNV, p.NgayNghi, p.LyDo }).ToList();
            }    
        }

        public static string username;
        private void btnIn_Click(object sender, EventArgs e)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            // Lay ma nhan vien
            NhanVien nv = db.NhanViens.Where(p => p.TenTKhoan == frmDangNhap.tenTK).SingleOrDefault();
            username = nv.TenNV;
            string lydo = txtTimKiem.Text;
            frmXinNghiPrinter frm = new frmXinNghiPrinter(lydo);
            frm.Show();
        }
        #endregion
    }
}
