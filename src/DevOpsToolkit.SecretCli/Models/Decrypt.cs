using CommandLine;

namespace DevOpsToolkit.SecretCli.Models
{
    [Verb("decrypt", HelpText = "Decrypt a string.")]
    public class Decrypt
    {
        [Option('v', "value", Required = true, HelpText = "Encrypted value.")]
        public string Value { get; set; }
    }
}