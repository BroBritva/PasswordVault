namespace PasswordVault
{
    public class PasswordEntry
    {
        public string Site { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string RecoveryFilePath { get; set; }
    }
}
