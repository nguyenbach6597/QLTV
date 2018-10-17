using QLGN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace qlcv.XuLyVsDB.User
{
    class SelectUser
    {

        SqlDataHelper dh = new SqlDataHelper();
        DataTable dt = new DataTable();
        
        public bool IsAdmin { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public List<SelectUser> List_SelectUser()

        {
            List<SelectUser> list = new List<SelectUser>();
            try
            {
                dt = dh.ExecuteDataSet("usp_Nhanvien_select", new SqlParameter[0]).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        SelectUser sl = new SelectUser
                        {
                            Name = dr["NAME"] == DBNull.Value ? "" : dr["NAME"].ToString(),              
                            Username = dr["USERNAME"] == DBNull.Value ? "" : dr["USERNAME"].ToString(),                         
                            IsAdmin = dr["ISADMIN"] == DBNull.Value ? false : bool.Parse(dr["ISADMIN"].ToString()),
                            

                        };
                        list.Add(sl);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}
