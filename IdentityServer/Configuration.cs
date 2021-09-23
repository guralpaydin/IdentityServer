using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Configuration
    {
        public static IEnumerable<ApiResource> GetApis() =>
            //new List<ApiResource> { new ApiResource(name: "EmployeeApi", displayName: "EmployeeApi Full Access") };
            new List<ApiResource> { new ApiResource() {
                Scopes = new List<string>{ "EmployeeApi"},
                Name="EmployeeApi",
                DisplayName="EmployeeApi Full Access",
                Enabled=true
            } };

        public static IEnumerable<Client> GetClients() =>
            new List<Client> {
                new Client{
                    ClientId = "client_id_1",
                    ClientSecrets = { new Secret("client_1 icin secret degeri default olarak verildi".ToSha256()) },
                    ClientName = "DefaultClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "EmployeeApi"
                        ,IdentityServer4.IdentityServerConstants.StandardScopes.OpenId
                        ,IdentityServer4.IdentityServerConstants.StandardScopes.Profile
                        ,"offline_access"}
            } };

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
             {
                 new ApiScope(name: "EmployeeApi",displayName:"EmployeeApi Full Access")
             };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
    }
}
