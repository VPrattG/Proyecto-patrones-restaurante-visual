namespace PDS_U4_Examen
{
    partial class Form6
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
            chkPDF = new CheckBox();
            chkXML = new CheckBox();
            btnRegresar = new Button();
            btnConfirmar = new Button();
            lblTitulo = new Label();
            lblDescripcion = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // chkPDF
            // 
            chkPDF.AutoSize = true;
            chkPDF.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkPDF.Location = new Point(65, 173);
            chkPDF.Name = "chkPDF";
            chkPDF.Size = new Size(167, 30);
            chkPDF.TabIndex = 2;
            chkPDF.Text = "¿Formato PDF?";
            chkPDF.UseVisualStyleBackColor = true;
            // 
            // chkXML
            // 
            chkXML.AutoSize = true;
            chkXML.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            chkXML.Location = new Point(65, 209);
            chkXML.Name = "chkXML";
            chkXML.Size = new Size(167, 30);
            chkXML.TabIndex = 3;
            chkXML.Text = "¿Formato XML?";
            chkXML.UseVisualStyleBackColor = true;
            // 
            // btnRegresar
            // 
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegresar.Location = new Point(84, 291);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(130, 40);
            btnRegresar.TabIndex = 23;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnConfirmar.Location = new Point(84, 245);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(130, 40);
            btnConfirmar.TabIndex = 24;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Minecraftia", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitulo.Location = new Point(54, 9);
            lblTitulo.Margin = new Padding(10, 0, 3, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(189, 40);
            lblTitulo.TabIndex = 25;
            lblTitulo.Text = "Finalizar día";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblDescripcion.Location = new Point(12, 62);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(256, 52);
            lblDescripcion.TabIndex = 26;
            lblDescripcion.Text = "Se creará un y enviará por\r\n correo un archivo .txt";
            lblDescripcion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Minecraftia", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(90, 136);
            label1.Name = "label1";
            label1.Size = new Size(118, 26);
            label1.TabIndex = 27;
            label1.Text = "Adicionales:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 343);
            Controls.Add(label1);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            Controls.Add(btnConfirmar);
            Controls.Add(btnRegresar);
            Controls.Add(chkXML);
            Controls.Add(chkPDF);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form6";
            Text = "Form6";
            Shown += Form6_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkPDF;
        private CheckBox chkXML;
        private Button btnRegresar;
        private Button btnConfirmar;
        private Label lblTitulo;
        private Label lblDescripcion;
        private Label label1;
    }
}