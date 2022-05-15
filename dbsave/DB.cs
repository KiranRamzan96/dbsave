using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbsave
{
     class DB
     {
          private static string TeleStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=FileData; Integrated Security=True";
          public SqlConnection con { get; set; }

          public DB()
          { 
               con = new SqlConnection(TeleStr);
          }

          public void FillComboBox(ComboBox comboBox, string sql, string displayMember)
          {
               DataTable dt1 = new DataTable();
               SqlCommand cmd = new SqlCommand(sql, con);
               con.Close();
               con.Open();
               dt1.Load(cmd.ExecuteReader());
               con.Close();
               comboBox.DataSource = dt1;
               comboBox.DisplayMember = displayMember;
          }

          public DataTable GetTable(string sql)
          {
               DataTable dt2 = new DataTable();
               SqlCommand cmd = new SqlCommand(sql, con);
               con.Close();
               con.Open();
               dt2.Load(cmd.ExecuteReader());
               con.Close();
               return dt2;
          }

          public void ExeSQL(string sql)
          {
               SqlCommand cmd = new SqlCommand(sql, con);
               con.Close();
               con.Open();
               cmd.ExecuteNonQuery();
               con.Close();
          }

          public string ExeSQLResult(string sql)
          {
               string str = null;
               SqlCommand cmd = new SqlCommand(sql, con);
               con.Close();
               con.Open();
               str = cmd.ExecuteScalar().ToString();
               con.Close();
               return str;
          }

     }
}
