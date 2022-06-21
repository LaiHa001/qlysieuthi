using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLST2
{
    public class ketnoi
    {

        private string con_str = "";
        private SqlConnection conn = null;

        public ketnoi()
        {
            con_str = @"Data Source=DESKTOP-2TFP3AF\SQLEXPRESS;Initial Catalog=QLST;Integrated Security=True";
            conn = new SqlConnection(con_str);
        }
        public bool thucthi(string sql)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;

            }
        }
        public DataSet laydulieu(string sql, string table_name)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, table_name);
            }
            catch
            {

            }
            return ds;
        }


    }
}
