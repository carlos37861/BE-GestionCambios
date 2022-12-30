using Common.Core.Services;
using GC.Core.Clases.ENTITIES;
using GC.Core.Repositories.Conexion;
using GC.Core.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Repositories.Implementation
{
    public class ProyectosRepository : Repository, IProyectosRepository
    {
        public ProyectosRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public Task<ResponseModel> Delete(string V_IDPROYECTOS)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insertar(GDTBC_PROYECTOS ent)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Listar(string V_IDPROYECTOS)
        {
            ResponseModel response = new ResponseModel();
            using (var command = CreateCommand())
            {
                command.CommandText = "[GC].[GC_LST_GDTBC_PROYECTOS]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter sp;
                sp = command.Parameters.Add("@V_IDPROYECTOS", SqlDbType.VarChar);
                sp.Value = V_IDPROYECTOS;

                using (var reader = await command.ExecuteReaderAsync())
                {
                    response.success = true;
                    response.result = ReflectionService.ReaderToList<GDTBC_PROYECTOS>(reader);
                }
                return response;
            } 
        }

        public Task<ResponseModel> Update(GDTBC_PROYECTOS ent)
        {
            throw new NotImplementedException();
        }
    }
}
