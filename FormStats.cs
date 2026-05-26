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
            try
            {
                AccesDonnees dal = new AccesDonnees();

                // On récupère la date du calendrier
                DateTime dateSelectionnee = dateTimePicker1.Value;

                // On calcule le CA de la semaine en partant de cette date
                decimal caHebdo = dal.ObtenirChiffreAffairesHebdo(dateSelectionnee);

                // On l'affiche dans ta TextBox (remplace 'txtChiffreAffaires' par le nom exact de ton contrôle)
                tbChiffre.Text = caHebdo.ToString("F2") + " €";

                // On actualise la grille par la même occasion
                dgvHitParade.DataSource = dal.ObtenirHitParade();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //ChargerStatistiques();
        }
    }
}
