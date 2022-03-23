using api_personas_web.Infraestructura.Abstract;
using api_personas_web.Models.Persona.Input;
using api_personas_web.Models.Persona.Output;
using api_personas_web.Models.ResponsesCollection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace api_personas_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        #region
        private static readonly log4net.ILog _Logger = log4net.LogManager.GetLogger(typeof(Program));
        private readonly IPersonasRepository _IPersonasRepository;
        #endregion
        public PersonaController(IPersonasRepository ipersonasRepository)
        {
            _IPersonasRepository = ipersonasRepository;
        }


        [HttpPost("Agregar")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CollectionModel))]
        [Authorize]
        public async Task<ActionResult> AddUser(InputPersonaModel model)
        {
            ObjectResult _HttpResponse;

            try
            {
                var _Users = await _IPersonasRepository.AddUser(model);

                if ((bool)_Users.Where(x => x.Key == 1).FirstOrDefault().Value)
                {
                    var _User = _Users.Where(x => x.Key == 2).FirstOrDefault().Value;

                    // Armamos la respuesta
                    var _Data = new CollectionModel
                    {
                        Code = 1,
                        Message = null,//SharedResource.Success_Request,
                        Object = _User
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status200OK, _Data);
                }
                else
                {
                    var _Message = (string)_Users.Where(x => x.Key == 2).FirstOrDefault().Value;
                    var _Code = (int)_Users.Where(x => x.Key == 3).FirstOrDefault().Value;

                    var _Error = new CollectionModel
                    {
                        Code = Math.Abs(_Code) * -1,
                        Message = _Message,
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status400BadRequest, _Error);
                }
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                var _Error = new CollectionModel
                {
                    Code = -50000,
                    Message = StatusCodes.Status500InternalServerError.ToString(),
                };

                _HttpResponse = StatusCode(StatusCodes.Status500InternalServerError, _Error);
            }

            return _HttpResponse;
        }

        [HttpPut("Actualizar")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CollectionModel))]
        [Authorize]
        public async Task<ActionResult> UpdateUser(InputPersonaModel model)
        {
            ObjectResult _HttpResponse;

            try
            {
                var _DiccCards = await _IPersonasRepository.UpdateUser(model);

                if ((bool)_DiccCards.Where(x => x.Key == 1).FirstOrDefault().Value)
                {
                    var _Card = (List<OutputPersonaModel>)_DiccCards.Where(x => x.Key == 2).FirstOrDefault().Value;

                    // Armamos la respuesta
                    var _Data = new CollectionModel
                    {
                        Code = 1,
                        Message = null,//SharedResource.Success_Request,
                        Object = _Card
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status200OK, _Data);
                }
                else
                {
                    var _Message = (string)_DiccCards.Where(x => x.Key == 2).FirstOrDefault().Value;
                    var _Code = (int)_DiccCards.Where(x => x.Key == 3).FirstOrDefault().Value;

                    var _Error = new CollectionModel
                    {
                        Code = Math.Abs(_Code) * -1,
                        Message = _Message,
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status400BadRequest, _Error);
                }
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                var _Error = new CollectionModel
                {
                    Code = -50000,
                    Message = StatusCodes.Status500InternalServerError.ToString(),
                };

                _HttpResponse = StatusCode(StatusCodes.Status500InternalServerError, _Error);
            }

            return _HttpResponse;
        }

        [HttpDelete("Eliminar")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CollectionModel))]
        [Authorize]
        public async Task<ActionResult> DeleteUser(int IdPersonaFisica)
        {
            ObjectResult _HttpResponse;

            try
            {
                var _DiccCards = await _IPersonasRepository.DeleteUser(IdPersonaFisica);

                if ((bool)_DiccCards.Where(x => x.Key == 1).FirstOrDefault().Value)
                {
                    var _Card = (List<OutputPersonaModel>)_DiccCards.Where(x => x.Key == 2).FirstOrDefault().Value;

                    // Armamos la respuesta
                    var _Data = new CollectionModel
                    {
                        Code = 1,
                        Message = null,//SharedResource.Success_Request,
                        Object = _Card
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status200OK, _Data);
                }
                else
                {
                    var _Message = (string)_DiccCards.Where(x => x.Key == 2).FirstOrDefault().Value;
                    var _Code = (int)_DiccCards.Where(x => x.Key == 3).FirstOrDefault().Value;

                    var _Error = new CollectionModel
                    {
                        Code = Math.Abs(_Code) * -1,
                        Message = _Message,
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status400BadRequest, _Error);
                }
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                var _Error = new CollectionModel
                {
                    Code = -50000,
                    Message = StatusCodes.Status500InternalServerError.ToString(),
                };

                _HttpResponse = StatusCode(StatusCodes.Status500InternalServerError, _Error);
            }

            return _HttpResponse;
        }

        [HttpGet("Obtener")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CollectionModel))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CollectionModel))]
        [Authorize]
        public async Task<ActionResult> GetUsers()
        {
            ObjectResult _HttpResponse;

            try
            {
                var _Users = await _IPersonasRepository.GetUsers();

                if ((bool)_Users.Where(x => x.Key == 1).FirstOrDefault().Value)
                {
                    var _User = (List<OutputPersonaModel>)_Users.Where(x => x.Key == 2).FirstOrDefault().Value;

                    // Armamos la respuesta
                    var _Data = new CollectionModel
                    {
                        Code = 1,
                        Message = null,//SharedResource.Success_Request,
                        Object = _User
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status200OK, _Data);
                }
                else
                {
                    var _Message = (string)_Users.Where(x => x.Key == 2).FirstOrDefault().Value;
                    var _Code = (int)_Users.Where(x => x.Key == 3).FirstOrDefault().Value;

                    var _Error = new CollectionModel
                    {
                        Code = Math.Abs(_Code) * -1,
                        Message = _Message,
                    };

                    _HttpResponse = StatusCode(StatusCodes.Status400BadRequest, _Error);
                }
            }
            catch (Exception e)
            {
                _Logger.Error(e);

                var _Error = new CollectionModel
                {
                    Code = -50000,
                    Message = StatusCodes.Status500InternalServerError.ToString(),
                };

                _HttpResponse = StatusCode(StatusCodes.Status500InternalServerError, _Error);
            }

            return _HttpResponse;
        }
    }
}
