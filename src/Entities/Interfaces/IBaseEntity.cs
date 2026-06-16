namespace Api.Entities;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}
