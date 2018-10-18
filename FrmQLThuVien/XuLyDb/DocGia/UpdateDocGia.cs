using QLGN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FrmQLThuVien.XuLyDb.DocGia
{
    class UpdateDocGia
    {
        SqlDataHelper dh = new SqlDataHelper();
        DataTable dt = new DataTable();
        public int UpdateReader(int ID, string Name, string PhoneNumber , string UUID)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@ID", ID),
                    new SqlParameter("@Name",Name),
                    new SqlParameter("@PhoneNumber", PhoneNumber),
                    new SqlParameter("@UUID",  UUID),



                };
                dh.ExecuteNonQuery("usp_Reader_Update", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }
    }
}
