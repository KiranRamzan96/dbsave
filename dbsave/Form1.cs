using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace dbsave
{
    public partial class Form1 : Form
    {
        DB db=new DB();
        public Form1()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            DataTable dt = new DataTable();
            dt = db.GetTable("Select * From Table_File");
            dgv.DataSource = dt;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //OpenFileDialog  ofd=new OpenFileDialog();
            //ofd.Multiselect = true;
            //ofd.ShowDialog();
            //byte[] filedata=File.ReadAllBytes(ofd.FileName);
            //SqlCommand cmd=new SqlCommand("Insert into Table_File (ID,FileData) values ('1',@Data) ",db.con);
            //cmd.Parameters.Add("@Data",SqlDbType.VarBinary).Value = filedata;
            //db.con.Open();
            //cmd.ExecuteNonQuery();
            //db.con.Close();
            //MessageBox.Show("Saved");

            LoadData();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.ShowDialog();

            byte[] FileNamesArray = new byte[ofd.FileNames.Length];
          
            for (int i = 0; i < FileNamesArray.Length; i++)
            {
                SqlCommand cmd = new SqlCommand("Insert into Table_File (FileData) values (@Data) ", db.con);
                cmd.Parameters.Add("@Data", SqlDbType.VarBinary).Value = FileNamesArray;
                db.con.Open();
                cmd.ExecuteNonQuery();
                db.con.Close();
            }

            MessageBox.Show("Saved");
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
