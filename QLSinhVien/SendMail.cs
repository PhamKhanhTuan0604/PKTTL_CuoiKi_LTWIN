﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien
{
    public static class SendMail
    {
        public static string taikhoan = "ctypkttl@gmail.com";
        public static string matkhau = "Alpha$4869!";

        public static bool sendMailTo(string emailto, string content)
        {
            var fromAddress = new MailAddress("taikhoan", "Admin Công ty PKTTL");
            var toAddress = new MailAddress(emailto, emailto);
            string fromPassword = matkhau;
            string subject = "Thông báo từ Công ty PKTTL";
            string body = content;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            try
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
