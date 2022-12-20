using AutoMapper;
using NotesApp.Application.Common.Mappings;
using NotesApp.Application.Interfaces;
using NotesApp.Persistence;
using System;
using Xunit;

namespace NotesApp.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public NotesDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = NotesContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            NotesContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
