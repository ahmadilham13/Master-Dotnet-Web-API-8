namespace Coc.Entities;

public interface ISoftDelete
{
    public DateTime? DeletedAt { get; set; }
    protected internal bool ForceDeleted { get; set; }

    /// <summary>
    /// Set the entity to force delete.
    /// </summary>
    /// <param name="shouldDelete">True for force delete, False for soft delete.</param>
    internal void SetForceDelete(bool shouldDelete = true)
    {
        ForceDeleted = shouldDelete;
    }

    /// <summary>
    /// Check the entity will force delete on soft delete
    /// </summary>
    /// <returns>True if will force delete, False if will soft delete.</returns>
    public virtual bool IsForceDeleted()
    {
        return ForceDeleted;
    }
}
