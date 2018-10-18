using QLGN;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmQLThuVien.XuLyDb.DocGia
{
    class DeleteDocGia
    {
        SqlDataHelper dh = new SqlDataHelper();
        public int XoaDocGia(int Id)
        {
            int r = 0;
            try
            {
                SqlParameter[] pa = new SqlParameter[]
                {
                    new SqlParameter("@ID", Id),

                };
                dh.ExecuteNonQuery("usp_Reader_Delete", pa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return r;
        }
    }
}
