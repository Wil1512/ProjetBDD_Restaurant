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
    public partial class Tables : Form
    {
        public Tables()
        {
            InitializeComponent();
        }

        private void RafraichirGrilleTables()
        {
            try
            {
                AccesDonnees dal = new AccesDonnees();
                // On lie la grille au résultat de notre requête de jointure
                dgvTables.DataSource = dal.ObtenirEtatDesTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de l'état des tables : " + ex.Message);
            }
        }

        private void Tables_Load(object sender, EventArgs e)
        {
            RafraichirGrilleTables();
        }
    }
}
