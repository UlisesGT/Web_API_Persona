using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_personas_web.Helpers
{
    public static class FechaHelper
    {
        #region Propiedades
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(typeof(Program));
        #endregion

        public static string Parse(string fecha)
        {
            try
            {
                var _Fecha = fecha.Split("-");

                // string _Data = _Fecha[2] + "-" + _Fecha[0] + "-" + _Fecha[1];
                string _Data = _Fecha[2] + "-" + _Fecha[1] + "-" + _Fecha[0];

                return _Data;
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                return "0000-00-00";
            }
        }
    }
}
