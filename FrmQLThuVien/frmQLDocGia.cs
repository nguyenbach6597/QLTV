using DevExpress.XtraLayout.Utils;
using FrmQLThuVien;
using FrmQLThuVien.ObjClass;
using FrmQLThuVien.XuLyDb.DocGia;
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
    public partial class frmQLDocGia : Form
    {
        private ILog lg = LogManager.GetLogger(typeof(frmQLDocGia));
        public frmQLDocGia()
        {
            InitializeComponent();
        }


        private void LoadMau()
        {
            //layoutControlGroup2.AppearanceGroup.BorderColor = Setting.GroupColor();

        }
        List<BanDoc> us;
        private void LoadNhanVien()
        {
            try
            {

                SelectDocGia sl = new SelectDocGia();
                us = sl.List_SelectDocGia();
                gc.DataSource = us;
            }
            catch (Exception ex)
            {
                lg.Error(ex);
            }
        }
        private void Hien()
        {
            txtHoTen.Enabled = true;
            txtSoDienThoai.Enabled = true;
            txtUUID.Enabled = true;

        }
        private void An()
        {
            txtHoTen.Enabled = false;
            txtSoDienThoai.Enabled = false;
            txtUUID.Enabled = false;

        }
        bool checkThem;
        private void sbThem_Click(object sender, EventArgs e)
        {
            Hien();
            checkThem = true;

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkThem)
                {

                    //Thêm độc giả
                    //string Name, DateTime DateCreate, string PhoneNumber, string UUID
                    InsertDocGia insert = new InsertDocGia();
                    if (txtHoTen.Text.Trim().Length == 0 || txtSoDienThoai.Text.Trim().Length == 0 || txtUUID.Text.Trim().Length == 0)
                    {

                        MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    int check = insert.InserDocGia(txtHoTen.Text, DateTime.Now,txtSoDienThoai.Text,txtUUID.Text);
                    if (check == 0)
                    {

                        txtHoTen.ResetText();
                        txtUUID.ResetText();
                        txtSoDienThoai.ResetText();
                        MessageBox.Show("Thêm độc giả thành công", "Thông báo");
                        LoadNhanVien();
                        An();


                    }

                }
                else
                {
                    //Sửa thì vào đây!
                    //string ID, string Name, DateTime DateCreate, string PhoneNumber , string UUID
                    UpdateDocGia update = new UpdateDocGia();
                    if (txtHoTen.Text.Trim().Length == 0 || txtSoDienThoai.Text.Trim().Length == 0 || txtUUID.Text.Trim().Length == 0)
                    {

                        MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    int check = update.UpdateReader(maDocGia, txtHoTen.Text,txtSoDienThoai.Text,txtUUID.Text);
                    if (check == 0)
                    {

                        txtHoTen.ResetText();
                        txtUUID.ResetText();
                        txtSoDienThoai.ResetText();
                        MessageBox.Show("Sửa độc giả thành công", "Thông báo");
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
        int maDocGia;
        string tenDocGia;
        string soDienThoai;
        private void btSua_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = true;
            txtUUID.Enabled = true;
            txtSoDienThoai.Enabled=true;
            maDocGia = Int32.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
            txtHoTen.Text = gv.GetRowCellValue(gv.FocusedRowHandle, "Name").ToString();
            txtSoDienThoai.Text = gv.GetRowCellValue(gv.FocusedRowHandle, "PhoneNumber").ToString();
            txtUUID.Text= gv.GetRowCellValue(gv.FocusedRowHandle, "UUID").ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //Xóa thì vào đây
            maDocGia = Int32.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
            DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
            {
                DeleteDocGia delete = new DeleteDocGia();
                int check = delete.XoaDocGia(maDocGia);
                if (check == 0)
                {

                    txtHoTen.ResetText();
                    txtUUID.ResetText();
                    txtSoDienThoai.ResetText();
                    MessageBox.Show("Xóa độc giả thành công", "Thông báo");
                    LoadNhanVien();
                }
            }
           

        }
    }
}
