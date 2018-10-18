using QLGN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace qlcv.XuLyVsDB.User
{
    class ClsDeteleUser
    {
        SqlDataHelper dh = new SqlDataHelper();
        public int DeleteUser(string Id)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@ID", Id),

                };
                dh.ExecuteNonQuery("usp_User_Bach_Delete", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }
    }
}
