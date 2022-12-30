using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core.Repositories.Conexion
{
    public abstract class Repository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        protected SqlCommand CreateCommand()
        {
            var command = _context.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }
    }
}
