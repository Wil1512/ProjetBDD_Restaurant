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
    public partial class FormCartes : Form
    {
        public FormCartes()
        {
            InitializeComponent();
        }

        private void FormCartes_Load(object sender, EventArgs e)
        {
            // Détermine le chemin automatique vers ton fichier HTML
            string cheminHtml = System.IO.Path.Combine(Application.StartupPath, "carte.html");

            // Si tu as nommé ton WebBrowser 'webBrowser1'
            webBrowser1.Navigate(cheminHtml);
        }
    }
}
