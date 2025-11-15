using System.Text.Json;

namespace PasswordVault
{
    public class VaultManager
    {
        private readonly string filePath = "vault.dat";
        private readonly byte[] key;

        public VaultManager(byte[] key)
        {
            this.key = key;
        }

        public void Save(List<PasswordEntry> entries)
        {
            string json = JsonSerializer.Serialize(entries);
            CryptoHelper.EncryptFile(filePath, json, key);
        }

        public List<PasswordEntry> Load()
        {
            if (!File.Exists(filePath))
                return new List<PasswordEntry>();

            string json = CryptoHelper.DecryptFile(filePath, key);
            return JsonSerializer.Deserialize<List<PasswordEntry>>(json) ?? new List<PasswordEntry>();
        }
    }
}
