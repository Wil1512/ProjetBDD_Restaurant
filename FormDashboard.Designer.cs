namespace ProjetBDD_Restaurant
{
    partial class FormDashboard
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClients = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnhtmlCarte = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnCommandes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClients
            // 
            this.btnClients.Location = new System.Drawing.Point(127, 84);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(198, 60);
            this.btnClients.TabIndex = 0;
            this.btnClients.Text = "Clients";
            this.btnClients.UseVisualStyleBackColor = true;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);
            // 
            // btnTables
            // 
            this.btnTables.Location = new System.Drawing.Point(127, 186);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(198, 60);
            this.btnTables.TabIndex = 1;
            this.btnTables.Text = "Tables";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnCarte_Click);
            // 
            // btnReservations
            // 
            this.btnReservations.Location = new System.Drawing.Point(127, 283);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(198, 60);
            this.btnReservations.TabIndex = 2;
            this.btnReservations.Text = "Reservations";
            this.btnReservations.UseVisualStyleBackColor = true;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
            // 
            // btnhtmlCarte
            // 
            this.btnhtmlCarte.Location = new System.Drawing.Point(446, 283);
            this.btnhtmlCarte.Name = "btnhtmlCarte";
            this.btnhtmlCarte.Size = new System.Drawing.Size(198, 60);
            this.btnhtmlCarte.TabIndex = 5;
            this.btnhtmlCarte.Text = "Carte";
            this.btnhtmlCarte.UseVisualStyleBackColor = true;
            this.btnhtmlCarte.Click += new System.EventHandler(this.btnhtmlCarte_Click);
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(446, 186);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(198, 60);
            this.btnStats.TabIndex = 4;
            this.btnStats.Text = "Statistiques";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnCommandes
            // 
            this.btnCommandes.Location = new System.Drawing.Point(446, 84);
            this.btnCommandes.Name = "btnCommandes";
            this.btnCommandes.Size = new System.Drawing.Size(198, 60);
            this.btnCommandes.TabIndex = 3;
            this.btnCommandes.Text = "Commandes";
            this.btnCommandes.UseVisualStyleBackColor = true;
            this.btnCommandes.Click += new System.EventHandler(this.btnCommandes_Click);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnhtmlCarte);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.btnCommandes);
            this.Controls.Add(this.btnReservations);
            this.Controls.Add(this.btnTables);
            this.Controls.Add(this.btnClients);
            this.Name = "FormDashboard";
            this.Text = "FormDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnhtmlCarte;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnCommandes;
    }
}

