using System;
using System.Windows.Forms;

namespace ImportadorContratos.app
{
    public partial class TelaInicial : Form
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botão clicado!");
        }
    }
}
