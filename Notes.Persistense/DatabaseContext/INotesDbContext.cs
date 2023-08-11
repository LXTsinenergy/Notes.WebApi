using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Persistense.DatabaseContext
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
