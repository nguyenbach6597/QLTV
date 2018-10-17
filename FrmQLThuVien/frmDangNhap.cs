using DevExpress.XtraRichEdit.Model;
using FrmQLThuVien;
using log4net;
using qlcv.XuLyVsDB.DangNhap;
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
    public partial class frmDangNhap : Form
    {
        private ILog lg = LogManager.GetLogger(typeof(frmDangNhap));
        clsDangNhap dn = new clsDangNhap();
        public frmDangNhap()
        {
            InitializeComponent();

        }
        private void buttonDN_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBoxTK.Text;
                string password = Utils.CreateMD5(textBoxMK.Text);
                DataTable dt = dn.Select_login(username, password);
                //Nếu select không có row nào thì thông báo không cho đăng nhập
                //Nếu select mà có row -> có tài khoản và pass word đó thì cho đăng nhâp -> vào main chính  frmMain

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ", "Cảnh báo");

                }
                else
                {

                    FrmMain dn = new FrmMain(true);
                    dn.Show();
                    //Cache.username = username;
                    //Cache.idUser = Int32.Parse(dt.Rows[0]["ID"].ToString());

                }
                #region
                //User login = Retrofit.instance.Login(username, password);
                //Console.Write(login);
                //if (login != null)
                //{
                //    if (login.status)
                //    {
                //        Cache.username = username;
                //        Networking.getInstance().setToken(login.Token);
                //        frmMain frMenu = new frmMain(login.IsAdmin);
                //        frMenu.Show();
                //        this.Hide();
                //        if (cbGhiNho.Checked)
                //        {
                //            Properties.Settings.Default.user = username;
                //            Properties.Settings.Default.password = password;
                //            Properties.Settings.Default.Save();
                //        }
                //        else
                //        {
                //            Properties.Settings.Default.user = "";
                //            Properties.Settings.Default.password = "";
                //            Properties.Settings.Default.Save();
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng", "Thông báo");
                //    }
                //}
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    textBoxTK.Text = Properties.Settings.Default.user;
            //    textBoxMK.Text = Properties.Settings.Default.password;
            //    cbGhiNho.Checked = textBoxTK.Text != "" && textBoxMK.Text != "";
            //}
            //catch (Exception ex)
            //{
            //    lg.Error(ex);
            //}

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
