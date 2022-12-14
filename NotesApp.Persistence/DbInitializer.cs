using NotesApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Persistence
{
    public class DbInitializer
    {
        public void Initialize(NotesDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
