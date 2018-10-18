using QLGN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace qlcv.XuLyVsDB.User
{
    public class ClsThemNhanVien
    {
      
        SqlDataHelper dh = new SqlDataHelper();

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
        public int UpdateNhanVien(int ID,string Name, string Username)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@ID", ID)

                };
                dh.ExecuteNonQuery("usp_Admin_UpdateNhanVien", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
        public int DeleteNhanVien(int ID)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@ID", ID)

                };
                dh.ExecuteNonQuery("usp_Admin_DeleteNhanVien", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
    }
    }
