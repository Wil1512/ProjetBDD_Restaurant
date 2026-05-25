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
    public partial class FormStats : Form
    {
        public FormStats()
        {
            InitializeComponent();
        }

        private void FormStats_Load(object sender, EventArgs e)
        {
            AccesDonnees dal = new AccesDonnees();

            // On remplit le DataGridView avec le résultat de la requête SQL située dans la DAL
            dgvHitParade.DataSource = dal.ObtenirHitParade();
        }

        private void btnAfficherStats_Click(object sender, EventArgs e)
        {
            AccesDonnees dal = new AccesDonnees();

            // 1. Récupérer la date de début de semaine sélectionnée
            DateTime dateDebutSemaine = dateTimePicker1.Value;

            // 2. Charger le Hit-parade des plats dans ton DataGridView (le grand carré gris)
            // dgvHitParade est le nom de ton tableau sur ton FormStats
            dgvHitParade.DataSource = dal.ObtenirHitParade();

            // 3. Calculer et afficher le chiffre d'affaires dans ta zone de texte
            decimal caTotal = dal.ObtenirChiffreAffairesHebdo(dateDebutSemaine);

            // txtChiffreAffaires correspond à ta TextBox de droite. 
            // "C2" applique le symbole monétaire (€) automatiquement
            tbChiffre.Text = caTotal.ToString("C2");
        }
    }
}
