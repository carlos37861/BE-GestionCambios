using GC.Core.Clases.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Repositories.Interface
{
    public interface IProyectosRepository
    {
        Task<ResponseModel> Listar(string V_IDPROYECTOS);
        Task<ResponseModel> Insertar(GDTBC_PROYECTOS ent);
        Task<ResponseModel> Update(GDTBC_PROYECTOS ent);
        Task<ResponseModel> Delete(string V_IDPROYECTOS);
    }
}
