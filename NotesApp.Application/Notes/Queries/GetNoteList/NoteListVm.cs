using System.Collections.Generic;

namespace NotesApp.Application.Notes.Queries.GetNoteList
{
    public class NoteListVm
    {
        public IList<NoteLookupDto> Notes { get; set; }
    }
}
