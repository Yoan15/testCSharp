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
            if (success == true)
            {
                //ajout réussi
                MessageBox.Show("New contact inserted.");
                //Appel de la methode Clear
                Clear();
            }
            else
            {
                MessageBox.Show("An error as occured. Try again later.");
            }

            //Chargement des données dans la Data GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        //Vider les champs
        public void Clear()
        {
            //Vider les textbox
            txtboxContactID.Text = "";
            txtboxFirstName.Text = "";
            txtboxLastName.Text = "";
            txtboxContactNo.Text = "";
            txtboxAddress.Text = "";
            cmbGender.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Récupérer les valeurs à partir des textbox
            c.ContactID = int.Parse(txtboxContactID.Text);
            c.FirstName = txtboxFirstName.Text;
            c.LastName = txtboxLastName.Text;
            c.ContactNo = txtboxContactNo.Text;
            c.Address = txtboxAddress.Text;
            c.Gender = cmbGender.Text;

            //Mise à jour des données dans la BDD
            bool success = c.Update(c);
            if (success == true)
            {
                //Update réussie
                MessageBox.Show("Contact has been updated");
                Clear();
            }
            else
            {
                //Update échouée
                MessageBox.Show("Update has failed. Try again later.");
            }
            //Chargement des données dans la Data GridView
            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }

        private void dgvContactList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Récupérer les données à partir de la DataGridView et les charger dans les textbox
            //Récupérer la bonne ligne sélectionnée
            int rowIndex = e.RowIndex;
            txtboxContactID.Text = dgvContactList.Rows[rowIndex].Cells[0].Value.ToString();
            txtboxFirstName.Text = dgvContactList.Rows[rowIndex].Cells[1].Value.ToString();
            txtboxLastName.Text = dgvContactList.Rows[rowIndex].Cells[2].Value.ToString();
            txtboxContactNo.Text = dgvContactList.Rows[rowIndex].Cells[3].Value.ToString();
            txtboxAddress.Text = dgvContactList.Rows[rowIndex].Cells[4].Value.ToString();
            cmbGender.Text = dgvContactList.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear toutes les textbox
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Récupérer le ContactID de l'application
            c.ContactID = Convert.ToInt32(txtboxContactID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //Suppression réussie
                MessageBox.Show("Contact successfully deleted.");
                //Mise a jour de la DataGridView
                DataTable dt = c.Select();
                dgvContactList.DataSource = dt;
                Clear();
            }
            else
            {
                //Suppression échouée
                MessageBox.Show("Failed to delete contact. Try again later.");
            }
        }
    }
}
