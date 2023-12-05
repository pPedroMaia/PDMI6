using tpfinal.Modelos;

namespace tpfinal.Paginas;

public partial class Coordenadas : ContentPage
{
	private Localizacao localizacao;

	public Coordenadas()
	{
        InitializeComponent();
        loadlocalizacao();
    }

    private async Task<Localizacao> loadlocalizacao()
    {
        localizacao = new Localizacao();
        try
        {
            Location location = await Geolocation.Default.GetLastKnownLocationAsync();

            if (location != null)
            {
                localizacao.Longitude = location.Longitude.ToString();
                localizacao.Latitude = location.Latitude.ToString();
                localizacao.Altitude = location.Altitude.ToString();
            }
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            return localizacao;
        }
        catch (FeatureNotEnabledException fneEx)
        {
            return localizacao;
        }
        catch (PermissionException pEx)
        {
            return localizacao;
        }
        catch (Exception ex)
        {
            return localizacao;
        }

        this.OnAppearing();
        return localizacao;
    }

    protected override void OnAppearing()
    {
        BindingContext = localizacao;
        base.OnAppearing();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}