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
        private int usuarioId;
        private string nomeUsuario;
        private List<Contrato> contratos;
        public TelaInicial(int usuarioId, string nomeUsuario)
        {
            //Inicializa todos os componentes da interface gráfica
            InitializeComponent();
            this.usuarioId = usuarioId;
            this.nomeUsuario = nomeUsuario;
        }
        //Busca e exibe os contratos do arquivo CSV através do clique do botao
        private void btnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            //Cria uma lista de contratos para armazenar os dados lidos do arquivo CSV
            contratos = new List<Contrato>();
            //Instancia openFileDialog do tipo OpenFileDialog para abrir o arquivo CSV
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Expecifíca o titulo e o tipo de arquivo que vai ser feito a leitura
            openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
            openFileDialog.Title = "Selecione o arquivo de contratos";

            //Abre o dialogo para o usuario selecionar o arquivo CSV
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Uma variável do tipo string que armazena o caminho do arquivo CSV
                string caminhoArquivo = openFileDialog.FileName;

                //Variável que lê todas as linhas e expecifíca o encoding
                var linhas = File.ReadAllLines(caminhoArquivo, Encoding.GetEncoding("ISO-8859-1"));

                //Um for para percorrer as linhas do arquivo
                for (int i = 1; i < linhas.Length; i++)
                {
                    //Define o tipo de separador do arquivo CSV
                    var colunas = linhas[i].Split(';');

                    //Verifica se o número de colunas é menor que 6, se sim, continua para a próxima iteração
                    if (colunas.Length < 6)
                        continue;

                    //Cria um novo objeto do tipo contrato e atribui os valores das colunas lidas do arquivo
                    var contrato = new Contrato
                    {
                        Nome = colunas[0],
                        CPF = colunas[1],
                        NumeroContrato = colunas[2],
                        Produto = colunas[3],
                        Vencimento = DateTime.Parse(colunas[4]),
                        Valor = decimal.Parse(colunas[5])
                    };

                    //Adiciona o contrato à lista de contratos
                    contratos.Add(contrato);
                }

                //Exibe os contratos lidos do arquivo CSV em um DataGridView
                dgvContratos.DataSource = contratos;

            }
        }
        //Botao que pega o metodo de salvar contratos no banco de dados
        private void btnSalvarBanco_Click(object sender, EventArgs e)
        {
            //Estrutura de condição que verifica se a lista de contratos não é nula e se tem mais de 0 elementos
            //Caso sim, chama o método SalvarContratosNoBanco passando a lista de contratos
            if (contratos != null && contratos.Count > 0)
            {
                SalvarContratosNoBanco(contratos);
            }
            //Caso não, exibe uma mensagem informando que nenhum contrato foi selecionado para salvar
            else
            {
                MessageBox.Show("Nenhum contrato selecionado para salvar.");
            }
        }
        // Método para pegar uma lista de contratos e salvar no banco de dados
        private void SalvarContratosNoBanco(List<Contrato> contratos)
        {
            //Cria uma string que recebe a conexão com o banco de dados
            string connectionString = "Server=localhost;Database=ImportadorContratosDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
            //Abre a conexão com o banco de dados passando a string anterior como parametro
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                //Pega o objeto conexao e abre a conexão com o banco de dados
                conexao.Open();
                //Para cada contrato na lista de contratos, executa o comando SQL para inserir os dados no banco
                foreach (var contrato in contratos)
                {
                    //Cria uma string que recebe uma consulta no banco de dados que insere as informações lidas do arquivo 
                    string query = "INSERT INTO Contratos (Nome, CPF, NumeroContrato, Produto, Vencimento, Valor, UsuarioId) VALUES (@Nome, @CPF, @NumeroContrato, @Produto, @Vencimento, @Valor, @UsuarioId)";
                    //Cria um objeto do tipo SqlCommand que recebe a string de consulta e a conexão com o banco de dados
                    using (SqlCommand comando = new SqlCommand(query, conexao))
                    {
                        //Adiciona os parâmetros da consulta SQL com os valores dos contratos lidos do arquivo CSV
                        comando.Parameters.AddWithValue("@Nome", contrato.Nome);
                        comando.Parameters.AddWithValue("@CPF", contrato.CPF);
                        comando.Parameters.AddWithValue("@NumeroContrato", contrato.NumeroContrato);
                        comando.Parameters.AddWithValue("@Produto", contrato.Produto);
                        comando.Parameters.AddWithValue("@Vencimento", contrato.Vencimento);
                        comando.Parameters.AddWithValue("@Valor", contrato.Valor);
                        comando.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        comando.ExecuteNonQuery();
                    }
                }
            }
            //Exibe uma mensagem informando que os contratos foram salvos com sucesso e mostra o nome do usuário responsável
            MessageBox.Show(
            $"Contratos inseridos:\n" +
            string.Join("\n", contratos.Select(c => $"{c.Nome} - {c.NumeroContrato}")) +
            $"\n\nUsuário responsável: {nomeUsuario}",
            "Contratos Salvos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
);
        }
    }
}