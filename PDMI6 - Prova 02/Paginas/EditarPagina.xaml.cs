using tpfinal.Modelos;
using tpfinal.Repositorios;


namespace tpfinal.Paginas;

public partial class EditarPagina : ContentPage
{
    private Livro currenteLivro;
    private readonly LivrosSQL livroSQL;
    public EditarPagina()
	{
		InitializeComponent();


        currenteLivro = livro;
        BindingContext = livro;

        livroSQL = LivroSQL.getInstance();
    }

    private async void onEdit(object sender, EventArgs e)
    {
        livroSQL.Update(currenteLivro.Id, currenteLivro);
        await Navigation.PopModalAsync();
    }

    private async void onCancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();

    }
}