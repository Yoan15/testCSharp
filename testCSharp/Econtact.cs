using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testCSharp.econtactClasses;

namespace testCSharp
{
    public partial class Econtact : Form
    {
        public Econtact()
        {
            InitializeComponent();
        }

        contactClass c = new contactClass();

        private void Econtact_Load(object sender, EventArgs e)
        {
            //Chargement des données dans la Data GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Récupération des valeurs
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNo.Text;
            c.Address = txtboxAddress.Text;
            c.Gender = cmbGender.Text;

            //Ajout des données dans la BDD
            bool success = c.Insert(c);
            if (success = true)
            {
                //ajout réussi
                MessageBox.Show("New contact inserted.");
            }
            else
            {
                MessageBox.Show("An error as occured. Try again later.");
            }

            //Chargement des données dans la Data GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }
    }
}
