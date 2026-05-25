using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetBDD_Restaurant
{
    public partial class FormReservation : Form
    {
        public FormReservation()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnReserver_Click(object sender, EventArgs e)
        {
            // 1. Vérification que la liste des clients n'est pas vide
            if (cbClient.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un client valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Récupération des informations saisies dans ton interface graphique
            int idClient = Convert.ToInt32(cbClient.SelectedValue);
            int numTable = Convert.ToInt32(numTables.Value); // correspond à ton NumericUpDown
            DateTime dateChoisie = dateTimePicker1.Value;   // ton DateTimePicker

            // 3. Envoi à la base de données via la DAL
            AccesDonnees dal = new AccesDonnees();
            dal.AjouterReservation(idClient, numTable, dateChoisie);

            MessageBox.Show("Réservation enregistrée avec succès !", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 4. Optionnel : Rafraîchir immédiatement ton DataGridView pour voir la réservation s'afficher
            // dgvReservations.DataSource = dal.ObtenirReservationsSemaine(dateTimePicker1.Value);
        }
    }
}
