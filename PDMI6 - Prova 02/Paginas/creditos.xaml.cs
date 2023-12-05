namespace tpfinal.Paginas;

public partial class Creditos : ContentPage
{
	public Creditos()
	{
		InitializeComponent();
	}

    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}