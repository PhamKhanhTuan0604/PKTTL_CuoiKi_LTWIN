using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLSinhVien
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public static string tenTK; // dung de xac dinh ten tai khoan cho cac form khac


        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                txtTaiKhoan.Focus();
                return;
            }
            else
            {
                dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
                TaiKhoan tk = db.TaiKhoans.SingleOrDefault(p => p.TenTKhoan == username);
                if (tk != null)
                {
                    //Kiem tra trang thai active chua => Nhap du lieu ma OTP
                    if(tk.Active == false)
                    {
                        MessageBox.Show("Tài khoản chưa xác thực. Vui lòng nhập OTP để xác thực!", "Thông báo");
                        frmXacThuc frm = new frmXacThuc(tk.TenTKhoan);
                        frm.Show();
                        return;
                    }    

                    #region kiem tra mat khau dang luu tru
                    MD5 md5 = MD5.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password+tk.RamdomKey);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    if(tk.MatKhau == hashBytes)
                    {
                        if(tk.LevelID == 1)
                        {
                            string quyen = "admin";
                            MessageBox.Show("Chào mừng admin " + username + " quay trở lại!", "Thông báo", MessageBoxButtons.OK);
                            tenTK = txtTaiKhoan.Text;
                            frmQuanLi frm = new frmQuanLi(quyen);
                            frm.Show();
                            this.Hide(); // Ẩn form đăng nhập
             
                        }    
                        if(tk.LevelID == 0)
                        {
                            string quyen = "user";
                            MessageBox.Show("Xin chào " + username + " quay trở lại!", "Thông báo", MessageBoxButtons.OK);
                            tenTK = txtTaiKhoan.Text;
                            frmQuanLi frm = new frmQuanLi(quyen);
                            frm.Show();
                            this.Hide(); // Ẩn form đăng nhập
                        }
                        return;
                        
                    }    
                    #endregion

                }
                
    
                 MessageBox.Show("Tài khoản không tồn tại. Mời nhập lại!!", "Thông báo", MessageBoxButtons.OK);
                 txtTaiKhoan.Focus();
                 return;
        
            }
                
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy frm = new frmDangKy();    
            frm.ShowDialog();   
        }

        private void chkMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMK.Checked) txtMatKhau.UseSystemPasswordChar = false;
            else txtMatKhau.UseSystemPasswordChar = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuenmk_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            if (username == "")
            {
                MessageBox.Show("Mời bạn nhập tên tài khoản", "Thông báo", MessageBoxButtons.OK);
                txtTaiKhoan.Focus();
                return;
            }
            else
            {
                dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
                TaiKhoan tk = db.TaiKhoans.SingleOrDefault(p => p.TenTKhoan == username);
                if (tk != null)
                {
                    frmQuenmk frm = new frmQuenmk(username);
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }
    }
}
