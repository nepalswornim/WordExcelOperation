using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
  public static  class DAO
    {
     public static AppSettingsReader aps = new AppSettingsReader();
     public static string constr = "";
     static DAO() {


         constr = aps.GetValue("myconnection", typeof(string)).ToString();
     }

     public static SqlConnection getConnection() {

         SqlConnection con = new SqlConnection(constr);
         return con;
     
     
     }
     public static DataTable GetTable(string sql, SqlParameter[] param, CommandType cmdType) {

         using (SqlConnection con = getConnection())
         {
             using (SqlCommand cmd=con.CreateCommand())
             {

                cmd.CommandText = sql;
                cmd.CommandType = cmdType;
                if (param!=null)
                {
                    cmd.Parameters.AddRange(param);
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
             }
             
         }
     
     
     }
    }
}
