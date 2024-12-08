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
    public partial class frmAboutUs : Form
    {
        public frmAboutUs()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmAboutUs
            // 
            this.BackgroundImage = global::QLSinhVien.Properties.Resources.Screenshot_2024_11_30_101608;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1665, 729);
            this.DoubleBuffered = true;
            this.Name = "frmAboutUs";
            this.ResumeLayout(false);

        }
    }
}
