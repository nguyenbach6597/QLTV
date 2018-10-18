using QLGN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmQLThuVien.XuLyDb.DocGia
{
    class InsertDocGia
    {
        SqlDataHelper dh = new SqlDataHelper();

        public int InserDocGia(string Name, DateTime DateCreate, string PhoneNumber, string UUID)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@Name", Name),
                    new SqlParameter ("@DateCreate",DateCreate),
                    new SqlParameter ("@PhoneNumber",PhoneNumber),
                    new SqlParameter ("@UUID",UUID)



                };
                dh.ExecuteNonQuery("usp_Reader_Insert", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return r;
        }
    }
}
