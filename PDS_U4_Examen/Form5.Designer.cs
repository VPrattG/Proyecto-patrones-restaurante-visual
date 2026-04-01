namespace PDS_U4_Examen
{
    partial class Form5
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
            lvwInventario = new ListView();
            chIngrediente = new ColumnHeader();
            chCantActual = new ColumnHeader();
            chMaximo = new ColumnHeader();
            chRellenar = new ColumnHeader();
            label1 = new Label();
            btnRegresar = new Button();
            btnReabastecer = new Button();
            SuspendLayout();
            // 
            // lvwInventario
            // 
            lvwInventario.Columns.AddRange(new ColumnHeader[] { chIngrediente, chCantActual, chMaximo, chRellenar });
            lvwInventario.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lvwInventario.GridLines = true;
            lvwInventario.Location = new Point(12, 52);
            lvwInventario.Name = "lvwInventario";
            lvwInventario.Size = new Size(776, 339);
            lvwInventario.TabIndex = 0;
            lvwInventario.UseCompatibleStateImageBehavior = false;
            lvwInventario.View = View.Details;
            lvwInventario.SelectedIndexChanged += lvwInventario_SelectedIndexChanged;
            // 
            // chIngrediente
            // 
            chIngrediente.Text = "Ingrediente";
            // 
            // chCantActual
            // 
            chCantActual.Text = "Cantidad Actual";
            // 
            // chMaximo
            // 
            chMaximo.Text = "Cantidad Máxima";
            // 
            // chRellenar
            // 
            chRellenar.Text = "¿Necesita reabastecerse?";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Minecraftia", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(280, 9);
            label1.Name = "label1";
            label1.Size = new Size(258, 40);
            label1.TabIndex = 1;
            label1.Text = "Inventario actual";
            // 
            // btnRegresar
            // 
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegresar.Location = new Point(650, 397);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(138, 40);
            btnRegresar.TabIndex = 22;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnReabastecer
            // 
            btnReabastecer.Cursor = Cursors.Hand;
            btnReabastecer.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnReabastecer.Location = new Point(12, 397);
            btnReabastecer.Name = "btnReabastecer";
            btnReabastecer.Size = new Size(138, 40);
            btnReabastecer.TabIndex = 23;
            btnReabastecer.Text = "Reabastecer";
            btnReabastecer.UseVisualStyleBackColor = true;
            btnReabastecer.Click += btnReabastecer_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(btnReabastecer);
            Controls.Add(btnRegresar);
            Controls.Add(label1);
            Controls.Add(lvwInventario);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form5";
            Text = "Inventario";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvwInventario;
        private ColumnHeader chIngrediente;
        private ColumnHeader chCantActual;
        private ColumnHeader chMaximo;
        private ColumnHeader chRellenar;
        private Label label1;
        private Button btnRegresar;
        private Button btnReabastecer;
    }
}