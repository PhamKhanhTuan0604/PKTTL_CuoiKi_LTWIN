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

namespace QLSinhVien
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            /*
            string username = txtTenTK_DK.Text;
            string password = txtMK_DK.Text;
            string confirmPassword = txtNhapLaiMK.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            using (var context = new dbQLSinhVienDataContext()) // Replace YourDataContext with your DataContext class
            {
                // Check if username already exists
                var existingUser = context.TaiKhoans.FirstOrDefault(u => u.TenTKhoan == username);

                if (existingUser != null)
                {
                    MessageBox.Show("Username already exists!");
                    return;
                }

                // Create a new user object
                var newUser = new TaiKhoan
                {
                    TenTKhoan = username,
                    MatKhau = password
                    // You can add more properties here if needed
                };

                // Add the new user to the Users table
                context.TaiKhoans.InsertOnSubmit(newUser);
                context.SubmitChanges();

                MessageBox.Show("Registration successful!");
            
            }
            */

            #region Tao tai khoan moi va ma hoa mat khau
            //Kiem tra du lieu dien day du
            if(txtTenTK_DK.Text == "" || txtMK_DK.Text == "" || txtEmail.Text == ""
                || txtNhapLaiMK.Text == "" /*|| txtOTP.Text == ""*/)
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin", "Thông báo");
                return;
            }     

            //Kiem tra trung lap mat khau
            if(txtMK_DK.Text != txtNhapLaiMK.Text)
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo");
                txtMK_DK.Focus();
                return;
            }

            //Tao ma OTP ngau nhien
            string taikhoan = txtTenTK_DK.Text;
            string matkhau = txtMK_DK.Text;
            string email = txtEmail.Text;
            Random rd = new Random();
            string otp = rd.Next(1000, 9999).ToString();

            //Ma hoa mat khau
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matkhau+otp);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            //Tao va them du lieu vao database
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = new TaiKhoan();
            tk.TenTKhoan = taikhoan;
            tk.MatKhau = hashBytes; // Mat khau da ma khoa
            tk.Email = email;
            tk.OTP = otp;
            tk.OPTDateSend = DateTime.Now;
            tk.DateCreated = DateTime.Now;
            tk.DateActive = null;
            tk.LevelID = 0;
            tk.Active = false;

            db.TaiKhoans.InsertOnSubmit(tk); // chen vo csdl
            db.SubmitChanges(); // dong bo csdl
            MessageBox.Show("Tạo tài khoản thành công!", "Thông báo");
            #endregion
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
