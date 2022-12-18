using FluentValidation;
using System;

namespace NotesApp.Application.Notes.Queries.GetNoteList
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(note => note.UserId).NotEqual(Guid.Empty);
        }
    }
}
