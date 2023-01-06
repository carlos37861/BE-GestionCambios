using GC.Core.Clases.DTO;
using GC.Core.Clases.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Services.Interface
{
    public interface IUsuariosService
    {
        Task<ResponseModel> Listar(string V_IDPROYECTOS);
        Task<ResponseModel> Insertar(GDTBC_USUARIOS_DTO ent, string password);
        Task<ResponseModel> Update(GDTBC_USUARIOS_DTO ent);
        Task<ResponseModel> Delete(string V_IDPROYECTOS);
    }
}
