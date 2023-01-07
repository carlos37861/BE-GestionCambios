using Common.Core.Services;
using GC.Core.Clases.ENTITIES;
using GC.Core.Repositories.Conexion;
using GC.Core.Repositories.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Repositories.Implementation
{
    public class UsuariosRepository: Repository, IUsuariosRepository
    {
        private readonly IConfiguration _configuration;

        public UsuariosRepository(SqlConnection context, SqlTransaction transaction,IConfiguration configuration)
        {
            _context = context;
            _transaction = transaction;
            _configuration = configuration;
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
                command.CommandText = "[GC].[GC_INS_USUARIO]";
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
            GDTBC_USUARIOS user = new GDTBC_USUARIOS();
            ResponseModel response = new ResponseModel();
            using (var command = CreateCommand())
            {
                command.CommandText = "[GC].[GC_LST_USUARIO]";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter sp;
                sp = command.Parameters.Add("@V_USERNAME", SqlDbType.VarChar);
                sp.Value = V_USERNAME;
                using (var reader = await command.ExecuteReaderAsync())
                {

                    user = ReflectionService.ReaderToEntity<GDTBC_USUARIOS>(reader);
                    if(user != null)
                    {
                        if (!VerificarPasswordHash(PASSWORD, user.V_PASSWORDHASH, user.V_PASSWORDSALT))
                        {
                            response.success = false;
                        }
                        else
                        {
                            response.success = true;
                            response.result = CrearToken(user);
                            
                        }
                    }             
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
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
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

        private string CrearToken(GDTBC_USUARIOS user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.V_IDUSER.ToString()),
                new Claim(ClaimTypes.Name,user.V_USERNAME)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Pl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlos"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = System.DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
