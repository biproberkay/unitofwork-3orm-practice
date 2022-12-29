using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application;
using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application.ORM;
using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Persistence.EfCore
{
    public class Repository<TEntity,TId> : IEfCoreRepository<TEntity, TId> where TEntity : class, IFullEntityModel<TId>
    {
        private readonly EfCoreDbContext _context;

        public Repository(EfCoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> DdbSet => _context.Set<TEntity>();

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DdbSet.ToList();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }

}
