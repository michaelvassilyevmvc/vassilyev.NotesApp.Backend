using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Common.Exceptions;
using NotesApp.Application.Interfaces;
using NotesApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotesApp.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);
            if(entity == null || entity.UserId != request.UserId) {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Title = request.Title;
            entity.Details = request.Details;
            entity.EditDate = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
