using GC.Core.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Agregar Interface de reposistorios ejemplo:
        IProyectosRepository ProyectosRepository { get; }
        IUsuariosRepository UsuariosRepository { get; }

        void Commit();
        void Rollback();

    }
}
