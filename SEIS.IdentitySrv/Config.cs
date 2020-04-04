using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace SEIS.IdentitySrv
{
    public class Config
    {
        // Used for Open-ID Connect Identity scopes
        public static IEnumerable<IdentityResource> GetidentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // Used for OAuth Identity scopes
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "sgirish",
                    Password = "Password@01"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "jsmith",
                    Password = "Password@02"
                }
            };
        }

        // Used for OAuth Identity scopes
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
                // This is the resource definition for the Registration API
                new ApiResource("RegistrationAPI", "Student Registration API")
            };
        }
        // Used for OAuth Identity scopes
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // Used by ConsoleAppClient
                // Client-Credential based grant type 
                new Client
                {
                    // The Client ID called  "Client".  Used when requesting an access token from IdentityServer
                    ClientId = "Client",
                    //Grant Type refers to the way by which Client communicates with IdentityServer
                    //to obtain access token so the Web API resource can be accessed.
                    //Grant Type of ClientCredentials are used  by machine to machine, trusted 1st party sources, server-to-server
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // Set-up a hashed password called "secretpass".  Used when requesting an access token from IdentityServer
                    ClientSecrets =
                    {
                        new Secret("secretpass".Sha256())
                    },
                    // Define the scope of this client (might be a console client, native app, ios app, web app)
                    // We are only allowing the client to access RegistrationAPI resource
                    AllowedScopes = { "RegistrationAPI" }
                }

            };
        }
    }
}
