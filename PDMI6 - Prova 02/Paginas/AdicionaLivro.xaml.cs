using tpfinal.Modelos;
using tpfinal.Repositorios;

namespace tpfinal.Paginas;

public partial class AdicionaLivro : ContentPage
{
    private readonly LivrosSQL livroSQL;

    public AdicionaLivro()
    {
        InitializeComponent();
        this.livroSQL = livroSQL.getInstance();
    }

    private async void onAdd(object sender, EventArgs e)
    {
        var livro = currentLivro();

        if (livro != null)
        {
            livroSQL.Create(livro);
            await Navigation.PopModalAsync();
        }
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }

    private Livro currentLivro()
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text) ||
            string.IsNullOrWhiteSpace(txtAutor.Text) ||
            string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtISBN.Text))
        {
            DisplayAlert("", "Preencha todos os campos!", "Ok");
            return null;
        }

        return new Livro(txtNome.Text, txtAutor.Text, txtEmail.Text, txtISBN.Text);
    }
}