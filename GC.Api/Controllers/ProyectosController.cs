using GC.Core.Clases.ENTITIES;
using GC.Core.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProyectosController : ControllerBase
    {
        IProyectosService _services;
        public ProyectosController(
            IProyectosService services)
        {
            _services = services;
        }

        [HttpGet]
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
    }
}
