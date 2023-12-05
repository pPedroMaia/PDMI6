using Microsoft.EntityFrameworkCore;
using tpfinal.Modelos;
using SQLite;

namespace tpfinal.Repositorios
{
    public class LivroSQL : LivrosSQL
    {
        private LivroSQL()
        {

        }


        private static LivroSQL Instance;

        public static LivroSQL getInstance()
        {
            if (Instance == null)
            {
                Instance = new LivroSQL();
            }

            return Instance;
        }


        private SQLiteAsyncConnection _dbConnection;
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath =
                Path.Combine(FileSystem.Current.AppDataDirectory, "db_atividades.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Livro>();
            }
        }


        public async Task<List<Livro>> GetAll()
        {
            return await _dbConnection.Table<Livro>().ToListAsync();
        }

        public async Task<Livro> GetById(int id)
        {
            var livros = await _dbConnection.QueryAsync<Livro>($"Select * From {nameof(Livro)} where Id = {id} ");
            return livros.FirstOrDefault();
        }

        public async void Create(Livro livro)
        {
            await _dbConnection.InsertAsync(livro);
        }

        public async void Update(int id, Livro livro)
        {
            livro.Id = id;
            await _dbConnection.UpdateAsync(livro);
        }

        public async void Delete(int id)
        {
            var livro = await GetById(id);
            await _dbConnection.DeleteAsync(livro);
        }
    }
}
