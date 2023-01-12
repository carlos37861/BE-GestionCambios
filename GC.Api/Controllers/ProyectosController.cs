using GC.Core.Clases.DTO;
using GC.Core.Clases.ENTITIES;
using GC.Core.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : ControllerBase
    {
        IProyectosService _services;
        public ProyectosController(
            IProyectosService services)
        {
            _services = services;
        }

        [HttpGet]
        //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]

        [Route("Listar-proyectos")]
        public async Task<ActionResult> Listar(string V_IDPROYECTOS)
        {
            ResponseModel response = await _services.Listar(V_IDPROYECTOS);
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
        [Route("Insert-proyectos")]
        public async Task<ActionResult> Insert(GDTBC_PROYECTOS_DTO dto)
        {

            ResponseModel response = await _services.Insertar(dto);
            if (response.success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
