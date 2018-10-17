using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmQLThuVien
{
    public partial class FrmMain : Form
    {
        public static bool isAdmin;
        public FrmMain(bool isAdmin)
        {
            InitializeComponent();
            FrmMain.isAdmin = isAdmin;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
