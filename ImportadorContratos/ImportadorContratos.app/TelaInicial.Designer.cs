namespace ImportadorContratos.app
{
    partial class TelaInicial
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
            btnSelecionarArquivo = new Button();
            SuspendLayout();
            // 
            // btnSelecionarArquivo
            // 
            btnSelecionarArquivo.Location = new Point(268, 203);
            btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            btnSelecionarArquivo.Size = new Size(163, 23);
            btnSelecionarArquivo.TabIndex = 0;
            btnSelecionarArquivo.Text = "Selecionar Arquivo";
            btnSelecionarArquivo.UseVisualStyleBackColor = true;
            btnSelecionarArquivo.Click += btnSelecionarArquivo_Click;
            // 
            // TelaInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 357);
            Controls.Add(btnSelecionarArquivo);
            Name = "TelaInicial";
            Text = "Importador";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelecionarArquivo;
    }
}
