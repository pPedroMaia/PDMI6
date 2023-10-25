using TP03.VM;

namespace TP03;

public partial class MainPage : ContentPage
{
    public PacoteVM ViewModel { get; set; }

    public MainPage()
    {
        InitializeComponent();
        ViewModel = new PacoteVM();
        BindingContext = ViewModel;
    }

    private async void OnRastrearClicked(object sender, EventArgs e)
    {
        string codigoRastreamento = CodigoRastreamentoEntry.Text;
        await ViewModel.BuscarInformacoesPacoteAsync(codigoRastreamento);

        if (ViewModel.Pacote != null)
        {
            await Navigation.PushAsync(new Resultado { BindingContext = ViewModel });
        }
        else
        {
            CodigoRastreamentoEntry.Text = "";
        }
    }
}

