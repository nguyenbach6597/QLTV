using qlcv;
using log4net;
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
        private ILog lg = LogManager.GetLogger(typeof(FrmMain));
        public static bool isAdmin;
        public FrmMain(bool isAdmin)
        {
            InitializeComponent();
            FrmMain.isAdmin = isAdmin;
        }
        private void LoadPhanQuyen()
        {
            try
            {
                txtTaiKhoan.Caption = "Chúc " + Cache.username + " có một ngày tốt lành!";
                if (!isAdmin)
                {
                    btCongViec.Enabled = false;
                    btDuAn.Enabled = false;
                    btNhanVien.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                lg.Error(ex);
            }

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void btNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhanVien fm = new frmNhanVien();
            fm.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLDocGia fm = new frmQLDocGia();
            fm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmQLNhaXuatBan frm = new frmQLNhaXuatBan();
            frm.Show();
        }
    }
}
