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
    public class UsuariosRepository: Repository, IUsuariosRepository
    {
        public UsuariosRepository(SqlConnection context, SqlTransaction transaction)
    {
        _context = context;
        _transaction = transaction;
    }

        public Task<ResponseModel> Delete(string V_IDPROYECTOS)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Insertar(GDTBC_USUARIOS ent,string password)
        {
            ResponseModel response = new ResponseModel();
            CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            ent.V_PASSWORDHASH = passwordHash;
            ent.V_PASSWORDSALT = passwordSalt;
            using (var command = CreateCommand())
            {
                command.CommandText = "[GC].[TZ_INS_USUARIO]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter sp;
                sp = command.Parameters.Add("@V_USERNAME", SqlDbType.VarChar);
                sp.Value = ent.V_USERNAME;
                sp = command.Parameters.Add("@V_PASSWORDHASH", SqlDbType.VarBinary);
                sp.Value = ent.V_PASSWORDHASH;
                sp = command.Parameters.Add("@V_PASSWORDSALT", SqlDbType.VarBinary);
                sp.Value = ent.V_PASSWORDSALT;
                sp = command.Parameters.Add("@V_IDUSER", SqlDbType.VarChar);
                sp.Value = ent.V_IDUSER;
                sp.Direction = ParameterDirection.Output;
                sp.Size = 5;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    response.success = true;
                    ent.V_IDUSER = command.Parameters["@V_IDUSER"].Value.ToString();
                    response.result = ent;
                }
                return response;
            }
        }

        public async Task<ResponseModel> Login(string V_USERNAME, string PASSWORD)
        {
            //var user=
            ResponseModel response = new ResponseModel();
            using (var command = CreateCommand())
            {
                command.CommandText = "[SIG].[SIG_LST_GDTBC_USUARIO]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter sp;
                sp = command.Parameters.Add("@V_USERNAME", SqlDbType.VarChar);
                sp.Value = V_USERNAME;
                sp = command.Parameters.Add("@PASSWORD", SqlDbType.Int);
                sp.Value = PASSWORD;
                using (var reader = await command.ExecuteReaderAsync())
                {
                    response.success = true;
                    response.result = ReflectionService.ReaderToList<GDTBC_USUARIOS>(reader);
                }
                return response;
            }
           
        }

        public Task<ResponseModel> Update(GDTBC_USUARIOS ent)
        {
            throw new NotImplementedException();
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.Key;
                passwordSalt = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
