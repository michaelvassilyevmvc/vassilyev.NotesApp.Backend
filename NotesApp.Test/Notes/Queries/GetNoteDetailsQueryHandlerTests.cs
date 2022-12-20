using AutoMapper;
using NotesApp.Application.Notes.Queries.GetNoteDetails;
using NotesApp.Persistence;
using NotesApp.Tests.Common;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NotesApp.Tests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteDetailsQueryHandlerTests
    {
        private readonly NotesDbContext Context;
        private readonly IMapper Mapper;
        public GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteDetailsQueryHandler_Success()
        {
            //Arrange 
            var handler = new GetNoteDetailsQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetNoteDetailsQuery
                {
                    UserId = NotesContextFactory.UserBId,
                    Id = Guid.Parse("1C7F8BB3-DC91-40EB-93FC-F0A9B3ADA30C")
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<NoteDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
