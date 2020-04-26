using petsolutionlogin.Data;
using petsolutionlogin.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace petsolutionlogin
{
    public partial class Dpinfo : Form
    {
        Users user;
        DataAccess dataAccess;
        public Dpinfo(Users _user)
        {
            InitializeComponent();
            user = _user;
            dataAccess = new DataAccess();
        }

        private void Dpinfo_Load(object sender, EventArgs e)
        {

        }
    }
}
