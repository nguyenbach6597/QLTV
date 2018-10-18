using QLGN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace qlcv.XuLyVsDB.User
{
    class ClsThemNhanVien
    {
        private bool @checked;
        private DateTime dateTime;
        SqlDataHelper dh = new SqlDataHelper();
        public bool ThemDuAn { get; internal set; }

        public int InsertNhanVien( string Name, string Username, string Password)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@PassWord", Password)

                };
                dh.ExecuteNonQuery("usp_Admin_addNhanVien", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
    }
    }
