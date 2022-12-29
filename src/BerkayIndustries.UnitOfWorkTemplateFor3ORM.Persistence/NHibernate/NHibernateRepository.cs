using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application;
using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain;
using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Persistence.EfCore;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Persistence.NHibernate
{
    public class NhDbContext : IContextOfORM
    {
        private readonly ISession _session;

        public NhDbContext(ISession session)
        {
            _session = session;
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return new NhDbSet<TEntity>(_session);
        }
    }

    public class NhRepository<TEntity,TId> : IRepository<TEntity,TId> where TEntity : class, IFullEntityModel<TId>
    {
        private readonly ISession _session;

        public NhRepository(ISession session)
        {
            _session = session;
        }

        public override void Add(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(entity);
                transaction.Commit();
            }
        }

        public override TEntity GetById(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return _session.CreateCriteria<TEntity>().List<TEntity>();
        }

        public override void Update(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(entity);
                transaction.Commit();
            }
        }

        public override void Delete(TEntity entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(entity);
                transaction.Commit();
            }
        }


    }
}
