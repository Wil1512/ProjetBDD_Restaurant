namespace ProjetBDD_Restaurant
{
    partial class Tables
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
            this.dgvTables = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTables
            // 
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Location = new System.Drawing.Point(18, 13);
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.Size = new System.Drawing.Size(761, 419);
            this.dgvTables.TabIndex = 0;
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTables);
            this.Name = "Tables";
            this.Text = "CarteHtml";
            this.Load += new System.EventHandler(this.Tables_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTables;
    }
}