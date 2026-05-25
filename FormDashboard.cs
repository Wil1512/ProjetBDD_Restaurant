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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            FormClients f = new FormClients();
            f.ShowDialog();
        }

        private void btnCarte_Click(object sender, EventArgs e)
        {
            Tables f = new Tables();
            f.ShowDialog();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            FormReservation f = new FormReservation();
            f.ShowDialog();
        }

        private void btnCommandes_Click(object sender, EventArgs e)
        {
            FormCommande f = new FormCommande();
            f.ShowDialog();
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            FormStats f = new FormStats();
            f.ShowDialog();
        }

        private void btnhtmlCarte_Click(object sender, EventArgs e)
        {
            FormCartes f = new FormCartes();
            f.ShowDialog();
        }
    }
}
