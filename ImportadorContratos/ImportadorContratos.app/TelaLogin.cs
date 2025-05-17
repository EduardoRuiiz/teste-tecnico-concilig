using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.ComponentModel;

namespace ImportadorContratos.app
{
    public partial class TelaLogin : Form
    {
        [Browsable(false)]
        public int UsuarioId { get; private set; }
        [Browsable(false)]
        public string NomeUsuario { get; private set; }

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text.Trim();

            string connectionString = "Server=localhost;Database=ImportadorContratosDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();
                string query = "SELECT Id, Nome FROM Usuarios WHERE Login = @Login AND SenhaHash = HASHBYTES('SHA2_256', @Senha)";
                using (SqlCommand comando = new SqlCommand(query, conexao))
                {
                    comando.Parameters.Add("@Login", System.Data.SqlDbType.NVarChar, 100).Value = login;
                    comando.Parameters.Add("@Senha", System.Data.SqlDbType.VarChar, 255).Value = senha;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UsuarioId = reader.GetInt32(0);
                            NomeUsuario = reader.GetString(1);
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("Login ou senha inválidos.");
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}