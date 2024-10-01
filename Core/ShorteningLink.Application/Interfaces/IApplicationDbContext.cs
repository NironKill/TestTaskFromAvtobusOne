using Microsoft.EntityFrameworkCore;
using ShorteningLink.Domain;

namespace ShorteningLink.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Link> Link { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
