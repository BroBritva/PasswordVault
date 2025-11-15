namespace PasswordVault
{
    public class PasswordEntry
    {
        public string Site { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RecoveryFilePath { get; set; } = string.Empty;
    }
}
