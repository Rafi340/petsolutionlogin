using petsolutionlogin.Data;
using petsolutionlogin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petsolutionlogin
{
    public partial class PatientSolution : Form
    {
        Users user;
        DataAccess dataAccess;

        public PatientSolution( Users _user)
        {
            user = _user;
            dataAccess = new DataAccess();
            InitializeComponent();
        }

        private void PatientSolution_Load(object sender, EventArgs e)
        {

        }

        private void ldPatient_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\githubfiles\petsolutionlogin\Properties\PetData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql1 = String.Format("select ID,FirstName,PetName,PetGender,PetAge,BloodGroup,PetProblem from  [dbo].[UserInfo] where PetName ='" + user.Specialist+"'");

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd1 = new SqlCommand(sql1, conn);

            DataTable dt = new DataTable();

            sqlCmd1.Connection.Open();

            dt.Load(sqlCmd1.ExecuteReader());
            dataGridView1.DataSource = dt;
            sqlCmd1.Connection.Close();
        }

        private void ppp_Click(object sender, EventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\githubfiles\petsolutionlogin\Properties\PetData.mdf;Integrated Security=True;Connect Timeout=30";
            SqlDataAdapter asdf = new SqlDataAdapter("select FirstName, PetName, PetGender, PetAge, BloodGroup, PetProblem from[dbo].[UserInfo] where ID = '" + textBox1.Text+ "'", ConnectionString1);
            DataTable ss = new DataTable();
            asdf.Fill(ss);
            
            txtFirstName.Text = ss.Rows[0][0].ToString();
            txtPetName.Text = ss.Rows[0][1].ToString();
            txtGender.Text = ss.Rows[0][2].ToString();
            txtAge.Text = ss.Rows[0][3].ToString();
            txtBlood.Text = ss.Rows[0][4].ToString();
            txtProblem.Text = ss.Rows[0][5].ToString();

          

        }

        private void bckBtn_Click(object sender, EventArgs e)
        {
            Dpinfo d1 = new Dpinfo(user);
            d1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\githubfiles\petsolutionlogin\Properties\PetData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql2 = String.Format("insert into [dbo].[ps] (Id,solution)  values ('" + textBox1.Text + "','" + suolutiontxt.Text+ "')");
            SqlConnection conn = new SqlConnection(ConnectionString1); 
            SqlCommand sqlCmd2 = new SqlCommand(sql2, conn);
            DataTable dt1 = new DataTable();
            sqlCmd2.Connection.Open();
            int rows = sqlCmd2.ExecuteNonQuery();

            if (rows > 0)
            {
                MessageBox.Show("SAVED");



            }
            else
            {
                MessageBox.Show("Something Wrong");
            }
            sqlCmd2.Connection.Close();
        }
    }
}
