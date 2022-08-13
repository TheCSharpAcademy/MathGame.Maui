using MathsGame.Models;
using SQLite;
using System;

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

            public void CreateTable()
        {
            try
            {
                conn = new SQLiteConnection(_dbPath);
                conn.CreateTable<Game>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void Add(Game game)
        {
            conn = new SQLiteConnection(_dbPath);
            conn.Insert(game);
        }

        public List<Game> GetAllGames()
        {
            try
            {
                CreateTable();
                return conn.Table<Game>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new List<Game>();
        }
    }
}