using FrmQLThuVien.ObjClass;
using QLGN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace qlcv.XuLyVsDB.User
{
    class SelectDocGia
    {

        SqlDataHelper dh = new SqlDataHelper();
        DataTable dt = new DataTable();


        public List<BanDoc> List_SelectDocGia()

        {
            List<BanDoc> list = new List<BanDoc>();
            try
            {
                dt = dh.ExecuteDataSet("usp_Reader_Select", new SqlParameter[0]).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BanDoc sl = new BanDoc
                        {
                            ID = dr["ID"] == DBNull.Value ? "" : dr["ID"].ToString(),
                            Name = dr["NAME"] == DBNull.Value ? "" : dr["NAME"].ToString(),
                            DateCreate = dr["DATECREATE"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(dr["DATECREATE"].ToString()),
                            PhoneNumber = dr["PHONENUMBER"] == DBNull.Value ? "" : dr["PHONENUMBER"].ToString(),
                            UUID = dr["UUID"] == DBNull.Value ? "" : dr["UUID"].ToString(),


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
