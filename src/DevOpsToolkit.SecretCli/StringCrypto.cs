using System;
using System.Text;
using SecurityDriven.Inferno;

namespace DevOpsToolkit.SecretCli
{
    public static class StringCrypto
    {
        public static string EncryptString(string stringToEncrypt, string key)
        {
            var encryptedBytes =
                SuiteB.Encrypt(Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(stringToEncrypt));

            return encryptedBytes != null ? Convert.ToBase64String(encryptedBytes) : null;
        }

        public static string DecryptString(string stringToDecrypt, string key)
        {
            var decryptedBytes = SuiteB.Decrypt(Encoding.UTF8.GetBytes(key),
                Convert.FromBase64String(stringToDecrypt));

            return decryptedBytes != null ? Encoding.UTF8.GetString(decryptedBytes) : null;
        }
    }
}