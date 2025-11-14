using System.Security.Cryptography;
using System.Text;

namespace PasswordVault
{
    public static class CryptoHelper
    {

        // Генерация ключа из пароля и соли
        public static byte[] GenerateKey(string password, byte[] salt, int iterations = 100_000)
        {
            using var deriveBytes = new Rfc2898DeriveBytes(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256 // ← безопасный алгоритм
            );

            return deriveBytes.GetBytes(32); // 256-битный ключ
        }
        public static byte[] GetOrCreateSalt(string saltPath = "salt.bin")
        {
            if (File.Exists(saltPath))
                return File.ReadAllBytes(saltPath);

            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            File.WriteAllBytes(saltPath, salt);
            return salt;
        }



        // Шифрование текста и сохранение в файл
        public static void EncryptFile(string path, string plainText, byte[] key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();

                using (var fs = new FileStream(path, FileMode.Create))
                {
                    fs.Write(aes.IV, 0, aes.IV.Length); // сохраняем IV в начале файла

                    using (var cryptoStream = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cryptoStream, Encoding.UTF8))
                    {
                        writer.Write(plainText);
                    }
                }
            }
        }

        public static string EncryptString(string plainText, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var ms = new MemoryStream()) // ← вот здесь создаётся ms
                {
                    using (var cryptoStream = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cryptoStream))
                    {
                        writer.Write(plainText);
                    }

                    return Convert.ToBase64String(ms.ToArray()); // ← здесь используется ms
                }
            }
        }

        public static string DecryptString(string cipherText, byte[] key, byte[] iv)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;

                using (var ms = new MemoryStream(buffer)) // ← создаётся ms
                using (var cryptoStream = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var reader = new StreamReader(cryptoStream))
                {
                    return reader.ReadToEnd(); // ← используется ms
                }
            }
        }

        // Расшифровка текста из файла
        public static string DecryptFile(string path, byte[] key)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                byte[] iv = new byte[16];
                fs.Read(iv, 0, iv.Length); // читаем IV из начала файла

                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.IV = iv;

                    using (var cryptoStream = new CryptoStream(fs, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (var reader = new StreamReader(cryptoStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
