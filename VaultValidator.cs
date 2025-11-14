using System.Text.Json;

namespace PasswordVault
{
    public static class VaultValidator
    {
        private const string VaultFilePath = "vault.dat";

        /// <summary>
        /// Проверяет, можно ли расшифровать и десериализовать vault-файл с заданным ключом.
        /// </summary>
        /// <param name="key">Ключ, полученный из мастер-пароля и соли</param>
        /// <returns>true — если файл существует, успешно расшифрован и содержит валидные данные</returns>
        public static bool IsVaultValid(byte[] key)
        {
            string path = "vault.dat";

            // Если файл не существует — это первый запуск → считаем валидным
            if (!File.Exists(path))
                return true;

            try
            {
                string json = CryptoHelper.DecryptFile(path, key);
                var entries = JsonSerializer.Deserialize<List<PasswordEntry>>(json);
                return entries != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
