using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
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
        }
    }
}
