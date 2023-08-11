using Notes.Persistense.DatabaseContext;

namespace Notes.Persistense.DatabaseControls
{
    public class DbInitializer
    {
        public static void Initialize(NotesDbContext context) => 
            context.Database.EnsureCreated();
    }
}
