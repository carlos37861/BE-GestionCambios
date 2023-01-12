using AutoMapper;
using GC.Core.Clases.DTO;
using GC.Core.Clases.ENTITIES;
using GC.Core.Helper;
using GC.Core.Repositories.Interface;
using GC.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Services.Implementation
{
    public class ProyectosService : IProyectosService
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ProyectosService()
        {
            uow = new UnitOfWork();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapeoGenerico>());
            mapper = config.CreateMapper();
        }

        public Task<ResponseModel> Delete(string V_IDPROYECTOS)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Insertar(GDTBC_PROYECTOS_DTO dto)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel = await uow.ProyectosRepository.Insertar(mapper.Map<GDTBC_PROYECTOS>(dto));
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

        public async Task<ResponseModel> Listar(string V_IDPROYECTOS)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (String.IsNullOrEmpty(V_IDPROYECTOS))
                {
                    V_IDPROYECTOS = "";
                }
                responseModel = await uow.ProyectosRepository.Listar(V_IDPROYECTOS);
            }
            catch (Exception ex)
            {
                responseModel.success = false;
                responseModel.errorMessage = ex.Message;
            }
            return responseModel;
        }

        public Task<ResponseModel> Update(GDTBC_PROYECTOS_DTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
