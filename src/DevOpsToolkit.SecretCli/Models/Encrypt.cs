using CommandLine;

namespace DevOpsToolkit.SecretCli.Models
{
    [Verb("encrypt", HelpText = "Encrypt a string.")]
    public class Encrypt
    {
        [Option('v', "value", Required = true, HelpText = "Plain text value.")]
        public string Value { get; set; }
    }
}