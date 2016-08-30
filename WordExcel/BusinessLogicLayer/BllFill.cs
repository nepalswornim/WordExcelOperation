using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
   public class BllFill
    {

       public DataTable GetTable() {

           string sql = "Select * from tbl_Attendence";
           DataTable dt = DAO.GetTable(sql, null, CommandType.Text);
           return dt;
       }
    }
}
