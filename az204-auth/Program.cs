using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace az204_auth
{
    class Program
    {

        private const string _clientId = "9263eff8-2963-4b64-af11-3dd15e0619e6";
        private const string _tenantId = "591fc3b6-8ece-4eaf-97b0-a21ea910a071";
        public static async Task Main(string[] args)
        {
            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri("http://localhost")
                .Build();
            string[] scopes = { "user.read" };
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token: \t{result.AccessToken}");
        }
    }
}