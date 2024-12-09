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
    public partial class frmQuenmk : Form
    {
        public frmQuenmk()
        {
            InitializeComponent();
        }

        string taikhoan;

        public frmQuenmk(string _taikhoan)
        {
            InitializeComponent();
            taikhoan = _taikhoan;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLayotp_Click(object sender, EventArgs e)
        {
            //Gui OTP
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(p => p.TenTKhoan == taikhoan);
            if (tk != null)
            {
                Random rd = new Random();
                tk.OTP = rd.Next(1000, 9999).ToString();
                #region Gui Email xac thuc
                SendMail.sendMailTo(tk.Email, "Mã OPT xác thực là: " + tk.OTP);
                tk.OPTDateSend = DateTime.Now; // kiem soat thoi gian 5 phut hieu luc
                db.SubmitChanges();
                #endregion
                MessageBox.Show("Đã gửi OTP đến email của bạn", "Thông báo");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string matkhau = txtMatkhau.Text;
            string matkhau_2 = txtNhapLaimk.Text;
            string otp = txtOtp.Text;

            //xem otp
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(p => p.TenTKhoan == taikhoan);
            if (tk != null)
            {
                if (tk.OTP == otp)
                {
                    DateTime dateotpsend = (DateTime)tk.OPTDateSend;
                    if ((DateTime.Now - dateotpsend).TotalMinutes <= 5)
                    {
                        if (matkhau == matkhau_2)
                        {
                            //Ma hoa mat khau
                            MD5 md5 = MD5.Create();
                            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(matkhau + otp);
                            byte[] hashBytes = md5.ComputeHash(inputBytes);
                            tk.MatKhau = hashBytes;
                            tk.RamdomKey = otp;
                            tk.DateActive = DateTime.Now;
                            tk.Active = true;
                            db.SubmitChanges();
                            MessageBox.Show("Mật khẩu mới đã cài đặt thành công", "Thông báo");
                        }    
                    }
                    else
                    {
                        MessageBox.Show("Mã OTP đã hết hiệu lực. Vui lòng lấy mã OTP mới", "Thông báo");

                        btnLayotp_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Mã OTP không chính xác. Vui lòng nhập lại.", "Thông báo");
                    return;
                }
            }    

        }
    }
}
