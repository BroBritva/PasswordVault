using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordVault
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabControl;
        private TabPage tabPasswords;
        private Panel panelPasswords;
        private DataGridView dataGridView1;
        private Panel panelBottom;
        private Button btnSave;
        private Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabPasswords = new TabPage();
            panelPasswords = new Panel();
            dataGridView1 = new DataGridView();
            panelBottom = new Panel();
            btnSave = new Button();
            btnExit = new Button();

            tabControl.SuspendLayout();
            tabPasswords.SuspendLayout();
            panelPasswords.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();

            // === TabControl ===
            tabControl.Controls.Add(tabPasswords);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 400);
            tabControl.TabIndex = 0;

            // === TabPage "Пароли" ===
            tabPasswords.Controls.Add(panelPasswords);
            tabPasswords.Location = new Point(4, 24);
            tabPasswords.Name = "tabPasswords";
            tabPasswords.Size = new Size(792, 372);
            tabPasswords.TabIndex = 0;
            tabPasswords.Text = "Сейф";

            // === PanelPasswords ===
            panelPasswords.Controls.Add(panelBottom);
            panelPasswords.Controls.Add(dataGridView1);
            panelPasswords.Dock = DockStyle.Fill;
            panelPasswords.Location = new Point(0, 0);
            panelPasswords.Name = "panelPasswords";
            panelPasswords.Size = new Size(792, 372);
            panelPasswords.TabIndex = 0;

            // === DataGridView ===
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(792, 322);
            dataGridView1.TabIndex = 1;

            // === PanelBottom ===
            panelBottom.Controls.Add(btnSave);
            panelBottom.Controls.Add(btnExit);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 322);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(792, 50);
            panelBottom.TabIndex = 0;

            // === btnSave ===
            btnSave.Anchor = AnchorStyles.Right;
            btnSave.Location = new Point(600, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Сохранить";
            btnSave.Click += BtnSave_Click;

            // === btnExit ===
            btnExit.Anchor = AnchorStyles.Right;
            btnExit.Location = new Point(700, 10);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(90, 30);
            btnExit.TabIndex = 1;
            btnExit.Text = "Выход";
            btnExit.Click += btnExit_Click;

            // === MainForm ===
            ClientSize = new Size(800, 400);
            Controls.Add(tabControl);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Password Vault";

            tabControl.ResumeLayout(false);
            tabPasswords.ResumeLayout(false);
            panelPasswords.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
