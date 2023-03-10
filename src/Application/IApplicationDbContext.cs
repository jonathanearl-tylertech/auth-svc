using Microsoft.EntityFrameworkCore;

namespace AuthService.Application;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
