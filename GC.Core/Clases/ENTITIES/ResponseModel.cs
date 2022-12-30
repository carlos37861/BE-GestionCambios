using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Clases.ENTITIES
{
    public class ResponseModel
    {
#nullable disable
        public bool success { get; set; }
        public object result { get; set; }
        public string errorMessage { get; set; }
        public bool RepeatOption { get; set; }
        public string MethodToRepeat { get; set; }
    }
}
