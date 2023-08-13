using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistense.DatabaseContext;

namespace Notes.Tests.Common
{
    public class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("CA51C236-7A93-4980-AFEF-C120A4CEFA1C"),
                    Title = "Title1",
                    UserId = UserAId,
                },
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("A54A5007-45B2-4130-9069-8176CDD1630B"),
                    Title = "Title2",
                    UserId = UserBId,
                },
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    EditDate = null,
                    Id = Guid.Parse("F2C0539F-1203-4E25-9F48-42DD2F33AD06"),
                    Title = "Title3",
                    UserId = UserAId,
                },
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    EditDate = null,
                    Id = Guid.Parse("A83C46E9-FAA2-45E3-91CB-797C61D487CA"),
                    Title = "Title4",
                    UserId = UserAId,
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
