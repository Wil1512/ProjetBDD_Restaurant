namespace ProjetBDD_Restaurant
{
    partial class FormStats
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgvHitParade = new System.Windows.Forms.DataGridView();
            this.lbChiffre = new System.Windows.Forms.Label();
            this.tbChiffre = new System.Windows.Forms.TextBox();
            this.btnAfficherStats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHitParade)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dgvHitParade
            // 
            this.dgvHitParade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHitParade.Location = new System.Drawing.Point(12, 45);
            this.dgvHitParade.Name = "dgvHitParade";
            this.dgvHitParade.Size = new System.Drawing.Size(424, 393);
            this.dgvHitParade.TabIndex = 1;
            // 
            // lbChiffre
            // 
            this.lbChiffre.AutoSize = true;
            this.lbChiffre.Location = new System.Drawing.Point(455, 18);
            this.lbChiffre.Name = "lbChiffre";
            this.lbChiffre.Size = new System.Drawing.Size(83, 13);
            this.lbChiffre.TabIndex = 2;
            this.lbChiffre.Text = "Chiffre d\'Affaires";
            // 
            // tbChiffre
            // 
            this.tbChiffre.Location = new System.Drawing.Point(458, 45);
            this.tbChiffre.Name = "tbChiffre";
            this.tbChiffre.Size = new System.Drawing.Size(302, 20);
            this.tbChiffre.TabIndex = 3;
            // 
            // btnAfficherStats
            // 
            this.btnAfficherStats.Location = new System.Drawing.Point(458, 157);
            this.btnAfficherStats.Name = "btnAfficherStats";
            this.btnAfficherStats.Size = new System.Drawing.Size(302, 47);
            this.btnAfficherStats.TabIndex = 4;
            this.btnAfficherStats.Text = "Afficher Stats";
            this.btnAfficherStats.UseVisualStyleBackColor = true;
            this.btnAfficherStats.Click += new System.EventHandler(this.btnAfficherStats_Click);
            // 
            // FormStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAfficherStats);
            this.Controls.Add(this.tbChiffre);
            this.Controls.Add(this.lbChiffre);
            this.Controls.Add(this.dgvHitParade);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "FormStats";
            this.Text = "FormStats";
            this.Load += new System.EventHandler(this.FormStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHitParade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dgvHitParade;
        private System.Windows.Forms.Label lbChiffre;
        private System.Windows.Forms.TextBox tbChiffre;
        private System.Windows.Forms.Button btnAfficherStats;
    }
}