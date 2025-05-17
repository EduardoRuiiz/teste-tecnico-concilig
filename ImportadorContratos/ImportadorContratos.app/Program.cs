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

            var telaLogin = new TelaLogin();
            if (telaLogin.ShowDialog() == DialogResult.OK)
            {
            Application.Run(new TelaInicial(telaLogin.UsuarioId, telaLogin.NomeUsuario));
                
            }
        }
    }
}