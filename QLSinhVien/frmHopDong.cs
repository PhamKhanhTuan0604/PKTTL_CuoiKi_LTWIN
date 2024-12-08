using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLSinhVien
{
    public partial class frmHopDong : Form
    {
        private static string quyen1;
        public frmHopDong(string _quyen1)
        {
            InitializeComponent();
            quyen1 = _quyen1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ktra();
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTKhoan == quyen1).FirstOrDefault();
            if (tk != null)
            {
                // Nếu tên tài khoản trùng với quyền "user", ẩn các nút
                if (tk.TenTKhoan == "user")
                {
                    
                    grbDieuKhien.Visible = false;

                }
                // Nếu tên tài khoản trùng với quyền "admin", hiển thị tất cả các nút
                else if (tk.TenTKhoan == "admin")
                {
                   
                    grbDieuKhien.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.");
            }
            loadDSLop();
        }

        private void ktra()
        {
            using (var db = new dbQLSinhVienDataContext())
            {
                var data = db.HopDongs.ToList()
                    .Select((p, index) => new
                    {
                        STT = index + 1,
                        p.SoHD,
                        NgayKy = string.Format("{0:dd-MM-yyyy}", p.NgayKy),
                        p.HeSoLuong,
                        p.MaNV,
                        NgayBatDau = string.Format("{0:dd-MM-yyyy}", p.NgayBatDau),
                        NgayKetThuc = string.Format("{0:dd-MM-yyyy}", p.NgayKetThuc)
                    })
                    .OrderBy(p => p.SoHD)
                    .ToList();

                if (data.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
                else
                {
                    dgvLop.DataSource = data;
                    MessageBox.Show($"Đã tải {data.Count} bản ghi vào DataGridView.");
                }
            }


        }
        private void loadDSLop()
        {

            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            dgvLop.DataSource = db.HopDongs.ToList()
                .Select((p, index) => new
                { 
                    STT = index + 1,
                    p.SoHD, 
                    NgayKy = string.Format("{0:dd-MM-yyyy}", p.NgayKy), 
                    p.HeSoLuong,
                    p.MaNV,
                    NgayBatDau = string.Format("{0:dd-MM-yyyy}", p.NgayBatDau),
                    NgayKetThuc = string.Format("{0:dd-MM-yyyy}", p.NgayKetThuc) 

                }).OrderBy(p => p.SoHD)
                .ToList();

        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int malop = int.Parse(txtMaLop.Text);
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            //kiem tra ton tai
            HopDong l = db.HopDongs.Where(p => p.SoHD == malop).SingleOrDefault();
            if (l != null){
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Mã lớp đã tồn tại","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLop.Focus();
                return;
            }
            l = new HopDong();
            l.SoHD = int.Parse(txtMaLop.Text);
            l.MaNV = txtTenLop.Text;
            l.HeSoLuong = short.Parse(txtSiSo.Text);
            l.NgayKy = dtpNgayKy.Value;
            l.NgayBatDau = dtpNgayBatDau.Value;
            l.NgayKetThuc = dtpNgayKetThuc. Value;
            db.HopDongs.InsertOnSubmit(l);
            db.SubmitChanges();
            //reload du lieu
            loadDSLop();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int soHD = int.Parse(txtMaLop.Text);
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();

            // Kiểm tra tồn tại của hợp đồng
            HopDong hopDong = db.HopDongs.Where(p => p.SoHD == soHD).SingleOrDefault();
            if (hopDong == null)
            {
                MessageBox.Show("Số hợp đồng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xóa các bản ghi trong NhanVien tham chiếu đến hợp đồng này
            var nhanViens = db.NhanViens.Where(nv => nv.SoHD == soHD).ToList();
            if (nhanViens.Any())
            {
                db.NhanViens.DeleteAllOnSubmit(nhanViens);
                db.SubmitChanges(); // Gửi thay đổi để xóa NhanVien trước
            }

            // Xóa hợp đồng
            db.HopDongs.DeleteOnSubmit(hopDong);
            db.SubmitChanges(); // Gửi thay đổi để xóa HopDong

            // Reload dữ liệu
            loadDSLop();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int malop = int.Parse(txtMaLop.Text);
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            //kiem tra ton tai
            HopDong l = db.HopDongs.Where(p => p.SoHD == malop).SingleOrDefault();
            if (l == null)
            {
                //du lieu da ton tai => THEM: FAILED
                MessageBox.Show("Số hợp đồng không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLop.Focus();
                return;
            }
            //ko update malop
            l.MaNV = txtTenLop.Text;
            l.HeSoLuong = short.Parse(txtSiSo.Text);
            l.NgayKy = dtpNgayKy.Value;
            l.NgayBatDau = dtpNgayBatDau.Value;
            l.NgayKetThuc = dtpNgayKetThuc.Value;
            db.SubmitChanges();
            //reload du lieu
            loadDSLop();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            //tenlop = null => FULL DS
            string tenlop = txtTenLop.Text;
            if (tenlop == "") loadDSLop();
            else
            {
                dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
                dgvLop.DataSource = db.HopDongs.Where(p=> p.MaNV.Contains(tenlop)).ToList()
                    .Select((p, index) => new { STT = index + 1, p.SoHD, p.MaNV, p.HeSoLuong, p.NgayKy, p.NgayBatDau, p.NgayKetThuc }).OrderBy(p => p.SoHD)
                    .ToList();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmHienThiHopDong frm = new frmHienThiHopDong(txtMaLop.Text,txtTenLop.Text);
            frm.ShowDialog();
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrowclick = e.RowIndex;
            
            if (idrowclick == -1) return; //dong header
            //tim malop dang chon tai dong do
            int malop = int.Parse(dgvLop[1, idrowclick].Value.ToString());
            //hien thi du lieu
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            HopDong l = db.HopDongs.Where(p => p.SoHD == malop).SingleOrDefault();
            if (l != null)
            {
               
                txtMaLop.Text = l.SoHD.ToString();
                dtpNgayKy.Value = (DateTime)l.NgayKy;
                dtpNgayBatDau.Value = (DateTime)l.NgayBatDau;
                dtpNgayKetThuc.Value = (DateTime)l.NgayKetThuc;
                txtSiSo.Text = l.HeSoLuong.ToString();
                txtTenLop.Text = l.MaNV.ToString();
            }
        }
    }
}
