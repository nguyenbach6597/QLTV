using FrmQLThuVien.ObjClass;
using QLGN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmQLThuVien.XuLyDb.NhaXuatBan
{
    public class clsNhaXuatBan
    {
        SqlDataHelper dh = new SqlDataHelper();
        DataTable dt = new DataTable();
        public List<NhaXuatBanOBJ> List_Select()

        {
            List<NhaXuatBanOBJ> list = new List<NhaXuatBanOBJ>();
            try
            {
                dt = dh.ExecuteDataSet("usp_NXB_Select", new SqlParameter[0]).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        NhaXuatBanOBJ sl = new NhaXuatBanOBJ
                        {
                            ID = dr["ID"] == DBNull.Value ? "" : dr["ID"].ToString(),
                            Name = dr["NAME"] == DBNull.Value ? "" : dr["NAME"].ToString(),


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

        public int InsertNhaXuatBan(string Name)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name),

                };
                dh.ExecuteNonQuery("usp_NSB_insert", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
        public int UpdateNhaXuatBan(int ID, string Name)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name),
                    new SqlParameter("@ID", ID)

                };
                dh.ExecuteNonQuery("usp_NSB_update", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
        //public int DeleteNhaXuatBan(int ID)
        //{
        //    int r = 0;
        //    try
        //    {
        //        SqlParameter[] pa = new SqlParameter[]
        //        {
        //            new SqlParameter("@ID", ID)

        //        };
        //        dh.ExecuteNonQuery("usp_Admin_DeleteNhanVien", pa);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return r;
        //}
    }
}
