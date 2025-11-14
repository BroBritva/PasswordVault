namespace PasswordVault
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK && loginForm.Key != null)
            {
                Application.Run(new MainForm(loginForm.Key));
            }
        }
    }
}
