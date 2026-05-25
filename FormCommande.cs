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
    public partial class FormCommande : Form
    {
        public FormCommande()
        {
            InitializeComponent();
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            // 1. Récupérer les identifiants cachés (ValueMember) de tes ComboBox
            // Assure-toi d'avoir configuré le ValueMember sur "ResID" et "PlatID" lors du chargement
            int idReservation = Convert.ToInt32(cbTable.SelectedValue);
            int idPlat = Convert.ToInt32(cbPlats.SelectedValue);
            int quantite = Convert.ToInt32(numQuantite.Value);

            if (quantite <= 0)
            {
                MessageBox.Show("La quantité doit être supérieure à 0.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Envoyer à la base de données
            AccesDonnees dal = new AccesDonnees();
            dal.AjouterPlatCommande(idReservation, idPlat, quantite);

            MessageBox.Show("Plat ajouté avec succès à l'addition !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionnel : Réinitialiser la quantité à 1
            numQuantite.Value = 1;

            // Si tu as un DataGridView sur ce formulaire pour lister la commande en cours, rafraîchis-le ici
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            int idReservation = Convert.ToInt32(cbTable.SelectedValue);

            // 1. Appeler la méthode DAL pour calculer le montant total
            AccesDonnees dal = new AccesDonnees();
            decimal totalAddition = dal.CalculerTotalTicket(idReservation);

            // 2. Afficher le résultat à l'utilisateur (Ticket automatique)
            if (totalAddition > 0)
            {
                string messageTicket = $"--- TICKET DE CAISSE ---\n\n" +
                                       $"Réservation N° : {idReservation}\n" +
                                       $"Date : {DateTime.Now.ToShortDateString()}\n" +
                                       $"------------------------\n" +
                                       $"TOTAL À PAYER : {totalAddition.ToString("C2")}\n\n" +
                                       $"Merci de votre visite au Restaurant Tatebong !";

                MessageBox.Show(messageTicket, "Impression du Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Aucun plat n'a encore été commandé pour cette table.", "Ticket Vide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
