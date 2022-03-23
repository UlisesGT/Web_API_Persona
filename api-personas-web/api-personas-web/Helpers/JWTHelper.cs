using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace api_personas_web.Helpers
{
    public static class JWTHelper
    {
        #region Propiedades
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(typeof(Program));
        #endregion

        #region Genera un token
        public static string GenerarTokenJWT(string username, string idusuario, bool biometrico)
        {
            try
            {
                // Obtenemos el archivo de configuración
                IConfigurationBuilder _ConfigurationBuilder = new ConfigurationBuilder();
                _ConfigurationBuilder.AddJsonFile("AppSettings.json");
                IConfiguration _Configuration = _ConfigurationBuilder.Build();

                // Creamos el header
                var _symmetricSecurityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_Configuration["JWT:ClaveSecreta"])
                    );
                var _signingCredentials = new SigningCredentials(
                        _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                    );
                var _Header = new JwtHeader(_signingCredentials);

                // Creamos los claims
                var _Claims = new[] {
                    new Claim("username", username),
                    new Claim("id", idusuario.ToString())
                };

                // Creamos el payload
                var _Payload = new JwtPayload(
                    issuer: _Configuration["JWT:Issuer"],
                    audience: _Configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: biometrico ? DateTime.UtcNow.AddYears(1) : DateTime.UtcNow.AddMinutes(Convert.ToInt32(_Configuration["JWT:Expires"]))
                );

                // Generamos el token
                var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

                return new JwtSecurityTokenHandler().WriteToken(_Token);
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                return null;
            }
        }
        #endregion

        #region Genera un token de forma temporal
        public static string GenerarTokenTemporalJWT(string numeroTelefono)
        {
            try
            {
                // Obtenemos el archivo de configuración
                IConfigurationBuilder _ConfigurationBuilder = new ConfigurationBuilder();
                _ConfigurationBuilder.AddJsonFile("AppSettings.json");
                IConfiguration _Configuration = _ConfigurationBuilder.Build();

                // Creamos el header
                var _symmetricSecurityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_Configuration["JWT:ClaveSecreta"])
                    );
                var _signingCredentials = new SigningCredentials(
                        _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                    );
                var _Header = new JwtHeader(_signingCredentials);

                // Creamos los claims
                var _Claims = new[] {
                    new Claim("numeroTelefono", numeroTelefono),
                };

                // Creamos el payload
                var _Payload = new JwtPayload(
                    issuer: _Configuration["JWT:Issuer"],
                    audience: _Configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_Configuration["JWT:Expires"]))
                );

                // Generamos el token
                var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

                return new JwtSecurityTokenHandler().WriteToken(_Token);
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                return null;
            }
        }
        #endregion

        #region Validamos la firma de un token
        public static bool ValidarFirma(string token)
        {
            bool _Resp = false;

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                _Resp = true;
            }
            catch (Exception e)
            {
                _Logger.Error(e);
            }

            return _Resp;
        }
        #endregion

        private static TokenValidationParameters GetValidationParameters()
        {
            // Obtenemos el archivo de configuración
            IConfigurationBuilder _ConfigurationBuilder = new ConfigurationBuilder();
            _ConfigurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration _Configuration = _ConfigurationBuilder.Build();

            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = _Configuration["JWT:Issuer"],
                ValidAudience = _Configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:ClaveSecreta"])) // The same key as the one that generate the token
            };
        }
    }
}
