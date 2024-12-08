using Microsoft.Reporting.WinForms;
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
    public partial class frmHienThiHopDong : Form
    {
        public frmHienThiHopDong()
        {
            InitializeComponent();
        }

        string _maHD, _maNV; //nhan du lieu tu formHocSinh (in theo lop nao?)
        public frmHienThiHopDong(string maHD, string maNV)
        {
            InitializeComponent();
            _maHD = maHD; _maNV = maNV;
        }

        private void frmHienThiHopDong_Load(object sender, EventArgs e)
        {
            //Nap du lieu
            dbQLSinhVienDataContext db = new dbQLSinhVienDataContext();
            List<HopDong> lst = new List<HopDong>();
            if (_maHD == "")
            {
                _maNV = "All";
                lst = db.HopDongs.ToList();
            }
            else lst = db.HopDongs.Where(p => p.SoHD.ToString() == _maHD).ToList();
            //Nap du lieu parameter report
            ReportParameter[] parameter = new ReportParameter[2];
            parameter[0] = new ReportParameter("paSoHD", _maHD);
            parameter[1] = new ReportParameter("paMaNV", _maNV);
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", lst));
            reportViewer2.LocalReport.SetParameters(parameter);
            //Xuat du lieu
            this.reportViewer2.RefreshReport();
           
        }
    }
}
