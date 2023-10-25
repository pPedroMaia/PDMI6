using TP03.VM;

namespace TP03;

public partial class Resultado : ContentPage
{
    public Resultado()
    {
        BindingContext = new PacoteVM();
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}