using MathGame.Maui.Models;
using SQLite;

namespace MathGame.Maui.Data
{
    public class GameRepository
    {
        string _dbPath;
        private SQLiteConnection conn;

        public GameRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Game>();
        }

        public List<Game> GetAllGames()
        {
            Init();
            return conn.Table<Game>().ToList();
        }

        public void Add(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(game);
        }

        public void Delete(int id)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Delete(new Game { Id = id });
        }
    }
}
