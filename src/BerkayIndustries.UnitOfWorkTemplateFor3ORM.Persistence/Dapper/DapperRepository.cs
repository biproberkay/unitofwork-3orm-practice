using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Application;
using BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Persistence.Dapper
{
    public class DapperDbContext //: IDbContext
    {
        private readonly IDbConnection _connection;

        public DapperDbContext(IDbConnection connection)
        {
            _connection = connection;
        }

    }

    public class DapperRepository<TEntity,TId> : IRepository<TEntity,TId> where TEntity : class, IFullEntityModel<TId>
    {
        private readonly IDbConnection _connection;

        public DapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public override void Add(TEntity entity)
        {
            string sql = "INSERT INTO " + typeof(TEntity).Name + " (...)" + " VALUES (...)";
            _connection.Execute(sql, entity);
        }

        public override TEntity GetById(int id)
        {
            string sql = "SELECT * FROM " + typeof(TEntity).Name + " WHERE Id = @Id";
            return _connection.QuerySingle<TEntity>(sql, new { Id = id });
        }

        public override IEnumerable<TEntity> GetAll()
        {
            string sql = "SELECT * FROM " + typeof(TEntity).Name;
            return _connection.Query<TEntity>(sql);
        }

        public override void Update(TEntity entity)
        {
            string sql = "UPDATE " + typeof(TEntity).Name + " SET (...) WHERE Id = @Id";
            _connection.Execute(sql, entity);
        }

        public override void Delete(TEntity entity)
        {
            string sql = "DELETE FROM " + typeof(TEntity).Name + " WHERE Id = @Id";
            _connection.Execute(sql, entity);
        }
    }

}
