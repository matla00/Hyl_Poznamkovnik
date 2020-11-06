using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Hyl_Poznamkovnik.Model;

namespace Hyl_Poznamkovnik
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public NoteDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _database.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<List<Note>> GetNoteAsyncList(int id)
        {
            return _database.Table<Note>()
                            .Where(i => i.ID == id)
                            .ToListAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }
        public void EditNote(Note note)
        {
            _database.UpdateAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
