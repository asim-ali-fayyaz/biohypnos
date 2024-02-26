using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
             //return new SqlConnection("Data Source=DESKTOP-19THQ4O;Initial Catalog=db_Biohypons;Integrated Security=True");
            return new SqlConnection("Data Source=66.165.248.146;Initial Catalog=db_biohypnos; User ID=user_biohypnos; Password=j!5T0n33k");
        }
    }
}
