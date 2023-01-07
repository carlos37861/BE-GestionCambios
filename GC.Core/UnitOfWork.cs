using GC.Core.Repositories.Implementation;
using GC.Core.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;
        private bool _disposed;

        #region Repositories
        public IProyectosRepository ProyectosRepository { get; }
        public IUsuariosRepository UsuariosRepository { get; }

        #endregion
        public UnitOfWork()
        {
            #region Conexion            
            //_connection = new SqlConnection("Data Source=172.16.0.216\\SISTEMAS; Initial Catalog=BDGESDOC;Persist Security Info = True; User ID=usrSIG ; Password=3YpFULAhzYyb2swq2HBc;");
            //_connection = new SqlConnection("Data Source=LMSIS07\\SQLEXPRESS; Initial Catalog=BDGESTORCAMBIOS;Persist Security Info = True; User ID=sa ; Password=123;");
            _connection = new SqlConnection("Data Source=DESKTOP-Q7699NO\\SQLEXPRESS; Initial Catalog=BDGESTORCAMBIOS;Persist Security Info = True; User ID=sa ; Password=123;");

            _connection.Open();
            _transaction = _connection.BeginTransaction();

            #endregion

            #region Repositorios

            ProyectosRepository = new ProyectosRepository(_connection, _transaction);
            UsuariosRepository = new UsuariosRepository(_connection, _transaction);

            #endregion
        }

        public void Commit()
        {
            _transaction.Commit();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            dispose(true);
            System.GC.SuppressFinalize(this);
        }
        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                    }
                    if (_connection != null)
                    {
                        _connection.Close();
                        _connection.Dispose();

                    }
                }
                _disposed = true;
            }
        }

    }
}
