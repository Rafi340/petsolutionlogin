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
using petsolutionlogin.Data;
using petsolutionlogin.Entities;

namespace petsolutionlogin
{
    public partial class pinfo : Form
    {
        Users user;
        DataAccess dataAccess;
        private void pinfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pinfo_Leave(object sender, System.EventArgs e)
        {
            MessageBox.Show("Leaved");
        }
        private void Pifo_Load(object sender, System.EventArgs e)
        {
            label1.Text += user.UserName;
            textBox1.Text = user.Id.ToString();
            var userInfo = dataAccess.GetById<UserInfo, int>(user.Id);
            if(userInfo != null)
            {
                txtFirstName.Text = userInfo.FirstName;
                txtLastName.Text = userInfo.LastName;
                txtPetName.Text = userInfo.PetName;
                txtAge.Text = userInfo.PetAge;
                txtAddress.Text = userInfo.PresentAddress;
                txtBlood.Text = userInfo.BloodGroup;
                txtGender.Text = userInfo.PetGender;
                txtProblem.Text = userInfo.PetProblem;
              // txtSolution.Text = userInfo.PetSolution;
               // txtMedicine.Text = userInfo.MedicineName;

            }
        }
        public pinfo(Users _user)
        {
            InitializeComponent();
            user = _user;
            dataAccess = new DataAccess();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            UserInfo userInfo = new UserInfo()
            {
                
                FirstName =txtFirstName.Text,
                LastName=txtLastName.Text,
                BloodGroup = txtBlood.Text,
                PetName=txtPetName.Text,
                PetGender=txtGender.Text,
                PetAge=txtAge.Text,
                PresentAddress=txtAddress.Text,
                PetProblem =txtProblem.Text,
                //PetSolution=txtSolution.Text,
              
             
                
            };
            DataAccess dataAccess = new DataAccess();
            int affectedRowCount = dataAccess.Insert<UserInfo>(userInfo, false);
            if (affectedRowCount > 0)
            {
                MessageBox.Show("Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Unable to save.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DOLPHIN\Documents\GitHub\petsolutionlogin\Properties\PetData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql1 = String.Format("select PetSolution from  [dbo].[UserInfo]");

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand sqlCmd1 = new SqlCommand(sql1, conn);

            DataTable dt = new DataTable();

            sqlCmd1.Connection.Open();
           
            dt.Load(sqlCmd1.ExecuteReader());
            dataGridView1.DataSource = dt;
            sqlCmd1.Connection.Close();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
