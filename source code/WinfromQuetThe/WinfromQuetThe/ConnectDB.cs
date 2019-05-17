using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinfromQuetThe
{
    public class ConnectDB
    {

        public SqlConnection conDB()
        {
            SqlConnection con = new SqlConnection(" Data Source =DESKTOP-R8KE3JJ; Initial Catalog = QL_DIEMRENLUYEN; Integrated Security = True");
            return con;

        }


    }
}