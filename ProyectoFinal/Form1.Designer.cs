namespace ProyectoFinal
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
            Mínimo = new Label();
            label2 = new Label();
            tbMinimoRango = new TextBox();
            tbMaximoRango = new TextBox();
            btnEjecutar = new Button();
            lbResultado = new ListBox();
            SuspendLayout();
            // 
            // Mínimo
            // 
            Mínimo.AutoSize = true;
            Mínimo.Location = new Point(46, 35);
            Mínimo.Name = "Mínimo";
            Mínimo.Size = new Size(86, 15);
            Mínimo.TabIndex = 0;
            Mínimo.Text = "Rango Mínimo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 91);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 1;
            label2.Text = "Rango Máximo";
            // 
            // tbMinimoRango
            // 
            tbMinimoRango.Location = new Point(46, 53);
            tbMinimoRango.Name = "tbMinimoRango";
            tbMinimoRango.Size = new Size(140, 23);
            tbMinimoRango.TabIndex = 2;
            // 
            // tbMaximoRango
            // 
            tbMaximoRango.Location = new Point(46, 109);
            tbMaximoRango.Name = "tbMaximoRango";
            tbMaximoRango.Size = new Size(140, 23);
            tbMaximoRango.TabIndex = 3;
            // 
            // btnEjecutar
            // 
            btnEjecutar.Location = new Point(46, 154);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(140, 48);
            btnEjecutar.TabIndex = 4;
            btnEjecutar.Text = "Ejecutar";
            btnEjecutar.UseVisualStyleBackColor = true;
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // lbResultado
            // 
            lbResultado.FormattingEnabled = true;
            lbResultado.Location = new Point(217, 12);
            lbResultado.Name = "lbResultado";
            lbResultado.Size = new Size(411, 379);
            lbResultado.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 415);
            Controls.Add(lbResultado);
            Controls.Add(btnEjecutar);
            Controls.Add(tbMaximoRango);
            Controls.Add(tbMinimoRango);
            Controls.Add(label2);
            Controls.Add(Mínimo);
            Name = "Form1";
            Text = "Trabajo Final";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Mínimo;
        private Label label2;
        private TextBox tbMinimoRango;
        private TextBox tbMaximoRango;
        private Button btnEjecutar;
        private ListBox lbResultado;
    }
}
