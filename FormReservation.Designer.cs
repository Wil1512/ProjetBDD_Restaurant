namespace ProjetBDD_Restaurant
{
    partial class FormReservation
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
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.btnReserver = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.numTables = new System.Windows.Forms.NumericUpDown();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbClient = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTables)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReservations
            // 
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(12, 43);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.Size = new System.Drawing.Size(499, 395);
            this.dgvReservations.TabIndex = 0;
            // 
            // btnReserver
            // 
            this.btnReserver.Location = new System.Drawing.Point(527, 309);
            this.btnReserver.Name = "btnReserver";
            this.btnReserver.Size = new System.Drawing.Size(261, 58);
            this.btnReserver.TabIndex = 2;
            this.btnReserver.Text = "Reserver";
            this.btnReserver.UseVisualStyleBackColor = true;
            this.btnReserver.Click += new System.EventHandler(this.btnReserver_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(130, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(209, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // numTables
            // 
            this.numTables.Location = new System.Drawing.Point(527, 249);
            this.numTables.Name = "numTables";
            this.numTables.Size = new System.Drawing.Size(121, 20);
            this.numTables.TabIndex = 4;
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(527, 169);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(121, 21);
            this.cbClient.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choiair une date :";
            // 
            // lbClient
            // 
            this.lbClient.AutoSize = true;
            this.lbClient.Location = new System.Drawing.Point(524, 144);
            this.lbClient.Name = "lbClient";
            this.lbClient.Size = new System.Drawing.Size(67, 13);
            this.lbClient.TabIndex = 7;
            this.lbClient.Text = "Choisir Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Table";
            // 
            // FormReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbClient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.numTables);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnReserver);
            this.Controls.Add(this.dgvReservations);
            this.Name = "FormReservation";
            this.Text = "FormReservation";
            this.Load += new System.EventHandler(this.FormReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnReserver;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown numTables;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbClient;
        private System.Windows.Forms.Label label3;
    }
}