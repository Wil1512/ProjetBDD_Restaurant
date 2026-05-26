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
            try
            {
                // 1. Vérifications de sécurité
                if (cbTable.SelectedIndex == -1 || cbPlats.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez sélectionner une table ET un plat.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (numQuantite.Value <= 0)
                {
                    MessageBox.Show("La quantité doit être supérieure à 0.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Récupération des données de l'IHM
                int tableNum = Convert.ToInt32(cbTable.SelectedValue);
                int platId = Convert.ToInt32(cbPlats.SelectedValue);
                int quantite = Convert.ToInt32(numQuantite.Value);

                // 3. Envoi à la base de données via la DAL
                AccesDonnees dal = new AccesDonnees();

                // ÉTAPE CRUCIALE : On récupère le ResID associé au numéro de table
                int resId = dal.ObtenirResIDParTable(tableNum);

                if (resId == 0)
                {
                    MessageBox.Show("Aucune réservation active trouvée pour cette table.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Plus besoin de boucle ! On insère une seule ligne avec la quantité directe
                dal.AjouterPlatCommande(resId, platId, quantite);

                MessageBox.Show("Ajouté à l'addition !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Réinitialiser la quantité pour la commande suivante
                numQuantite.Value = 1; // Mettre à 1 par défaut est plus ergonomique

                // 5. MAJ de ton DataGridView
                dgvCommandes.DataSource = dal.ObtenirCommandesParTable(tableNum);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout du plat : " + ex.Message);
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Vérifier qu'une table est bien sélectionnée
                if (cbTable.SelectedIndex == -1)
                {
                    MessageBox.Show("Veuillez sélectionner une table pour générer son ticket.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int tableNum = Convert.ToInt32(cbTable.SelectedValue);
                AccesDonnees dal = new AccesDonnees();

                // 2. Récupérer les plats (on utilise la méthode qui marche déjà pour ta grille !)
                DataTable dtTicket = dal.ObtenirCommandesParTable(tableNum);

                // CORRECTION ICI : On vérifie si le tableau contient des lignes
                if (dtTicket.Rows.Count == 0)
                {
                    MessageBox.Show("Aucun plat n'a été commandé pour cette table.", "Ticket Vide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3. Construction du texte du ticket de caisse
                string ticketText = $"=== TICKET DE CAISSE - TABLE {tableNum} ===\n\n";
                ticketText += "Détail de la commande :\n";
                ticketText += "----------------------------------------\n";

                foreach (DataRow row in dtTicket.Rows)
                {
                    string nomPlat = row["Plat Commandé"].ToString();
                    decimal prix = Convert.ToDecimal(row["Prix Unitaire (€)"]);
                    int qte = Convert.ToInt32(row["Quantité"]);
                    decimal sousTotal = prix * qte;

                    ticketText += $"- {nomPlat} x{qte} : {sousTotal:F2} €\n";
                }

                // 4. Récupération et affichage du total général
                decimal totalGeneral = dal.CalculerTotalTable(tableNum);

                ticketText += "----------------------------------------\n";
                ticketText += $"TOTAL À PAYER : {totalGeneral:F2} €\n\n";
                ticketText += "Merci de votre visite, à bientôt !";

                // 5. Affichage du ticket dans une boîte de message (ou une TextBox)
                MessageBox.Show(ticketText, "Impression du Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la génération du ticket : " + ex.Message);
            }
        }

        private void FormCommande_Load(object sender, EventArgs e)
        {
            try
            {
                AccesDonnees dal = new AccesDonnees();

                // 1. Remplir le ComboBox des Tables (cbTables)
                DataTable dtTables = dal.ObtenirTablesReservees();
                cbTable.DataSource = dtTables;
                cbTable.DisplayMember = "TableNum";
                cbTable.ValueMember = "TableNum";
                cbTable.SelectedIndex = -1; // Laisse vide au démarrage

                // 2. Remplir le ComboBox des Plats (cbPlats)
                DataTable dtPlats = dal.ObtenirTousLesPlats();
                cbPlats.DataSource = dtPlats;
                cbPlats.DisplayMember = "Nom";
                cbPlats.ValueMember = "PlatID";
                cbPlats.SelectedIndex = -1; // Laisse vide au démarrage
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur au chargement des listes de commande : " + ex.Message);
            }
        }

        private void cbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SÉCURITÉ : On vérifie que la valeur n'est pas nulle ET qu'elle n'est pas un DataRowView parasite
            if (cbTable.SelectedValue != null && !(cbTable.SelectedValue is System.Data.DataRowView))
            {
                try
                {
                    AccesDonnees dal = new AccesDonnees();

                    // Maintenant la conversion se fera en toute sécurité
                    int tableSelectionnee = Convert.ToInt32(cbTable.SelectedValue);

                    // Charger les plats de la table dans ton DataGridView (remplace dgvCommandes par le vrai nom si nécessaire)
                    dgvCommandes.DataSource = dal.ObtenirCommandesParTable(tableSelectionnee);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement du ticket de cette table : " + ex.Message);
                }
            }
        }
    }
}
