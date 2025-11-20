using Coc.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Coc.Helpers;

public class AutofillDateTimeInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        if (eventData.Context is null) return new ValueTask<InterceptionResult<int>>(result);

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is { State: EntityState.Modified, Entity: IBaseEntity update })
            {
                update.Updated = DateTime.UtcNow;
            }

            else if (entry is { State: EntityState.Deleted, Entity: ISoftDelete delete })
            {
                if (! delete.ForceDeleted)
                {
                    entry.State = EntityState.Modified;
                    delete.DeletedAt = DateTime.UtcNow;
                }
            }

            else if (entry is { State: EntityState.Added, Entity: IBaseEntity create })
            {
                create.Created = DateTime.UtcNow;
            }
        }

        return new ValueTask<InterceptionResult<int>>(result);
    }
}