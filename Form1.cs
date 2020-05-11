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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aoyon\Documents\GitHub\petsolutionlogin\Properties\PetData.mdf;Integrated Security=True;Connect Timeout=30";
            string sql= "select Id,Password,UserName,EmailAddress,UserType" +
                " from [dbo].[Users] where UserName='" + UserName.Text
                + "' and Password='" + Password.Text + "'";
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sqlcmd = new SqlCommand(sql, con);

            DataTable dt = new DataTable();
            sqlcmd.Connection.Open();
           // Users user1;
            dt.Load(sqlcmd.ExecuteReader());
            if(dt.Rows.Count > 0)
            {

                Entities.Users user = new Users()
                {
                    Id = dt.Rows[0].Field<int>("Id"),
                    UserName = dt.Rows[0].Field<string>("UserName"),
                    UserType=dt.Rows[0].Field<string>("UserType"),
                    Password = dt.Rows[0][1].ToString(),
                    EmailAddress = dt.Rows[0][3].ToString(),
                    // UserType= dt.Rows[0][2].ToString(),

                     

                };
                if (user.UserType == "P")
                {
                    pinfo pinfo = new pinfo(user);
                    pinfo.Show();
                    this.Hide();
                }
                else if (user.UserType == "D")
                {
                    Dpinfo dpinfo = new Dpinfo(user);
                    dpinfo.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("not Correct ");
                }



                MessageBox.Show("Correct ");

            }

            else
            {
                DataAccess dataAccess = new DataAccess(ConnectionString);
                List<Entities.Users> users = dataAccess.GetList<Entities.Users>();
            }
            
            sqlcmd.Connection.Close();

           

        }
        private void UserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Password.Focus();
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserName.Focus();
        }
    }
}
