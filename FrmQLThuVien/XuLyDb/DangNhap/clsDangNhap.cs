using QLGN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace qlcv.XuLyVsDB.DangNhap
{
    public class clsDangNhap
    {
        SqlDataHelper dh = new SqlDataHelper();

        #region select
        public DataTable Select_login(string user,string pass)
        {
            DataTable dt;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@Username", user),
                    new SqlParameter("@Password",pass),

                };
                dt = dh.ExecuteDataSet("usp_Login", pa).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion

    }
}
