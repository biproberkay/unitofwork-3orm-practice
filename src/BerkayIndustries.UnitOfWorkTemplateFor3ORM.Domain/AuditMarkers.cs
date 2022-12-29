using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain
{
public interface IDeletionAudit
    {
        bool Deleted { get; set; }
        string? DeletedBy { get; set; }
        DateTime? DeletedOn { get; set; }
    }
    public interface ICreationAudit
    {
        string CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
    }
    public interface IModificationAudit
    {
        string? EditedBy { get; set; }
        DateTime? EditedOn { get; set; }
    }
    public interface IAudit : IDeletionAudit,ICreationAudit,IModificationAudit
    {
    }

}
