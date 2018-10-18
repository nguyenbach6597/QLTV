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
        ClsThemNhanVien user = new ClsThemNhanVien();
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
                gc.DataSource = us;
            }
            catch (Exception ex)
            {
                lg.Error(ex);
            }
        }
        private void Hien()
        {
            tbName.Enabled = true;
            tbUsername.Enabled = true;
            tbPass.Enabled = true;
            layoutControlItem13.Visibility = LayoutVisibility.Never;

        }
        private void An()
        {
            tbName.Enabled = false;
            tbUsername.Enabled = false;
            tbPass.Enabled = false;

        }
        bool checkThem;
        private void sbThem_Click(object sender, EventArgs e)
        {
            Hien();
            checkThem = true;
            layoutControlItem13.Visibility = LayoutVisibility.Always;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkThem)
                {

                    //Thêm người dùng mới
                    //User user = new User
                   
                    //user.ThemDuAn = cbThemDA.Checked;
                    //StatusRespon status = Retrofit.instance.addUser(user);
                    //MessageBox.Show(status.Message);
                    //LoadNhanVien();
                    if (tbName.Text.Trim().Length == 0 || tbUsername.Text.Trim().Length == 0 || tbPass.Text.Trim().Length == 0)
                    {

                        MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    int check = user.InsertNhanVien(tbName.Text, tbUsername.Text, Utils.CreateMD5(tbPass.Text));
                    if (check == 0)
                    {

                        tbName.ResetText();
                        tbPass.ResetText();
                        tbUsername.ResetText();
                        MessageBox.Show("Thêm nhân viên thành công", "Thông báo");
                        LoadNhanVien();
                        An();


                    }

                }
                else
                {
                    //Sửa thì vào đây!
                    if (tbName.Text.Trim().Length == 0 || tbUsername.Text.Trim().Length == 0)
                    {

                        MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    int check = user.UpdateNhanVien(maNhanVien,tbName.Text, tbUsername.Text);
                    if (check == 0)
                    {

                        tbName.ResetText();
                        tbPass.ResetText();
                        tbUsername.ResetText();
                        MessageBox.Show("Sửa nhân viên thành công", "Thông báo");
                        LoadNhanVien();
                        An();
                    }

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
        int maNhanVien;
        string tenNhanVien;
        string userName;
        private void btSua_Click(object sender, EventArgs e)
        {
            tbName.Enabled = true;
            tbPass.Enabled = true;
            tbUsername.Enabled=true;
            layoutControlItem13.Visibility = LayoutVisibility.Never;
            maNhanVien = Int32.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
            tbName.Text = gv.GetRowCellValue(gv.FocusedRowHandle, "Name").ToString();
            tbUsername.Text = gv.GetRowCellValue(gv.FocusedRowHandle, "Username").ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //Xóa thì vào đây
            maNhanVien = Int32.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                int check = user.DeleteNhanVien(maNhanVien);
                if (check == 0)
                {

                    tbName.ResetText();
                    tbPass.ResetText();
                    tbUsername.ResetText();
                    MessageBox.Show("Xóa nhân viên thành công", "Thông báo");
                    LoadNhanVien();
                }
            }
           

        }
    }
}
