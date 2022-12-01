using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace DemoWebAPI.Helpers
{
    public class KeyVault
    {
        private static string tenantid = "5274e0ff-b00d-4522-9b2e-418283781063";
        private static string clientid = "4a49aa0d-49e9-4595-bf99-0939390acd40";
        private static string clientsecret = "T3c8Q~~rD1K6dFiOxMj2shF6DUvHO~lsxsCX3clA";

        private static string keyvault_url = "https://kv-dev-api-west-001.vault.azure.net/";
        private static string connectionstring = "productConnectionString";


        public static string GetConnectionString()
        {

            ClientSecretCredential clientSecret = new ClientSecretCredential(tenantid, clientid, clientsecret);
            SecretClient secretClient = new SecretClient(new Uri(keyvault_url), clientSecret);

            var secret = secretClient.GetSecret(connectionstring);

            return secret.Value.Value;
        }
    }
}
