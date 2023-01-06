using System;
using System.Collections.Generic;
using GC.Core.Clases.ENTITIES;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Repositories.Interface
{
    public interface IUsuariosRepository
    {
        Task<ResponseModel> Listar(string V_IDPROYECTOS);
        Task<ResponseModel> Insertar(GDTBC_USUARIOS ent,string password);
        Task<ResponseModel> Update(GDTBC_USUARIOS ent);
        Task<ResponseModel> Delete(string V_IDPROYECTOS);
    }
}
