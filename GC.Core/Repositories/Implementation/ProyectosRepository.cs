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

        public async Task<ResponseModel> Insertar(GDTBC_PROYECTOS ent)
        {
            ResponseModel response = new ResponseModel();
            using (var command = CreateCommand())
            {
                command.CommandText = "[GC].[GC_INSERT_GDTBC_PROYECTOS]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter sp;
                sp = command.Parameters.Add("@V_NOMBREPROYECTO", SqlDbType.VarChar);
                sp.Value = ent.V_NOMBREPROYECTO;
                sp = command.Parameters.Add("@V_DESCRIPPROYECTO", SqlDbType.VarChar);
                sp.Value = ent.V_DESCRIPPROYECTO;
                sp = command.Parameters.Add("@V_VERSION", SqlDbType.VarChar);
                sp.Value = ent.V_VERSION;
                sp = command.Parameters.Add("@V_USUREGISTRO", SqlDbType.VarChar);
                sp.Value = ent.V_USUREGISTRO;

                sp = command.Parameters.Add("@V_IDPROYECTOS", SqlDbType.VarChar);
                sp.Value = ent.V_IDPROYECTOS;
                sp.Direction = ParameterDirection.Output;
                sp.Size = 5;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    response.success = true;
                    ent.V_IDPROYECTOS = command.Parameters["@V_IDPROYECTOS"].Value.ToString();
                    response.result = ent;
                }
                return response;
            }
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
