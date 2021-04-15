using Microsoft.Extensions.Configuration;

namespace DevOpsToolkit.SecretCli
{
    public static class Configuration
    {
        public static IConfiguration GetConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", false, true)
                .Build();

            return configuration;
        }
    }
}