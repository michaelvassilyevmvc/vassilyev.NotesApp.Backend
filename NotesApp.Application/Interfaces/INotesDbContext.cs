using Microsoft.EntityFrameworkCore;
using NotesApp.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace NotesApp.Application.Interfaces
{
    public interface INotesDbContext
    {
        public DbSet<Note> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
