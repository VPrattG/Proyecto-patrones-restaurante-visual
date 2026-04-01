namespace PDS_U4_Examen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            btnMesas = new Button();
            btnOrden = new Button();
            btnInventario = new Button();
            btnConcluir = new Button();
            lblMateria = new Label();
            lblSemestre = new Label();
            lblAlumno = new Label();
            lblNumCon = new Label();
            lblVersion = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Minecraftia", 24F, FontStyle.Underline, GraphicsUnit.Point);
            lblTitulo.Location = new Point(35, 25);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(600, 70);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de restaurante";
            // 
            // btnMesas
            // 
            btnMesas.Cursor = Cursors.Hand;
            btnMesas.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnMesas.Location = new Point(530, 189);
            btnMesas.Name = "btnMesas";
            btnMesas.Size = new Size(179, 40);
            btnMesas.TabIndex = 1;
            btnMesas.Text = "Manejar mesas";
            btnMesas.UseVisualStyleBackColor = true;
            btnMesas.Click += btnMesas_Click;
            // 
            // btnOrden
            // 
            btnOrden.Cursor = Cursors.Hand;
            btnOrden.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOrden.Location = new Point(530, 235);
            btnOrden.Name = "btnOrden";
            btnOrden.Size = new Size(179, 40);
            btnOrden.TabIndex = 2;
            btnOrden.Text = "Registrar orden";
            btnOrden.UseVisualStyleBackColor = true;
            btnOrden.Click += btnOrden_Click;
            // 
            // btnInventario
            // 
            btnInventario.Cursor = Cursors.Hand;
            btnInventario.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnInventario.Location = new Point(530, 281);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(179, 40);
            btnInventario.TabIndex = 3;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnConcluir
            // 
            btnConcluir.Cursor = Cursors.Hand;
            btnConcluir.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnConcluir.Location = new Point(530, 327);
            btnConcluir.Name = "btnConcluir";
            btnConcluir.Size = new Size(179, 40);
            btnConcluir.TabIndex = 4;
            btnConcluir.Text = "Finalizar día";
            btnConcluir.UseVisualStyleBackColor = true;
            btnConcluir.Click += btnConcluir_Click;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblMateria.Location = new Point(49, 230);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(299, 26);
            lblMateria.TabIndex = 5;
            lblMateria.Text = "Patrones de Diseño de Software";
            // 
            // lblSemestre
            // 
            lblSemestre.AutoSize = true;
            lblSemestre.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSemestre.Location = new Point(49, 256);
            lblSemestre.Name = "lblSemestre";
            lblSemestre.Size = new Size(134, 26);
            lblSemestre.TabIndex = 6;
            lblSemestre.Text = "8vo semestre";
            // 
            // lblAlumno
            // 
            lblAlumno.AutoSize = true;
            lblAlumno.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblAlumno.Location = new Point(49, 282);
            lblAlumno.Name = "lblAlumno";
            lblAlumno.Size = new Size(322, 26);
            lblAlumno.TabIndex = 7;
            lblAlumno.Text = "Van Pratt González Ricardo Adolfo";
            // 
            // lblNumCon
            // 
            lblNumCon.AutoSize = true;
            lblNumCon.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumCon.Location = new Point(49, 308);
            lblNumCon.Name = "lblNumCon";
            lblNumCon.Size = new Size(100, 26);
            lblNumCon.TabIndex = 8;
            lblNumCon.Text = "21212581";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersion.Location = new Point(49, 334);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(127, 26);
            lblVersion.TabIndex = 9;
            lblVersion.Text = "Versión ?.?.?";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(lblVersion);
            Controls.Add(lblNumCon);
            Controls.Add(lblAlumno);
            Controls.Add(lblSemestre);
            Controls.Add(lblMateria);
            Controls.Add(btnConcluir);
            Controls.Add(btnInventario);
            Controls.Add(btnOrden);
            Controls.Add(btnMesas);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Proyecto final PDS";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Button btnMesas;
        private Button btnOrden;
        private Button btnInventario;
        private Button btnConcluir;
        private Label lblMateria;
        private Label lblSemestre;
        private Label lblAlumno;
        private Label lblNumCon;
        private Label lblVersion;
    }
}