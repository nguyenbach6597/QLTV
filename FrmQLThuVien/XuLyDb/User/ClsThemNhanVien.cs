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

        public int InsertNhanVien( string Name, string DiaChi, string SoDienThoai, string Username, string Password , string Mail, bool GioiTinh, DateTime NgaySinh, bool IsAdmin, bool ThemDuAn)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Diachi", DiaChi),
                    new SqlParameter("@sdt", SoDienThoai),
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@Ngaysinh", NgaySinh),
                    new SqlParameter("@PassWord", Password),
                    new SqlParameter("@Gioitinh", GioiTinh),
                    new SqlParameter("@mail", Mail),
                    new SqlParameter("@isAdmin", IsAdmin),
                    new SqlParameter("@ThemDuAn", ThemDuAn),

                };
                dh.ExecuteNonQuery("usp_User_Bach_Insert", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
    }
    }
