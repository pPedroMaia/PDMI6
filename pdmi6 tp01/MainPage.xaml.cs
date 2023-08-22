using System;

namespace Mauitp01;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked1(object sender, EventArgs e)
    {
        try
        {
            if (LoginEnt.Text == "admin" && PasswordEnt.Text == "senha@dmin")
            {
                DisplayAlert("Login efetuado", "Acesso Liberado", "Avançar");
            }
            else
            {
                DisplayAlert("Login não efetuado", "Acesso Negado", "Retroceder");
            }
        }
        catch
        {
            DisplayAlert("!!!!!!!!", "ERRO", "Retornar");
        }
    }

    private void OnCounterClicked2(object sender, EventArgs e)
    {
        LoginEnt.Text = "";
        PasswordEnt.Text = "";
    }

    private void OnCounterClicked3(object sender, EventArgs e)
    {
        DisplayAlert("Créditos", "Pedro Henrique de Oliveira Maia dos Santos", "OK");
    }
}


