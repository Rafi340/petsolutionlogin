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
    public partial class Dpinfo : Form
    {
        Users user;
        DataAccess dataAccess;

        private void Dpinfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Dpinfo_Leave(object sender, System.EventArgs e)
        {
            MessageBox.Show("Leaved");
        }
      

        private void Dpinfo_Load(object sender, EventArgs e)
        {
            label9.Text += user.UserName;
            txtId.Text = user.Id.ToString();
            var doc = dataAccess.GetById<Doctor, int>(user.Id);
            if (doc != null)
            {
               // txtId.Text = doc.Id;
                txtName.Text = doc.Name;
                txtAge.Text = doc.Age;
                txtSpecialist.Text = doc.Specialist;
                txtGender.Text = doc.Gender;
                txtDoctorAddress.Text =doc.DoctorAddress;

                txtBloodGroup.Text = doc.DBloodGroup;
                txtDateOfBirth.Text = doc.DateOfBirth;
                txtAboutDoctor.Text =doc.AboutDoctor;

                txtDetailsDoctor.Text = doc.DetailsDoctor;
                txtNoofpatient.Text = doc.Noofpatient;


            }
        }

        public Dpinfo(Users _user)
        {
            InitializeComponent();
            user = _user;
            dataAccess = new DataAccess();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            Doctor doc = new Doctor()
            {
                //Id = txtId.Text,
                Name = txtName.Text,
                Age = txtAge.Text,
                Specialist = txtSpecialist.Text,
                Gender = txtGender.Text,
                DetailsDoctor=txtDetailsDoctor.Text,
                AboutDoctor=txtAboutDoctor.Text,
                DoctorAddress = txtDoctorAddress.Text,
                DBloodGroup = txtBloodGroup.Text,
                DateOfBirth = txtDateOfBirth.Text,
                Noofpatient = txtNoofpatient.Text,
            };

            DataAccess dataAccess = new DataAccess();
            int affectedRowCount = dataAccess.Insert<Doctor>(doc, false);
            if (affectedRowCount > 0)
            {
                MessageBox.Show("Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Unable to save.");
            }


        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
