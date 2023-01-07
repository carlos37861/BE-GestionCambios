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
        Task<ResponseModel> Login(string V_USERNAME, string PASSWORD);
        Task<ResponseModel> Insertar(GDTBC_USUARIOS_DTO ent, string password);
        Task<ResponseModel> Update(GDTBC_USUARIOS_DTO ent);
        Task<ResponseModel> Delete(string V_IDPROYECTOS);
    }
}
