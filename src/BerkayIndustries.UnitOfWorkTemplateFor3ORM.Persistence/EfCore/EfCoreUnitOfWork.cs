using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Persistence.EfCore
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly EfCoreDbContext _context;
        private IDbTransaction? _dbTransaction;
#if false // this doesnt work because i cant write where clause
        #region Repository Fields
        private IRepository<TEntity, TId> Repository where
        #endregion
#else
        private Hashtable _repositories;
#endif

        public EfCoreUnitOfWork(EfCoreDbContext context)
        {
            _context = context;
            _repositories ??= new Hashtable();
        }

        public void BeginTransaction()
        {
            _dbTransaction = (IDbTransaction)_context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbTransaction?.Commit();
        }

        public void Rollback()
        {
            _dbTransaction?.Rollback();
        }

#if true
        IRepository<TEntity, TId> IUnitOfWork.SetRepository<TEntity, TId>()
        {
            _repositories ??= new Hashtable();
            if (_repositories.ContainsKey(nameof(TEntity)))
            {
                var repositoryType = typeof(Repository<,>).MakeGenericType(typeof(TEntity),typeof(TId));
                _repositories[nameof(TEntity)] = Activator.CreateInstance(repositoryType, _context);
            }
            return (IRepository<TEntity, TId>)_repositories[nameof(TEntity)];
        } 
#endif

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _dbTransaction?.Dispose();
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~EfCoreUnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
