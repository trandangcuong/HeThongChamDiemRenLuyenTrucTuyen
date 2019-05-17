using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinfromQuetThe
{
    class KetNoi_CSDL
    {
        static SqlConnection ket_noi;
        static KetNoi_CSDL()
        {
            
            string chuoi_ket_noi = @"Data Source =DESKTOP-R8KE3JJ; Initial Catalog = QL_DIEMRENLUYEN; Integrated Security = True";
            ket_noi = new SqlConnection(chuoi_ket_noi);
            ket_noi.Close();
        }
        public static DataTable Doc_bang(string lenh)
        {
            DataTable dt = new DataTable();
            if (ket_noi.State == ConnectionState.Closed)
            {
                ket_noi.Open();
            }
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(lenh, ket_noi);
                sda.Fill(dt);
            }
            catch (Exception loi)
            {
                throw loi;
            }
            ket_noi.Close();
            return dt;
        }
        public static bool Ghi_bang(string lenh)
        {
            bool kq = false;
            if (ket_noi.State == ConnectionState.Closed)
            {
                ket_noi.Open();
            }
            try
            {
                SqlCommand cmd = new SqlCommand(lenh, ket_noi);
                cmd.ExecuteNonQuery();
                kq = true;
            }
            catch (Exception loi)
            {
                throw loi;
            }
            return kq;
        }


    }
}
