using ImportadorContratos.App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
            openFileDialog.Title = "Selecione o arquivo de contratos";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;

                List<Contrato> contratos = new List<Contrato>();

                var linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("ISO-8859-1"));

                for (int i = 1; i < linhas.Length; i++) // Pula a primeira linha (cabeçalho)
                {
                    var colunas = linhas[i].Split(';'); // Se for tab, usa ';'

                    if (colunas.Length < 6)
                        continue;

                    var contrato = new Contrato
                    {
                        Nome = colunas[0],
                        CPF = colunas[1],
                        NumeroContrato = colunas[2],
                        Produto = colunas[3],
                        Vencimento = DateTime.Parse(colunas[4]),
                        Valor = decimal.Parse(colunas[5])
                    };

                    contratos.Add(contrato);
                }

                dgvContratos.DataSource = contratos;

            }
        }
    }
}
