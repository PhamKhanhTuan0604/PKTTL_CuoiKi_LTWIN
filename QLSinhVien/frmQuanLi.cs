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
    public partial class frmQuanLi : Form
    {
        private static string quyen;

        public frmQuanLi(string username)
        {
            InitializeComponent();
            quyen = username;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmHocSinh frmNV = new frmHocSinh(quyen);
            frmNV.TopLevel = false;
            panel1.Controls.Add(frmNV);
            frmNV.Dock = DockStyle.Fill;
            frmNV.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fmrLuongNV frmLuong = new fmrLuongNV(quyen);
            frmLuong.TopLevel = false;
            panel1.Controls.Add(frmLuong);
            frmLuong.Dock = DockStyle.Fill;
            frmLuong.Show();
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            frmAboutUs frmAboutUs = new frmAboutUs();
            frmAboutUs.TopLevel = false;
            panel1.Controls.Add(frmAboutUs);
            frmAboutUs.Dock = DockStyle.Fill;
            frmAboutUs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDiemDanh frm = new frmDiemDanh(quyen);
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmHopDong frm = new frmHopDong(quyen);
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btnDK_TaiKhoan_Click(object sender, EventArgs e)
        {
            frmDangKy frm = new frmDangKy();
            frm.TopLevel = false;
            panel1.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void frmQuanLi_Load_1(object sender, EventArgs e)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.Where(p => p.TenTKhoan == frmDangNhap.tenTK).FirstOrDefault();
            if(tk != null)
            {
                // Nếu tên tài khoản trùng với quyền "user", ẩn các nút
                if (quyen == "user")
                {
                    btnAboutUs.Visible = false;
                    btnDK_TaiKhoan.Visible = false;

                }
                // Nếu tên tài khoản trùng với quyền "admin", hiển thị tất cả các nút
                else if (quyen == "admin")
                {

                    btnAboutUs.Visible = true;
                    btnDK_TaiKhoan.Visible = true;
                }
            }    
            else
            {
                MessageBox.Show("Tài khoản không tồn tại.");
                return;
            }

        }

        private void btnTangCa_Click(object sender, EventArgs e)
        {
            frmTangCa frm = new frmTangCa(quyen);            
            frm.TopLevel = false;   
            panel1.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;      
            frm.Show();
                                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            this.Close();
            frm.Show();
        }
    }
}
