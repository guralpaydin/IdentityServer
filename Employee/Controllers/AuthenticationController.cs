using Employee.Helpers;
using Employee.Model;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employee.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly DataContext context;

        public AuthenticationController(IHttpClientFactory httpClientFactory, DataContext context)
        {
            this.httpClientFactory = httpClientFactory;
            this.context = context;
        }

        [HttpPost("GetToken")]
        public async Task<IActionResult> GetToken([FromBody] TokenRequestModel model)
        {
            var user = context.Users.SingleOrDefault(x => x.Name == model.Username && x.Password == model.Password);

            if (user == null) return Unauthorized();

            //get access token
            var serverClient = httpClientFactory.CreateClient();
            var discoveryDocument = await serverClient.GetDiscoveryDocumentAsync("https://localhost:44357/");
            var tokenResponse = await serverClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = discoveryDocument.TokenEndpoint,
                ClientId = "client_id_1",
                ClientSecret = "client_1 icin secret degeri default olarak verildi",
                Scope = "EmployeeApi"
            });

            return Ok(new
            {
                access_token = tokenResponse.AccessToken
            });

            return Unauthorized();
        }
    }
}
