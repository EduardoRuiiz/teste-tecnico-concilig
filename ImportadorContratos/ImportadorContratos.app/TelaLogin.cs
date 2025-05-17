using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace ImportadorContratos.app
{
    public partial class TelaLogin : Form
    {
        // Propriedades para armazenar o ID e o nome do usuário, e exibir no formulário
        [Browsable(false)]
        public int UsuarioId { get; private set; }
        [Browsable(false)]
        public string NomeUsuario { get; private set; }

        public TelaLogin()
        {
            //Inicializa todos os componentes da interfáce gráfica
            InitializeComponent();
        }

        // Método que é chamado quando o botão "Entrar" é clicado
        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            //Armazena o que for digitado nos campos de textos "login" e "senha" em variáveis, e remove os espaços em branco
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text.Trim();

            //Cria uma váriavel do tipo string que armazena a string de conexão com o banco de dados
            string connectionString = "Server=localhost;Database=ImportadorContratosDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
            //Cria uma conexão com o banco de dados usando a string de conexão
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                //Abre a conexão com o banco de dados
                conexao.Open();
                //Cria uma variável do tipo string que armazena a query SQL que será executada no banco de dados
                //A query seleciona o ID e o nome do usuário da tabela "Usuarios" onde o login e a senha hash correspondem aos valores informados
                string query = "SELECT Id, Nome FROM Usuarios WHERE Login = @Login AND SenhaHash = HASHBYTES('SHA2_256', @Senha)";

                //Cria um objeto do tipo SqlCommand que recebe a string de consulta e a conexão com o banco de dados
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    //Adiciona os parâmetros da consulta SQL ao objeto comando, expecificando os tipos de dados e os tamanhos
                    comando.Parameters.Add("@Login", System.Data.SqlDbType.NVarChar, 100).Value = login;
                    comando.Parameters.Add("@Senha", System.Data.SqlDbType.VarChar, 255).Value = senha;

                    //Executa a consulta no banco de dados e armazena o resultado em um SqlDataReader
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        //Estrutura de condição que verifica se o SqlDataReader retornou algum resultado
                        //Caso sim, armazena o ID e o nome do usuário nas propriedades correspondentes e fecha a tela de login
                        if (reader.Read())
                        {
                            UsuarioId = reader.GetInt32(0);
                            NomeUsuario = reader.GetString(1);
                            DialogResult = DialogResult.OK;
                        }
                        //Caso não, exibe uma mensagem informando que o login ou a senha estão inválidos
                        else
                        {
                            MessageBox.Show("Login ou senha inválidos.");
                        }
                    }
                }
            }
        }

        //Método que exibe a label indicativa para inserção do login
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Método que exibe a label indicativa para inserção de senha
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Método que exibe um campo de texto para o usuário digitar a senha
        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        //Método que exibe um campo de texto para o usuário digitar o login
        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}