namespace PasswordVault
{
    partial class ChangePasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnApply;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblOldPassword = new Label();
            lblNewPassword = new Label();
            txtOldPassword = new TextBox();
            txtNewPassword = new TextBox();
            btnApply = new Button();
            SuspendLayout();
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Location = new Point(20, 20);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(95, 15);
            lblOldPassword.TabIndex = 0;
            lblOldPassword.Text = "Старый пароль:";
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Location = new Point(20, 60);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(91, 15);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "Новый пароль:";
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(130, 17);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(150, 23);
            txtOldPassword.TabIndex = 1;
            txtOldPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(130, 57);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(150, 23);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(130, 100);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(150, 30);
            btnApply.TabIndex = 4;
            btnApply.Text = "Применить";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // ChangePasswordForm
            // 
            ClientSize = new Size(320, 150);
            Controls.Add(lblOldPassword);
            Controls.Add(txtOldPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(btnApply);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Смена пароля";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
