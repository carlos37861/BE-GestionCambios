using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Clases.ENTITIES
{
    public class GDTBC_USUARIOS
    {
#nullable disable
        public string V_IDUSER { get; set; }
        public string V_USERNAME { get; set; }
        public byte[] V_PASSWORDHASH { get; set; }
        public byte[] V_PASSWORDSALT { get; set; }
    }
}
