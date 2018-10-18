using DevExpress.XtraLayout.Utils;
using FrmQLThuVien;
using log4net;
using qlcv.XuLyVsDB.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qlcv
{
    public partial class frmNhanVien : Form
    {
        private ILog lg = LogManager.GetLogger(typeof(frmNhanVien));
        public frmNhanVien()
        {
            InitializeComponent();
        }

       
        private void LoadMau()
        {
            //layoutControlGroup2.AppearanceGroup.BorderColor = Setting.GroupColor();

        }
        List<SelectUser> us;
        private void LoadNhanVien()
        {
            try
            {

                SelectUser sl = new SelectUser();
                us = sl.List_SelectUser();
                gridControl1.DataSource = us;
            }
            catch (Exception ex)
            {
                lg.Error(ex);
            }
        }
        private void Hien() {
            tbName.Enabled = true;
            tbUsername.Enabled = true;
            tbPass.Enabled = true;

        }

        private void sbThem_Click(object sender, EventArgs e)
        {
            Hien();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {

                //Thêm người dùng mới
                //User user = new User
                ClsThemNhanVien user = new ClsThemNhanVien();
                //user.ThemDuAn = cbThemDA.Checked;
                //StatusRespon status = Retrofit.instance.addUser(user);
                //MessageBox.Show(status.Message);
                //LoadNhanVien();
                int check = user.InsertNhanVien(tbName.Text, tbUsername.Text, Utils.CreateMD5(tbPass.Text));
                if (check == 0)
                {

                    tbName.ResetText();
                    tbPass.ResetText();
                    tbUsername.ResetText();
                }
            }
            catch (Exception ex)
            {
                lg.Error(ex);
            }
        }
       
        private void tbUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmNhanVien_Load_1(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadMau();
            layoutControlGroup2.Visibility = FrmMain.isAdmin ? LayoutVisibility.Always : LayoutVisibility.Never;
        }


    }
}
