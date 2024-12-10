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
    public partial class frmXacThuc : Form
    {
        string taikhoan;
        public frmXacThuc()
        {
            InitializeComponent();
        }

        public frmXacThuc(string _taikhoan)
        {
            InitializeComponent();
            taikhoan = _taikhoan;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuiLai_Click(object sender, EventArgs e)
        {
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

        private void btnXacThuc_Click(object sender, EventArgs e)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            TaiKhoan tk = db.TaiKhoans.SingleOrDefault(p => p.TenTKhoan == taikhoan);
            if (tk != null)
            {
                if (tk.OTP == txtOTP.Text) 
                {
                    DateTime dateotpsend = (DateTime)tk.OPTDateSend;
                    if ((DateTime.Now - dateotpsend).TotalMinutes <= 5)
                    {
                        tk.DateActive = DateTime.Now;
                        tk.Active = true;
                        db.SubmitChanges();
                        MessageBox.Show("Đã kích hoạt thành công tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mã OTP đã hết hiệu lực. Vui lòng lấy mã OTP mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        btnGuiLai_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Mã OTP không chính xác. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }    
            }
        }

        private void frmXacThuc_Load(object sender, EventArgs e)
        {
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
    }
}
