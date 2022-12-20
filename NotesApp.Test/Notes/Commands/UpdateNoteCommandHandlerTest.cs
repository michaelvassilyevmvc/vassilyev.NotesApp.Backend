using NotesApp.Application.Notes.Commands.UpdateNote;
using NotesApp.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Common.Exceptions;

namespace NotesApp.Tests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTest: TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            //Arrange
            var handler = new UpdateNoteCommandHandler(Context);
            var updateTitle = "new title";

            //Act
            await handler.Handle(new UpdateNoteCommand
            {
                Id = NotesContextFactory.NoteIdForUpdate,
                UserId = NotesContextFactory.UserBId,
                Title = updateTitle
            }, CancellationToken.None);

            //Assert
            Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note => note.Id == NotesContextFactory.NoteIdForUpdate && note.Title == updateTitle));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOrWrongId()
        {
            //Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new UpdateNoteCommand 
            { Id = Guid.NewGuid(), UserId = NotesContextFactory.UserAId }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOrWrongUserId()
        {
            //Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            //Act

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(new UpdateNoteCommand
                {
                    Id = NotesContextFactory.NoteIdForUpdate,
                    UserId = NotesContextFactory.UserAId
                }, CancellationToken.None);
            });
        }
    }
}
