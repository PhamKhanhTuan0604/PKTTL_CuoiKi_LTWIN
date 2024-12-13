﻿using Microsoft.Reporting.WinForms;
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
    public partial class frmXinNghiPrinter : Form
    {
        /*public frmXinNghiPrinter()
        {
            
        }*/

        string Lydo;
        public frmXinNghiPrinter(string _Lydo)
        {
            InitializeComponent();
            Lydo = _Lydo;
        }

        private void frmXinNghiPrinter_Load(object sender, EventArgs e)
        {
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();

            List<ChiTietNghiPhep> lst = new List<ChiTietNghiPhep>();
            if(Lydo == "")
            {
                Lydo = "Tất cả";
                lst = db.ChiTietNghiPheps.ToList();
            }
            else
            {
                lst = db.ChiTietNghiPheps.Where(p => p.LyDo.Contains(Lydo) || p.MaNV.Contains(Lydo)).ToList();
            }    

            ReportParameter[] para = new ReportParameter[2];
            para[0] = new ReportParameter("Nguoidung", frmNghiPhep.username);
            para[1] = new ReportParameter("Lydonghi", Lydo);
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource(
                "DataSetXinNghi", lst));
            this.reportViewer1.RefreshReport();
        }
    }
}
