using QLGN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace qlcv.XuLyVsDB.User
{
    class ClsUpdateUser
    {
        SqlDataHelper dh = new SqlDataHelper();
        DataTable dt = new DataTable();
        public int UpdateUser(string ID, string Name, string DiaChi, string SoDienThoai, string Username, string Mail, bool
            GioiTinh, DateTime NgaySinh, bool IsAdmin, bool ThemDuAn)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@Name",Name),
                    new SqlParameter("@Diachi", DiaChi),
                    new SqlParameter("@sdt", SoDienThoai),
                    new SqlParameter("@mail", Mail ),
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@Gioitinh", GioiTinh),
                    new SqlParameter("@NgaySinh", NgaySinh),
                    new SqlParameter("@isAdmin", IsAdmin),
                    new SqlParameter("@ThemDuAn", ThemDuAn),



                };
                dh.ExecuteNonQuery("usp_User_Bach_UpdateUser", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }
       

    }
}