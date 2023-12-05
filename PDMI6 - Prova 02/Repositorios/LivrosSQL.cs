using Microsoft.EntityFrameworkCore;
using tpfinal.Modelos;
using SQLite;


namespace tpfinal.Repositorios
{
    public interface LivrosSQL
    {
        Task InitializeAsync();
        Task<List<Livro>> GetAll();
        Task<Livro> GetById(int id);
        void Create(Livro livro);
        void Update(int id, Livro livro);
        void Delete(int id);
    }
}
