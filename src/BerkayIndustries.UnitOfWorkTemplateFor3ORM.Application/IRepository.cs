using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application
{
    /// <summary>
    /// This is just a marker interface now
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IRepository<TEntity,TId> where TEntity : class, IFullEntityModel<TId>
    {
    }
}
