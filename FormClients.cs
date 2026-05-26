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
    public partial class FormClients : Form
    {
        public FormClients()
        {
            InitializeComponent();
        }

        private void Enregistrer_Click(object sender, EventArgs e)
        {
            // 1. Vérification de sécurité (Règle métier élémentaire)
            if (string.IsNullOrWhiteSpace(txtNom.Text) || string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageBox.Show("Veuillez remplir au moins le nom et le prénom du client.", "Champs manquants", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // On arrête la méthode ici si les champs sont vides
            }

            // 2. Instanciation de ta couche d'accès aux données (DAL)
            AccesDonnees dal = new AccesDonnees();

            // 3. Appel de la méthode en lui passant les valeurs textuelles de tes TextBox
            // Remplace txtNom, txtPrenom, txtTelephone par les identifiants de tes composants si nécessaire
            dal.AjouterClient(txtNom.Text.Trim(), txtPrenom.Text.Trim(), txtTelephone.Text.Trim());

            // 4. Message de confirmation à l'utilisateur
            MessageBox.Show("Le client a été enregistré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // 5. Optionnel : Vider les TextBox pour la saisie suivante
            txtNom.Clear();
            txtPrenom.Clear();
            txtTelephone.Clear();

            // Si tu as une fonction pour rafraîchir ton DataGridView, appelle-la ici :
             RafraichirGrilleClients();
        }

        // . Crée une fonction pour rafraîchir la grille
        private void RafraichirGrilleClients()
        {
            try
            {
                AccesDonnees dal = new AccesDonnees();
                // Remplace dgvClients par le nom exact de ton DataGridView sur le design
                dgvClients.DataSource = dal.ObtenirTousLesClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de la grille : " + ex.Message);
            }
        }

        private void FormClients_Load(object sender, EventArgs e)
        {
            RafraichirGrilleClients();
        }
    }
}
