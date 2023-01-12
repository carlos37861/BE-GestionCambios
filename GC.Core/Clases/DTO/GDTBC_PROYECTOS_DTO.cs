using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Clases.DTO
{
    public class GDTBC_PROYECTOS_DTO
    {
        #nullable disable
        public string V_IDPROYECTOS { get; set; }
        public string V_NOMBREPROYECTO { get; set; }
        public string V_DESCRIPPROYECTO { get; set; }
        public string V_VERSION { get; set; }
        public string S_ESTADO { get; set; }
        public DateTime D_FECREGISTRO { get; set; }
        public string V_USUREGISTRO { get; set; }
        public DateTime D_FECMODIFICA { get; set; }
        public string V_USUMODIFICA { get; set; }
    }
}
