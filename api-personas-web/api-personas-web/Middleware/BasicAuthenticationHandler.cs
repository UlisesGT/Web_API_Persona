using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

/*
using api_personas_web.Helpers;
*/

using Microsoft.EntityFrameworkCore;
using api_personas_web.Entities;

namespace api_personas_web.Middleware
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        #region Propiedades
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(typeof(Program));
        private readonly DBContext _Context;
        #endregion 


        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            Microsoft.Extensions.Logging.ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            DBContext dBContext
        )
            : base(options, logger, encoder, clock)
        {
            _Context = dBContext;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            bool _Auth = false;
            string _Username = string.Empty;
            string _Password = string.Empty;

            try
            {
                var _AuthHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var _CredentialBytes = Convert.FromBase64String(_AuthHeader.Parameter);
                var _Credentials = Encoding.UTF8.GetString(_CredentialBytes).Split(new[] { ':' }, 2);
                _Username = _Credentials[0];
                _Password = _Credentials[1];

                if (_Username == "uappPersonas" && _Password == "0on3CjJ*$EO&")
                {
                    _Auth = true;
                }
                _Auth = true;
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (!_Auth)
                return AuthenticateResult.Fail("Invalid token");

            var _Claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, _Username),
                new Claim(ClaimTypes.Name, _Password),
            };

            var _Identity = new ClaimsIdentity(_Claims, Scheme.Name);
            var _Principal = new ClaimsPrincipal(_Identity);
            var _Ticket = new AuthenticationTicket(_Principal, Scheme.Name);

            return AuthenticateResult.Success(_Ticket);
        }
    }
}
