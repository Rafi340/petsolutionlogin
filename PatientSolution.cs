﻿using petsolutionlogin.Data;
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
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DOLPHIN\Documents\GitHub\petsolutionlogin\Properties\PetData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql1 = String.Format("select FirstName,PetName,PetGender,PetAge,BloodGroup,PetProblem from  [dbo].[UserInfo] where PetName ='" + user.Specialist+"'");

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
            string ConnectionString1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DOLPHIN\Documents\GitHub\petsolutionlogin\Properties\PetData.mdf;Integrated Security=True;Connect Timeout=30";
            /*string sql2 = String.Format("select FirstName,PetName,PetGender,PetAge,BloodGroup,PetProblem from  [dbo].[UserInfo] where ID ='" + textBox1.Text+ "'");
            SqlConnection conn = new SqlConnection(ConnectionString1);
            SqlCommand sqlCmd2 = new SqlCommand(sql2, conn);
            DataTable dt1 = new DataTable();
            sqlCmd2.Connection.Open();
             textBox1.Text = dt1.Rows[0][0].ToString();
             txtFirstName.Text = dt1.Rows[0][1].ToString();
             txtPetName.Text = dt1.Rows[0][3].ToString();
             txtGender.Text = dt1.Rows[0][4].ToString();
             txtAge.Text = dt1.Rows[0][5].ToString();
             txtBlood.Text = dt1.Rows[0][7].ToString();
             txtProblem.Text = dt1.Rows[0][8].ToString();

           
            sqlCmd2.Connection.Close();*/

            SqlDataAdapter asdf = new SqlDataAdapter("select FirstName, PetName, PetGender, PetAge, BloodGroup, PetProblem from[dbo].[UserInfo] where ID = '" + textBox1.Text+ "'", ConnectionString1);
            DataTable ss = new DataTable();
            asdf.Fill(ss);
            textBox1.Text = ss.Rows[0][0].ToString();
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
    }
}
