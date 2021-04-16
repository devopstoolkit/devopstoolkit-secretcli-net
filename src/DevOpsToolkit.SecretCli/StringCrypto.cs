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
                SuiteB.Encrypt(Encoding.Default.GetBytes(key), Encoding.Default.GetBytes(stringToEncrypt));

            return encryptedBytes != null ? Convert.ToBase64String(encryptedBytes) : null;
        }

        public static string DecryptString(string stringToDecrypt, string key)
        {
            var decryptedBytes = SuiteB.Decrypt(Encoding.Default.GetBytes(key),
                Convert.FromBase64String(stringToDecrypt));

            return decryptedBytes != null ? Encoding.Default.GetString(decryptedBytes) : null;
        }
    }
}