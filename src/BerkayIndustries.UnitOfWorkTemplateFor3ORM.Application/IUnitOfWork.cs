using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

#if true // Repository varieties
        IRepository<TEntity,TId> SetRepository<TEntity,TId>() where TEntity : class, IFullEntityModel<TId>;
#elif false//what if i want to use as a readonly property?
        IRepository<TEntity,TId> Repository { get; }
        //it can not recognise the generic type definition. i need a where clause 
#endif

#if false // Asyncronous methods
        IAsyncRepository<T> GetAsyncRepository<T>() where T : class, IFullEntityModel;
#endif

#if false // for join tables
        IJoinRepository<T> GetJoinRepository<T>() where T : class, IJoin
#endif

#if false // for data manupulation - data query
        IQueryRepository<T> GetQueryRepository<T>() where T : class, IFullEntityModel<int>; 
        ICommandRepository<T> GetCommandRepository<T>() where T : class, IFullEntityModel<int>; 
#endif

#if false // bulk actions for only command operations
        IBulkRepository<T> GetBulkRepository<T>() where T : class, IFullEntityModel;
#endif

    }
}