using AutoMapper;
using GC.Core.Clases.DTO;
using GC.Core.Clases.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Helper
{
    internal class MapeoGenerico : Profile
    {
        public MapeoGenerico()
        {
            #region "GDTBC_PROYECTOS"            
            CreateMap<GDTBC_PROYECTOS, GDTBC_PROYECTOS_DTO>();
            CreateMap<GDTBC_PROYECTOS_DTO, GDTBC_PROYECTOS>();

            #endregion
        }
    }
}
