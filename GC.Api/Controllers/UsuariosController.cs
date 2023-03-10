using GC.Core.Clases.DTO;
using GC.Core.Clases.ENTITIES;
using GC.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuariosService _services;
        public UsuariosController(
            IUsuariosService services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("Insertar-usuario")]
        public async Task<ActionResult> Insertar(GDTBC_USUARIOS_DTO dto)
        {
            ResponseModel response = await _services.Insertar(dto,dto.V_PASSWORD);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(GDTBC_USUARIOS_DTO dto)
        {
            ResponseModel response = await _services.Login(dto.V_USERNAME, dto.V_PASSWORD);
            if (response.success)
            {
                response.successMessage = "Usuario y password correcto";
                return Ok(response);
            }
            else
            {
                response.errorMessage = "Usuario o contraseña erronea";
                return BadRequest(response);
            }
        }
    }
}
