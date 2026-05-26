namespace ProjetBDD_Restaurant
{
    partial class FormCommande
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.cbPlats = new System.Windows.Forms.ComboBox();
            this.numQuantite = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddition = new System.Windows.Forms.Button();
            this.dgvCommandes = new System.Windows.Forms.DataGridView();
            this.btnTicket = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(12, 32);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(141, 21);
            this.cbTable.TabIndex = 0;
            this.cbTable.SelectedIndexChanged += new System.EventHandler(this.cbTable_SelectedIndexChanged);
            // 
            // cbPlats
            // 
            this.cbPlats.FormattingEnabled = true;
            this.cbPlats.Location = new System.Drawing.Point(175, 32);
            this.cbPlats.Name = "cbPlats";
            this.cbPlats.Size = new System.Drawing.Size(122, 21);
            this.cbPlats.TabIndex = 1;
            // 
            // numQuantite
            // 
            this.numQuantite.Location = new System.Drawing.Point(12, 94);
            this.numQuantite.Name = "numQuantite";
            this.numQuantite.Size = new System.Drawing.Size(285, 20);
            this.numQuantite.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantité";
            // 
            // btnAddition
            // 
            this.btnAddition.Location = new System.Drawing.Point(12, 136);
            this.btnAddition.Name = "btnAddition";
            this.btnAddition.Size = new System.Drawing.Size(288, 41);
            this.btnAddition.TabIndex = 4;
            this.btnAddition.Text = "Ajouter à l\'addition";
            this.btnAddition.UseVisualStyleBackColor = true;
            this.btnAddition.Click += new System.EventHandler(this.btnAddition_Click);
            // 
            // dgvCommandes
            // 
            this.dgvCommandes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommandes.Location = new System.Drawing.Point(325, 12);
            this.dgvCommandes.Name = "dgvCommandes";
            this.dgvCommandes.Size = new System.Drawing.Size(471, 429);
            this.dgvCommandes.TabIndex = 5;
            // 
            // btnTicket
            // 
            this.btnTicket.Location = new System.Drawing.Point(12, 388);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(285, 50);
            this.btnTicket.TabIndex = 6;
            this.btnTicket.Text = "Générer le Ticket";
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Choisir la table occupée :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sélectionner un plat :";
            // 
            // FormCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.dgvCommandes);
            this.Controls.Add(this.btnAddition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numQuantite);
            this.Controls.Add(this.cbPlats);
            this.Controls.Add(this.cbTable);
            this.Name = "FormCommande";
            this.Text = "FormCommande";
            this.Load += new System.EventHandler(this.FormCommande_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommandes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.ComboBox cbPlats;
        private System.Windows.Forms.NumericUpDown numQuantite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddition;
        private System.Windows.Forms.DataGridView dgvCommandes;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}