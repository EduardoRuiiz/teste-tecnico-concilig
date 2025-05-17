using ImportadorContratos.App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace ImportadorContratos.app
{
    public partial class TelaInicial : Form
    {
        private List<Contrato> contratos;
        public TelaInicial()
        {
            InitializeComponent();
        }
        //Busca e exibe os contratos do arquivo CSV
        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            contratos = new List<Contrato>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
            openFileDialog.Title = "Selecione o arquivo de contratos";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoArquivo = openFileDialog.FileName;

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
        //Botao que pega o metodo de salvar contratos no banco de dados
        private void btnSalvarBanco_Click(object sender, EventArgs e)
        {
            if (contratos != null && contratos.Count > 0)
            {
                SalvarContratosNoBanco(contratos);
            }
            else
            {
                MessageBox.Show("Nenhum contrato selecionado para salvar.");
            }
        }
        // Método para pegar uma lista de contratos e salvar no banco de dados
        private void SalvarContratosNoBanco(List<Contrato> contratos)
        {
            string connectionString = "Server=localhost;Database=ImportadorContratosDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                foreach (var contrato in contratos)
                {
                    string query = "INSERT INTO Contratos (Nome, CPF, NumeroContrato, Produto, Vencimento, Valor) VALUES (@Nome, @CPF, @NumeroContrato, @Produto, @Vencimento, @Valor)";
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@Nome", contrato.Nome);
                        comando.Parameters.AddWithValue("@CPF", contrato.CPF);
                        comando.Parameters.AddWithValue("@NumeroContrato", contrato.NumeroContrato);
                        comando.Parameters.AddWithValue("@Produto", contrato.Produto);
                        comando.Parameters.AddWithValue("@Vencimento", contrato.Vencimento);
                        comando.Parameters.AddWithValue("@Valor", contrato.Valor);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Contratos salvos no banco com sucesso!");
        }
    }
}