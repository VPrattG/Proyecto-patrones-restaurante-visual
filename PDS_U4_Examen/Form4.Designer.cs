namespace PDS_U4_Examen
{
    partial class Form4
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
            txtVentas = new TextBox();
            btnRegresar = new Button();
            SuspendLayout();
            // 
            // txtVentas
            // 
            txtVentas.Dock = DockStyle.Fill;
            txtVentas.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtVentas.Location = new Point(0, 0);
            txtVentas.Multiline = true;
            txtVentas.Name = "txtVentas";
            txtVentas.ReadOnly = true;
            txtVentas.ScrollBars = ScrollBars.Vertical;
            txtVentas.Size = new Size(800, 451);
            txtVentas.TabIndex = 1;
            // 
            // btnRegresar
            // 
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegresar.Location = new Point(642, 397);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(130, 40);
            btnRegresar.TabIndex = 0;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(btnRegresar);
            Controls.Add(txtVentas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form4";
            Text = "Historial de ventas";
            Load += Form4_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtVentas;
        private Button btnRegresar;
    }
}