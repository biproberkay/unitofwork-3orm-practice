using System.Security.Cryptography;

namespace BerkayIndustries.UnitOfWorkTemplateFor3ORM.Domain
{
    public interface IFullEntityModel : IFullEntityModel<int>
    {
        //TODO: navigation properties of an entity
    }
    /// <summary>
    /// default Type of Id is int
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IFullEntityModel<TId> : IReadDto<TId>
    {
        //TODO: navigation properties of an entity
    }

    /// <summary>
    /// if a class has an identity it is exists. if not... it doesn't exist.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IExistance<TId>
    {
        TId Id { get; set; }
    }

    /// <summary>
    /// This marker interface indicates that the model is intended for use in a database insert operation. It includes the properties that will be needed when adding the entity to the database as part of a transaction process.
    /// </summary>
    public interface ICreation
    {
        //TODO: main characteristic properties of the entity
    }

    /// <summary>
    /// it is a class that holding an existing entity's data which can be editable.
    /// it includes the properties defined before when it had been created
    /// </summary>
    public interface IModification<TId> : IExistance<TId>, ICreation
    {
        //TODO: 
    }
    /// <summary>
    /// this class is also contains the audit characteristics because it could be shown to client.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public interface IReadDto<TId> : IModification<TId>, IAudit
    {
        //TODO: 
    }
    public interface IRequestModel
    {
        //TODO: minimum needed data for acting the demanded action 
    }
    public interface IResponseModel
    {
        //TODO: the properties responded as a data collection after a data operation ended
    }

}