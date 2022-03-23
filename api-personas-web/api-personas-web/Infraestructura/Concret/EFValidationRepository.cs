using api_personas_web.Infraestructura.Abstract;
using api_personas_web.Helpers;
using api_personas_web.Models.Errors.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiTokainternacionalupf.Infraestructura.Concret
{
    public class EFValidationRepository : IValidationRepository
    {
        #region Propiedades
        readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected Regex NameRegex;
        protected Regex PasswordRegex;
        protected Regex CardNumberRegex;
        protected Regex ProxyNumberRegex;
        protected Regex MCCRegex;
        protected Regex RubroRegex;
        protected Regex DateRegex;
        protected Regex PINRegex;
        protected Regex CVVRegex;
        protected Regex AmountRegex;
        protected Regex EmisorRegex;
        protected Regex CardExpirationRegex;
        protected Regex EstadoRegex;
        protected Regex PhoneRegex;
        protected Regex IdUsuarioRegex;
        #endregion

        public EFValidationRepository()
        {
            NameRegex = new Regex(@"^([a-zA-ZÀ-ÿ\u00f1\u00d1]){10,15}");
            PasswordRegex = new Regex(@"^([a-zA-ZÀ-ÿ\u00f1\u00d1]+([a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+){10,20}");

            CardNumberRegex = new Regex(@"^([\d]{16})");
            ProxyNumberRegex = new Regex(@"^([\d]{10,11})");
            PhoneRegex = new Regex(@"^([\d]{10})");
            MCCRegex = new Regex(@"^([\d]{1,2})");
            RubroRegex = new Regex(@"^([\d]{4})");
            DateRegex = new Regex(@"^([\d]{2}[\-][\d]{2}[\-][\d]{4})");
            PINRegex = new Regex(@"^([\d]{4})");
            CVVRegex = new Regex(@"^([\d]{3,4})");
            AmountRegex = new Regex(@"^[0-9]+([.][0-9]{1,2})?$");
            EmisorRegex = new Regex(@"^([\d]{1})");
            CardExpirationRegex = new Regex(@"^[\d]{2}[\/][\d]{4}");
            EstadoRegex = new Regex(@"^([\d]{2,2})");
            IdUsuarioRegex = new Regex(@"^([\d])");
        }
    }
}
