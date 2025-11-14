namespace PasswordVault
{
    public partial class ChangePasswordForm : Form
    {
        private static readonly byte[] salt = CryptoHelper.GetOrCreateSalt();

        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Новый пароль не может быть пустым!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Генерация ключа из старого пароля
                byte[] oldKey = CryptoHelper.GenerateKey(oldPassword, salt);

                // Попытка расшифровать файл
                string decryptedData = CryptoHelper.DecryptFile("vault.dat", oldKey);

                // Генерация ключа из нового пароля
                byte[] newKey = CryptoHelper.GenerateKey(newPassword, salt);

                // Перешифровка с новым ключом
                CryptoHelper.EncryptFile("vault.dat", decryptedData, newKey);

                MessageBox.Show("Пароль успешно изменён!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Старый пароль неверен или файл повреждён.\n" + ex.Message,
                                "Ошибка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
