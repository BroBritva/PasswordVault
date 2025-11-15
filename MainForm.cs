namespace PasswordVault
{
    public partial class MainForm : Form
    {
        private readonly VaultManager vault;
        private readonly List<PasswordEntry> entries;
        

        public MainForm(byte[] key)
        {
            InitializeComponent();
            using (var ms = new MemoryStream(Properties.Resources.apps))
            {
                this.Icon = new Icon(ms);
            }
            vault = new VaultManager(key);
            entries = vault.Load();
            // 🔽 Добавляем пустые строки, если их меньше 10
            while (entries.Count < 15)
            {
                entries.Add(new PasswordEntry());
            }
            dataGridView1.DataSource = new BindingSource { DataSource = entries };
            FormClosing += MainForm_FormClosing; // обработчик закрытия формы
        }



        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Диалог подтверждения выхода
            vault.Save(entries);
            var result = MessageBox.Show("Вы действительно хотите закрыть приложение?",
                                         "Подтверждение выхода",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // отменяем закрытие
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            vault.Save(entries);
            MessageBox.Show("Данные сохранены!");
        }

        private void BtnExitMain_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
       
        private void BtnSaveAll_Click(object sender, EventArgs e)
        {
            vault.Save(entries); // сохраняем пароли
            MessageBox.Show("Все данные успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
    }
}