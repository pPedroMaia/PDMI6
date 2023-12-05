using tpfinal.Modelos;
using tpfinal.Repositorios;

namespace tpfinal.Paginas;

public partial class DetalhesLivros : ContentPage
{
    private Livro currenteLivro;
    private readonly LivrosSQL livroSQL;
    public DetalhesLivros()
	{
		InitializeComponent();

        currenteLivro = livro;
        BindingContext = livro;

        livroSQL = LivroSQL.getInstance();
    }

    private async void OnEditarClick(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new EditPage(currenteLivro));
    }

    private async void OnExcluirClick(object sender, EventArgs e)
    {
        bool remove = await DisplayAlert("Excluir item",
                                        "Deseja realmente remover o item:\n" + currenteLivro.Nome,
                                        "Sim",
                                        "Não");

        if (currenteLivro != null && remove)
        {
            livroSQL.Delete(currenteLivro.Id);
        }

        await Navigation.PopAsync();
    }

    protected async override void OnAppearing()
    {
        currenteLivro = await livroSQL.GetById(currenteLivro.Id);
        BindingContext = currenteLivro;
        base.OnAppearing();
    }
}