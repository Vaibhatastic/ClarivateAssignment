using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Web.Http;

namespace ClarivateAssessment.Handler
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync(){
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }
            string authHeader = Request.Headers["Authorization"];
            var byteArray = Convert.FromBase64String(authHeader);
            string decodedAuthHeader = Encoding.UTF8.GetString(byteArray);
            if (!string.IsNullOrEmpty(decodedAuthHeader))
            {
                string[] credentials = decodedAuthHeader.Split(":");
                if (credentials[0] == "admin" && credentials[1] == "admin")
                {
                    return AuthenticateResult.Success(new AuthenticationTicket(new ClaimsPrincipal(new ClaimsIdentity("BasicAuthentication")), "BasicAuthentication"));
                }
            }
            return AuthenticateResult.Fail("Authentication Failed");
        }
    }
}
