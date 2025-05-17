namespace ImportadorContratos.app
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Criado e instanciado um objeto do tipo TelaLogin
            var telaLogin = new TelaLogin();
            //Abre o dialogo de login e verifica se o usuario clicou no botao de login
            if (telaLogin.ShowDialog() == DialogResult.OK)
            {
                //Se o usuario clicou no botao de login, inicia a tela inicial passando o id e nome do usuario logado
                //e executa a aplicação
                Application.Run(new TelaInicial(telaLogin.UsuarioId, telaLogin.NomeUsuario));
                
            }
        }
    }
}