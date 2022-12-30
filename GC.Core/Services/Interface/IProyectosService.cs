using GC.Core.Clases.DTO;
using GC.Core.Clases.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Services.Interface
{
    public interface IProyectosService
    {
        Task<ResponseModel> Listar(string V_IDPROYECTOS);
        Task<ResponseModel> Insertar(GDTBC_PROYECTOS_DTO dto);
        Task<ResponseModel> Update(GDTBC_PROYECTOS_DTO dto);

        Task<ResponseModel> Delete(string V_IDPROYECTOS);
    }
}
