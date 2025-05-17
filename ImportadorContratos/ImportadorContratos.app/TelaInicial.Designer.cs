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
            dgvContratos = new DataGridView();
            btnSalvarBanco = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvContratos).BeginInit();
            SuspendLayout();
            // 
            // btnSelecionarArquivo
            // 
            btnSelecionarArquivo.Location = new Point(327, 12);
            btnSelecionarArquivo.Name = "btnSelecionarArquivo";
            btnSelecionarArquivo.Size = new Size(163, 23);
            btnSelecionarArquivo.TabIndex = 0;
            btnSelecionarArquivo.Text = "Selecionar Arquivo";
            btnSelecionarArquivo.UseVisualStyleBackColor = true;
            btnSelecionarArquivo.Click += btnSelecionarArquivo_Click;
            // 
            // dgvContratos
            // 
            dgvContratos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContratos.Location = new Point(65, 57);
            dgvContratos.Name = "dgvContratos";
            dgvContratos.Size = new Size(673, 329);
            dgvContratos.TabIndex = 1;
            // 
            // btnSalvarBanco
            // 
            btnSalvarBanco.Location = new Point(359, 403);
            btnSalvarBanco.Name = "btnSalvarBanco";
            btnSalvarBanco.Size = new Size(114, 21);
            btnSalvarBanco.TabIndex = 2;
            btnSalvarBanco.Text = "Salvar no Banco";
            btnSalvarBanco.UseVisualStyleBackColor = true;
            btnSalvarBanco.Click += btnSalvarBanco_Click;
            // 
            // TelaInicial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 454);
            Controls.Add(btnSalvarBanco);
            Controls.Add(dgvContratos);
            Controls.Add(btnSelecionarArquivo);
            Name = "TelaInicial";
            Text = "Importador";
            ((System.ComponentModel.ISupportInitialize)dgvContratos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelecionarArquivo;
        private DataGridView dgvContratos;
        private Button btnSalvarBanco;
    }
}
