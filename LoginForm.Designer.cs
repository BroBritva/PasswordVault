namespace PasswordVault
{
    partial class LoginForm
    {
        /// <summary>
       
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            btnChangePassword = new Button();
            btnFullReset = new Button();
            SuspendLayout();
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = SystemColors.Window;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.Location = new Point(26, 100);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "введите пароль";
            txtPassword.PasswordChar = '●';
            txtPassword.RightToLeft = RightToLeft.No;
            txtPassword.Size = new Size(308, 23);
            txtPassword.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.AutoSize = true;
            btnLogin.Location = new Point(119, 146);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(147, 40);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.None;
            btnExit.AutoSize = true;
            btnExit.Location = new Point(119, 217);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(147, 37);
            btnExit.TabIndex = 2;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // lab
            // 
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = SystemColors.Highlight;
            btnChangePassword.Location = new Point(26, 10);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(107, 23);
            btnChangePassword.TabIndex = 4;
            btnChangePassword.Text = "сменить пароль";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += BtnChangePassword_Click;
            // 
            // btnFullReset
            // 
            btnFullReset.BackColor = Color.Red;
            btnFullReset.Location = new Point(281, 12);
            btnFullReset.Name = "btnFullReset";
            btnFullReset.Size = new Size(75, 23);
            btnFullReset.TabIndex = 5;
            btnFullReset.Text = "full reset";
            btnFullReset.UseVisualStyleBackColor = false;
            btnFullReset.Click += BtnFullReset_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(368, 298);
            Controls.Add(btnFullReset);
            Controls.Add(btnChangePassword);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        
        private Button btnChangePassword;
        private Button btnFullReset;
    }
}