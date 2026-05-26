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
            RafraichirGrilleReservations();
        }

        private void RafraichirGrilleReservations()
        {
            try
            {
                AccesDonnees dal = new AccesDonnees();

                // On récupère la date sélectionnée dans le calendrier
                DateTime dateSelectionnee = dateTimePicker1.Value;

                // On appelle la méthode de la DAL (celle qui filtre sur 7 jours)
                // Remplace 'dgvReservations' par le nom EXACT de ton DataGridView
                dgvReservations.DataSource = dal.ObtenirReservationsSemaine(dateSelectionnee);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du rafraîchissement de la grille : " + ex.Message);
            }
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

            RafraichirGrilleReservations();

            // 4. Optionnel : Rafraîchir immédiatement ton DataGridView pour voir la réservation s'afficher
            // dgvReservations.DataSource = dal.ObtenirReservationsSemaine(dateTimePicker1.Value);
        }

        private void FormReservation_Load(object sender, EventArgs e)
        {
            try
            {
                AccesDonnees dal = new AccesDonnees();

                // 1. On récupère les clients (on combine Nom et Prénom pour l'affichage)
                // Assure-toi que les noms de colonnes (ClientID, Nom, Prenom) correspondent EXACTEMENT à ta BD
                string query = "SELECT ClientID, Nom + ' ' + Prenom AS NomComplet FROM Clients";
                System.Data.DataTable dtClients = dal.GetDonnees(query);

                // 2. On lie les données au ComboBox (cbClients)
                cbClient.DataSource = dtClients;
                cbClient.DisplayMember = "NomComplet"; // Ce qui est visible pour l'utilisateur
                cbClient.ValueMember = "ClientID";     // L'ID caché qu'on utilisera pour insérer la réservation

                // 3. Optionnel : Désélectionner par défaut pour forcer un choix
                cbClient.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des clients : " + ex.Message);
            }

            RafraichirGrilleReservations();
        }
    }


}
