using System.Runtime.InteropServices;
namespace PasswordVault
{
    public partial class LoginForm : Form
    {
        [LibraryImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static partial IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
        int nWidthEllipse, int nHeightEllipse);


        private int attempts = 0;
        private const int maxAttempts = 3;
        public byte[]? Key { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            ShowInTaskbar = true;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            using (var ms = new MemoryStream(Properties.Resources.apps))
            {
                this.Icon = new Icon(ms);
            }
            // Назначаем кнопку входа как AcceptButton
            this.AcceptButton = btnLogin;

            // Скрываем ввод пароля

            txtPassword.UseSystemPasswordChar = true;
            // Подсказка
            PictureBox helpIcon = new()
            {
                Image = SystemIcons.Question.ToBitmap(), // стандартная иконка вопроса
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(25, 25),
                Cursor = Cursors.Hand,
                Location = new Point(
         txtPassword.Left + (txtPassword.Width - 25) / 2, // центр по горизонтали
         txtPassword.Top - 30 // над полем, на 30 пикселей выше
     )
            };
            Controls.Add(helpIcon);

            ToolTip tooltip = new();
            tooltip.SetToolTip(helpIcon, "Первый введённый пароль станет основным для входа.");
            tooltip.BackColor = Color.Aqua;
            Controls.Add(helpIcon);
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            byte[] salt = CryptoHelper.GetOrCreateSalt();
            byte[] key = CryptoHelper.GenerateKey(password, salt);

            if (VaultValidator.IsVaultValid(key))
            {
                this.Key = key;
                this.DialogResult = DialogResult.OK; // ← сигнализируем успешный вход
                this.Close(); // ← закрываем LoginForm
            }
            else
            {
                attempts++;
                MessageBox.Show("Неверный пароль");
                txtPassword.Clear();
                txtPassword.Focus();

                if (attempts >= 3)
                {
                    MessageBox.Show("Слишком много попыток. Приложение будет закрыто.");
                    Application.Exit();
                }
            }
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            using var changeForm = new ChangePasswordForm();
            changeForm.StartPosition = FormStartPosition.CenterParent;
            changeForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ActiveControl = btnLogin;


        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void BtnFullReset_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
        "Это удалит все сохранённые пароли, ключи и временные файлы.\nВы уверены?",
        "Подтверждение сброса",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string appPath = Application.StartupPath;

                string[] targets = [
            Path.Combine(appPath, "vault.dat"),
            Path.Combine(appPath, "vault.bin"),
            Path.Combine(appPath, "salt.dat"),
            Path.Combine(appPath, "salt.bin")
        ];

                foreach (var file in targets)
                {
                    if (File.Exists(file))
                        File.Delete(file);
                }

                MessageBox.Show("Хранилище сброшено. Приложение будет перезапущено.", "Сброс завершён", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сбросе: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
