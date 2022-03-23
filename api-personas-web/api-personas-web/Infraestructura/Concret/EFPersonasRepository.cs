using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_personas_web.Entities;
using api_personas_web.Infraestructura.Abstract;
using api_personas_web.Models.Errors.Output;
using api_personas_web.Models.Persona.Input;
using api_personas_web.Models.Persona.Output;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace api_personas_web.Infraestructura.Concret
{
    public class EFPersonasRepository : IPersonasRepository
    {
        #region Propiedades
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(typeof(Program));
        private readonly DBContext _Context;
        #endregion
        public EFPersonasRepository(DBContext dBContext)
        {
            _Context = dBContext;
        }

        public async Task<Dictionary<int, object>> GetUsers()
        {
            Dictionary<int, object> _y = new Dictionary<int, object>();
            var _Users = new List<OutputPersonaModel>();

            try
            {
                // Validamos el código generico
                _y = await Task.Run(async () =>
                {
                    var _tmp = new Dictionary<int, object>();
                    // Obtenemos el nombre de embozado y compañia

                    var _Dicc = _Context.sp_ObtenerPersonaFisica.FromSqlRaw(
                        $"sp_ObtenerPersonaFisica"
                    ).ToList();

                    if (_Dicc.Count > 0)
                    {
                        _Dicc.Reverse();

                        foreach(var _U in _Dicc)
                        {
                            // Modelo de respuesta
                            var _RespTemp = new OutputPersonaModel
                            {
                                IdPersonaFisica = _U.IdPersonaFisica,
                                FechaRegistro = _U.FechaRegistro,
                                FechaActualizacion = _U.FechaActualizacion,
                                Nombre = _U.Nombre,
                                ApellidoPaterno = _U.ApellidoPaterno,
                                ApellidoMaterno = _U.ApellidoMaterno,
                                RFC = _U.RFC,
                                FechaNacimiento = _U.FechaNacimiento,
                                UsuarioAgrega = _U.UsuarioAgrega
                            };

                            _Users.Add(_RespTemp);
                        }
                        

                        _tmp.Add(1, true);
                        _tmp.Add(2, _Users);
                    }
                    else
                    {
                        _tmp.Add(1, false);
                        _tmp.Add(2, "No hay personas registradas");
                        _tmp.Add(3, -1);
                    }

                    return _tmp;
                });
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                _y = new Dictionary<int, object>{
                    { 1, false },
                    { 2, null }, //SharedResource.Excepcion_No_Controlada },
                    { 3, 50000 }
                };
            }

            return _y;
        }

        public async Task<Dictionary<int, object>> AddUser(InputPersonaModel model)
        {
            Dictionary<int, object> _y = new Dictionary<int, object>();

            try
            {
                _y = await Task.Run(async () =>
                {
                    var _tmp = new Dictionary<int, object>();

                    var _Dicc = _Context.sp_AgregarPersonaFisica.FromSqlRaw(
                        $"sp_AgregarPersonaFisica @Nombre,@ApellidoPaterno,@ApellidoMaterno,@RFC,@FechaNacimiento,@UsuarioAgrega",
                        new SqlParameter("@Nombre", model.Nombre),
                        new SqlParameter("@ApellidoPaterno", model.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno", model.ApellidoMaterno),
                        new SqlParameter("@RFC", model.RFC),
                        new SqlParameter("@FechaNacimiento", model.FechaNacimiento),
                        new SqlParameter("@UsuarioAgrega", model.UsuarioAgrega)
                    ).ToList();

                    var _Resp = new ErrorModel
                    {
                        IdError = _Dicc.FirstOrDefault().ERROR,
                        Status = _Dicc.FirstOrDefault().MENSAJEERROR
                    };

                    _tmp.Add(1, true);
                    _tmp.Add(2, _Resp);

                    return _tmp;
                });
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                _y = new Dictionary<int, object>{
                    { 1, false },
                    { 2, null },//SharedResource.Excepcion_No_Controlada },
                    { 3, 50000 }
                };
            }

            return _y;
        }

        public async Task<Dictionary<int, object>> DeleteUser(int idUser)
        {
            Dictionary<int, object> _y = new Dictionary<int, object>();

            try
            {
                _y = await Task.Run(async () =>
                {
                    var _tmp = new Dictionary<int, object>();

                    var _Dicc = _Context.sp_EliminarPersonaFisica.FromSqlRaw(
                        $"sp_EliminarPersonaFisica @IdPersonaFisica",
                        new SqlParameter("@IdPersonaFisica", idUser)
                    ).ToList();

                    // Modelo de respuesta
                    var _Resp = new ErrorModel
                    {
                        IdError = _Dicc.FirstOrDefault().ERROR,
                        Status = _Dicc.FirstOrDefault().MENSAJEERROR
                    };

                    _tmp.Add(1, true);
                    _tmp.Add(2, _Resp);

                    return _tmp;
                });
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                _y = new Dictionary<int, object>{
                    { 1, false },
                    { 2, null },//SharedResource.Excepcion_No_Controlada },
                    { 3, 50000 }
                };
            }

            return _y;
        }

        public async Task<Dictionary<int, object>> UpdateUser(InputPersonaModel model)
        {
            Dictionary<int, object> _y = new Dictionary<int, object>();

            try
            {
                _y = await Task.Run(async () =>
                {
                    var _tmp = new Dictionary<int, object>();

                    var _Dicc = _Context.sp_ActualizarPersonaFisica.FromSqlRaw(
                        $"sp_AgregarPersonaFisica @IdPersonaFisica,@Nombre,@ApellidoPaterno,@ApellidoMaterno,@RFC,@FechaNacimiento,@UsuarioAgrega",
                        new SqlParameter("@IdPersonaFisica", model.IdPersonaFisica),
                        new SqlParameter("@Nombre", model.Nombre),
                        new SqlParameter("@ApellidoPaterno", model.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno", model.ApellidoMaterno),
                        new SqlParameter("@RFC", model.RFC),
                        new SqlParameter("@FechaNacimiento", model.FechaNacimiento),
                        new SqlParameter("@UsuarioAgrega", model.UsuarioAgrega)
                    ).ToList();

                    var _Resp = new ErrorModel
                    {
                        IdError = _Dicc.FirstOrDefault().ERROR,
                        Status = _Dicc.FirstOrDefault().MENSAJEERROR
                    };

                    _tmp.Add(1, true);
                    _tmp.Add(2, _Resp);

                    return _tmp;
                });
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                _y = new Dictionary<int, object>{
                    { 1, false },
                    { 2, null },//SharedResource.Excepcion_No_Controlada },
                    { 3, 50000 }
                };
            }

            return _y;
        }
    }
}
