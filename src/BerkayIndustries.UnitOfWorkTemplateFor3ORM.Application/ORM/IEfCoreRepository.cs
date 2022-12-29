using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application.ORM
{
    public interface IEfCoreRepository<TEntity,TId> : IRepository<TEntity, TId> where TEntity : class, IFullEntityModel<TId>
    {

    }
}
