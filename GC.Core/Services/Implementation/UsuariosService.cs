using AutoMapper;
using GC.Core.Clases.DTO;
using GC.Core.Clases.ENTITIES;
using GC.Core.Helper;
using GC.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Services.Implementation
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UsuariosService()
        {
            uow = new UnitOfWork();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapeoGenerico>());
            mapper = config.CreateMapper();
        }

        public Task<ResponseModel> Delete(string V_IDPROYECTOS)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Insertar(GDTBC_USUARIOS_DTO dto, string password)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel = await uow.UsuariosRepository.Insertar(mapper.Map<GDTBC_USUARIOS>(dto),password);
                if (responseModel.success)
                {
                    uow.Commit();
                }
                else
                {
                    uow.Rollback();
                }
            }
            catch (Exception ex)
            {
                responseModel.success = false;
                responseModel.errorMessage = ex.Message;
                uow.Rollback();
            }
            return responseModel;
        }

        public async Task<ResponseModel> Login(string V_USERNAME, string PASSWORD)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel = await uow.UsuariosRepository.Login(V_USERNAME, PASSWORD);
                if (responseModel.success)
                {
                    uow.Commit();
                }
                else
                {
                    uow.Rollback();
                }
            }
            catch (Exception ex)
            {
                responseModel.success = false;
                responseModel.errorMessage = ex.Message;
                uow.Rollback();
            }
            return responseModel;
        }

        public Task<ResponseModel> Update(GDTBC_USUARIOS_DTO ent)
        {
            throw new NotImplementedException();
        }
    }
}
