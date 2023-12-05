using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpfinal.Modelos
{
    public class Livro
    {
        public Livro()
        {

        }
        public Livro(string nome, string autor, string email, string iSBN)
        {
            Nome = nome;
            Autor = autor;
            Email = email;
            ISBN = iSBN;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ISBN { get; set; }
    }
}
}
