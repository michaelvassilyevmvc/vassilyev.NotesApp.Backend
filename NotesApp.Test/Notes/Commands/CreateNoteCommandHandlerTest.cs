﻿using Microsoft.EntityFrameworkCore;
using NotesApp.Application.Notes.Commands.CreateNote;
using NotesApp.Tests.Common;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NotesApp.Tests.Notes.Commands
{
    public class CreateNoteCommandHandlerTest : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateNoteCommandHandler(Context);
            var noteName = "note name";
            var noteDetails = "note details";

            //Act 
            var noteId = await handler.Handle(
                new CreateNoteCommand
                {
                    Title = noteName,
                    Details = noteDetails,
                    UserId = NotesContextFactory.UserAId
                },
                CancellationToken.None);


            //Assert
            Assert.NotNull(
                await Context.Notes.SingleOrDefaultAsync(note => note.Id == noteId && note.Title == noteName && note.Details == noteDetails));
        }
    }
}
