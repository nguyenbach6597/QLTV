using DevExpress.XtraLayout.Utils;
using FrmQLThuVien;
using FrmQLThuVien.ObjClass;
using FrmQLThuVien.XuLyDb.DocGia;
using FrmQLThuVien.XuLyDb.NhaXuatBan;
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
    public partial class frmQLNhaXuatBan : Form
    {
        private ILog lg = LogManager.GetLogger(typeof(frmQLNhaXuatBan));
        clsNhaXuatBan cls = new clsNhaXuatBan();
        public frmQLNhaXuatBan()
        {
            InitializeComponent();
        }


        private void LoadMau()
        {
            //layoutControlGroup2.AppearanceGroup.BorderColor = Setting.GroupColor();

        }
        List<NhaXuatBanOBJ> us;
        private void LoadData()
        {
            try
            {
                us = cls.List_Select();
                gc.DataSource = us;
            }
            catch (Exception ex)
            {
                lg.Error(ex);
            }
        }
        private void Hien()
        {
            txtTenNXB.Enabled = true;


        }
        private void An()
        {
            txtTenNXB.Enabled = false;


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
                    if (txtTenNXB.Text.Trim().Length == 0 )
                    {

                        MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    int check = cls.InsertNhaXuatBan(txtTenNXB.Text);
                    if (check == 0)
                    {

                        txtTenNXB.ResetText();
                        MessageBox.Show("Thêm nhà xuất bản thành công", "Thông báo");
                        LoadData();
                        An();


                    }

                }
                else
                {
                    //Sửa thì vào đây!
                    //string ID, string Name, DateTime DateCreate, string PhoneNumber , string UUID
                    UpdateDocGia update = new UpdateDocGia();
                    if (txtTenNXB.Text.Trim().Length == 0 )
                    {

                        MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                    int check = cls.UpdateNhaXuatBan(maNXB, txtTenNXB.Text);
                    if (check == 0)
                    {

                        txtTenNXB.ResetText();
                        MessageBox.Show("Sửa nhà xuất bản thành công", "Thông báo");
                        LoadData();
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
            LoadData();
            LoadMau();
            layoutControlGroup2.Visibility = FrmMain.isAdmin ? LayoutVisibility.Always : LayoutVisibility.Never;
        }
        int maNXB;
        string tenDocGia;
        string soDienThoai;
        private void btSua_Click(object sender, EventArgs e)
        {
            txtTenNXB.Enabled = true;
            maNXB = Int32.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
            txtTenNXB.Text = gv.GetRowCellValue(gv.FocusedRowHandle, "Name").ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //Xóa thì vào đây
            //maNXB = Int32.Parse(gv.GetRowCellValue(gv.FocusedRowHandle, "ID").ToString());
            //DialogResult dl = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dl == DialogResult.Yes)
            //{
            //    DeleteDocGia delete = new DeleteDocGia();
            //    int check = cls(maNXB);
            //    if (check == 0)
            //    {

            //        txtTenNXB.ResetText();
            //        MessageBox.Show("Xóa nhà xuất bản thành công", "Thông báo");
            //        Load();
            //    }
            //}
           

        }
    }
}
