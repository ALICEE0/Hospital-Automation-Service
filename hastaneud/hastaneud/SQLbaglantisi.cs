using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace hastaneud
{
    class SQLbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=OZMEN\\SQLEXPRESS01;Initial Catalog=HastaneUD;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
