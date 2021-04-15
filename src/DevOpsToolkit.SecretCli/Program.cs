using System;
using System.IO;
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"");
            Console.WriteLine(@"                            .__  .__ ");
            Console.WriteLine(@"  ______ ____   ____   ____ |  | |__|");
            Console.WriteLine(@" /  ___// __ \ /    \_/ ___\|  | |  |");
            Console.WriteLine(@" \___ \\  ___/|   |  \  \___|  |_|  |");
            Console.WriteLine(@"/____  >\___  >___|  /\___  >____/__|");
            Console.WriteLine(@"     \/     \/     \/     \/         ");
            Console.WriteLine(@"");
            
            var configuration = Configuration.GetConfiguration();

            Console.WriteLine("Enter plain text secret:");
            var secret = Console.ReadLine();
            Console.WriteLine(@"");
            Console.WriteLine($"Plain: {secret}");
            Console.WriteLine($"Encrypted: {StringCrypto.EncryptString(secret, configuration["EncryptionKey"])}");

            Console.WriteLine("");
            Console.WriteLine("Press key to exit.");
            Console.ReadLine();
        }
    }
}