using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Persistence.EfCore
{
    public class EfCoreDbContext : DbContext
    {
        public EfCoreDbContext(DbContextOptions options) : base(options) 
        {
        }

    }

}
