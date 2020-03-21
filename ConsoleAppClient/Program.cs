using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppClient
{
    class Program
    {
        public static void Main(string[] args) => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            // Get the discovery end points using metadata of the identity server
            var discovery = await DiscoveryClient.GetAsync("https://localhost:44343");

            if (discovery.IsError)
            {
                Console.WriteLine(discovery.Error);
                return;
            }

            // Grab a bearer token
            // Values are configured in BankOfDotNet.IdentityServer.Config.cs
            // This is the same as what we did in Postman request named "Request Token From BankOfDotNet.IdentityServer"
            var tokenClient = new TokenClient(discovery.TokenEndpoint, "Client", "secretpass");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("RegistrationAPI");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");
 
        // Consume our BankOfDotNet.API
        var client = new HttpClient();
            // In Postman, this is the Authorization token we defined in the Headers
            client.SetBearerToken(tokenResponse.AccessToken);

            var customerInfo = new StringContent(
                JsonConvert.SerializeObject(
                    new { Id = 10, FirstName = "Girish", MiddleName="Srini", LastName = "Srinivasa",EmailAddress="g.srinivasa@test.com",MobileNumber="043892839" }),
                Encoding.UTF8,
                "application/json");

            var createStudentResponse = await client.PostAsync("https://localhost:44332/api/registrations",
                customerInfo);

            try
            { 
                if (!createStudentResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Create Student: " + createStudentResponse.StatusCode);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            var getStudentResponse = await client.GetAsync("https://localhost:44332/api/registrations");

            if (!getStudentResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Get Student: " + getStudentResponse.StatusCode);
            }
            else
            {
                var content = await getStudentResponse.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }

            Console.Read();

        }
    }
}
