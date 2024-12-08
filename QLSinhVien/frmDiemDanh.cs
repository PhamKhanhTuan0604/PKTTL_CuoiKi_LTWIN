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
    public partial class frmDiemDanh : Form
    {
        private dbQLSinhVienDataContext db;
        private static string _quyen;
        public frmDiemDanh(string _Phanquyen)
        {
            InitializeComponent();
            db = new dbQLSinhVienDataContext();
            setupDataGridView();
            _quyen = _Phanquyen;    
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Dispose();
        }

        private void frmDiemDanh_Load(object sender, EventArgs e)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTKhoan == _quyen).FirstOrDefault();
            if (tk != null)
            {
                // Nếu tên tài khoản trùng với quyền "user", ẩn các nút
                if (tk.TenTKhoan == "user")
                {
                    btn_diemdanh.Visible = false;
                    btnReload.Visible = false;
                   
                }
                // Nếu tên tài khoản trùng với quyền "admin", hiển thị tất cả các nút
                else if (tk.TenTKhoan == "admin")
                {
                    btn_diemdanh.Visible = true;
                    btnReload.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.");
            }
            initData();
        }
        private void initData()
        {
            loadPhongBan();
            loadChucVu();
            loadNhanVien();
            loadDiemDanh();
        }

        private void setupDataGridView()
        {
            // Định nghĩa các cột
            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
            sttColumn.HeaderText = "STT";
            sttColumn.DataPropertyName = "STT";
            sttColumn.MinimumWidth = 6;
            sttColumn.Width = 50;
            dgvHS.Columns.Add(sttColumn);

            DataGridViewTextBoxColumn maNVColumn = new DataGridViewTextBoxColumn();
            maNVColumn.HeaderText = "Mã nhân viên";
            maNVColumn.DataPropertyName = "MaNV";
            maNVColumn.MinimumWidth = 6;
            maNVColumn.Width = 125;
            dgvHS.Columns.Add(maNVColumn);

            DataGridViewTextBoxColumn tenNhanVienColumn = new DataGridViewTextBoxColumn();
            tenNhanVienColumn.HeaderText = "Tên nhân viên";
            tenNhanVienColumn.DataPropertyName = "TenNhanVien";
            tenNhanVienColumn.MinimumWidth = 6;
            tenNhanVienColumn.Width = 200;
            dgvHS.Columns.Add(tenNhanVienColumn);

            DataGridViewTextBoxColumn chucVuColumn = new DataGridViewTextBoxColumn();
            chucVuColumn.HeaderText = "Chức vụ";
            chucVuColumn.DataPropertyName = "ChucVu";
            chucVuColumn.MinimumWidth = 6;
            chucVuColumn.Width = 150;
            dgvHS.Columns.Add(chucVuColumn);

            DataGridViewTextBoxColumn soNgayLamViecColumn = new DataGridViewTextBoxColumn();
            soNgayLamViecColumn.HeaderText = "Số ngày làm việc";
            soNgayLamViecColumn.DataPropertyName = "SoNgayLamViec";
            soNgayLamViecColumn.MinimumWidth = 6;
            soNgayLamViecColumn.Width = 125;
            dgvHS.Columns.Add(soNgayLamViecColumn);
        }

        private void loadNhanVien()
        {
            // Khởi tạo truy vấn cơ bản
            var query = db.NhanViens.AsQueryable();

            // Kiểm tra giá trị của cbbChucvu.SelectedValue
            if (cbbChucvu.SelectedValue != null)
            {
                ChucVu selectedChucVu = (ChucVu)cbbChucvu.SelectedItem;

                // Truy cập MaChucVu
                string maChucVu = selectedChucVu.MaChucVu;

                if (maChucVu != "")
                {
                    query = query.Where(p => p.MaChucVu == maChucVu);
                }
            }
            // Kiểm tra giá trị của cbbPhong.SelectedValue
            if (cbbPhong.SelectedValue != null)
            {
                PhongBan selectedPhongBan = (PhongBan)cbbPhong.SelectedItem;

                // Truy cập MaPhongBan
                string maPhongBan = selectedPhongBan.MaPhongBan;

                if (maPhongBan != "")
                {
                    query = query.Where(p => p.MaPhongBan == maPhongBan);
                }
            }

            // Thực hiện truy vấn và sắp xếp kết quả theo TenNV
            List<NhanVien> lst = query.OrderBy(p => p.TenNV).ToList();
            NhanVien l = new NhanVien(); l.MaNV = ""; l.TenNV = "Tất cả";
            lst.Insert(0, l);
            cbbNhansu.DataSource = lst;
            cbbNhansu.DisplayMember = "TenNV";
            cbbNhansu.ValueMember = "MaNV";
        }

        private void loadPhongBan()
        {
            List<PhongBan> lst = db.PhongBans.OrderBy(p => p.TenPhongBan).ToList();
            PhongBan l = new PhongBan(); l.MaPhongBan = ""; l.TenPhongBan = "Tất cả";
            lst.Insert(0, l);
            cbbPhong.DataSource = lst;
            cbbPhong.DisplayMember = "TenPhongBan";
            cbbPhong.ValueMember = "MaPhongBan";
        }

        private void loadChucVu()
        {
            // Khởi tạo truy vấn cơ bản
            var query = db.ChucVus.AsQueryable();

            // Kiểm tra giá trị của cbbPhong.SelectedValue
            if (cbbPhong.SelectedValue != null)
            {
                PhongBan selectedPhongBan = (PhongBan)cbbPhong.SelectedItem;

                // Truy cập MaPhongBan
                string maPhongBan = selectedPhongBan.MaPhongBan;

                if(maPhongBan != "")
                {
                    query = query.Where(p => p.MaPhongBan == maPhongBan);
                }
            }

            // Thực hiện truy vấn và sắp xếp kết quả theo TenNV
            List<ChucVu> lst = query.OrderBy(p => p.TenChucVu).ToList();

            ChucVu l = new ChucVu(); l.MaChucVu = ""; l.TenChucVu = "Tất cả";
            lst.Insert(0, l);
            cbbChucvu.DataSource = lst;
            cbbChucvu.DisplayMember = "TenChucVu";
            cbbChucvu.ValueMember = "MaChucVu";
        }

        private void loadDiemDanh()
        {
            // Truy vấn dữ liệu từ bảng DiemDanh và NhanVien
            var query = from nv in db.NhanViens
                        join dd in db.DiemDanhs on nv.MaNV equals dd.MaNV into diemdanhGroup
                        select new
                        {
                            MaChucVu = nv.MaChucVu,
                            MaPhongBan = nv.MaPhongBan,
                            MaNV = nv.MaNV,
                            ChucVu = nv.ChucVu.TenChucVu,
                            TenNhanVien = nv.TenNV,
                            SoNgayLamViec = diemdanhGroup.Count()
                        };
            // Kiểm tra giá trị của cbbChucvu.SelectedValue
            if (cbbChucvu.SelectedValue != null)
            {
                ChucVu selectedChucVu = (ChucVu)cbbChucvu.SelectedItem;

                // Truy cập MaChucVu
                string maChucVu = selectedChucVu.MaChucVu;

                if (maChucVu != "")
                {
                    query = query.Where(p => p.MaChucVu == maChucVu);
                }
            }
            // Kiểm tra giá trị của cbbPhong.SelectedValue
            if (cbbPhong.SelectedValue != null)
            {
                PhongBan selectedPhongBan = (PhongBan)cbbPhong.SelectedItem;

                // Truy cập MaPhongBan
                string maPhongBan = selectedPhongBan.MaPhongBan;

                if (maPhongBan != "")
                {
                    query = query.Where(p => p.MaPhongBan == maPhongBan);
                }
            }
            // Kiểm tra giá trị của cbbNhansu.SelectedValue
            if (cbbNhansu.SelectedValue != null)
            {
                NhanVien selectedNhanVien = (NhanVien)cbbNhansu.SelectedItem;

                // Truy cập MaPhongBan
                string maNhanVien = selectedNhanVien.MaNV;

                if (maNhanVien != "")
                {
                    query = query.Where(p => p.MaNV == maNhanVien);
                }
            }
            // Chuyển kết quả truy vấn thành danh sách và gán vào DataGridView
            var result = query.ToList();
            dgvHS.DataSource = result.Select((item, index) => new
            {
                STT = index + 1,
                item.MaNV,
                item.TenNhanVien,
                item.ChucVu,
                item.SoNgayLamViec
            }).ToList();
        }

        private void btn_diemdanh_Click(object sender, EventArgs e)
        {
            string maNhanVien = (string)cbbNhansu.SelectedValue;
            if(maNhanVien == "")
            {
                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string tenNhanVien = cbbNhansu.Text;
            LuuThongTinDiemDanh(maNhanVien);
            MessageBox.Show("Đã điểm danh thành công cho nhân viên: " + tenNhanVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LuuThongTinDiemDanh(string maNhanVien)
        {
            DiemDanh diemDanh = new DiemDanh();
            diemDanh.MaDiemDanh = GenerateRandomString(20);
            diemDanh.MaNV = maNhanVien;
            diemDanh.NgayDiemDanh = dateTimePicker1.Value;
            db.DiemDanhs.InsertOnSubmit(diemDanh);
            db.SubmitChanges();
            initData();
        }

        private void cbbPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChucVu();
            loadNhanVien();
            loadDiemDanh();
        }

        private void cbbChucvu_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadNhanVien();
            loadDiemDanh();
        }

        private void cbbNhansu_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDiemDanh();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            initData();
        }

        // Tạo khóa cho bảng DiemDanh
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
