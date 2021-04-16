using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommandLine;
using DevOpsToolkit.SecretCli.Models;
using SecurityDriven.Inferno;

namespace DevOpsToolkit.SecretCli
{
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
            
            Parser.Default.ParseArguments<Encrypt, Decrypt>(args)
                .WithParsed<Encrypt>(EncryptString)
                .WithParsed<Decrypt>(DecryptString)
                .WithNotParsed(Errors);
        }
        
        private static void Errors(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine($"Error: {error.ToString()}");
            }
        }
        
        private static void EncryptString(Encrypt options)
        {
            var configuration = Configuration.GetConfiguration();

            Console.WriteLine(@"");
            Console.WriteLine($"Plain: {options.Value}");
            Console.WriteLine($"Encrypted: {StringCrypto.EncryptString(options.Value, configuration["EncryptionKey"])}");

            Console.WriteLine("");
            Console.WriteLine("Press key to exit.");
            Console.ReadLine();
        }
        
        private static void DecryptString(Decrypt options)
        {
            var configuration = Configuration.GetConfiguration();

            Console.WriteLine(@"");
            Console.WriteLine($"Encrypted: {options.Value}");
            Console.WriteLine($"Plain: {StringCrypto.DecryptString(options.Value, configuration["EncryptionKey"])}");

            Console.WriteLine("");
            Console.WriteLine("Press key to exit.");
            Console.ReadLine();
        }
    }
}