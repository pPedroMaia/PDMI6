using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP03.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TP03.VM;

public class PacoteVM : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private List<Pacote> _pacotes;
    private Pacote _pacote;

    public List<Pacote> Pacotes
    {
        get { return _pacotes; }
        set
        {
            _pacotes = value;
            OnPropertyChanged();
        }
    }

    public Pacote Pacote
    {
        get { return _pacote; }
        set
        {
            _pacote = value;
            OnPropertyChanged();
        }
    }

    public PacoteVM()
    {
        _pacotes = new List<Pacote>
            {
                new Pacote
                {
                    PacoteId = "687238",
                    Status = "Entregue",
                    DataEnvio = DateTime.Now.AddDays(-7),
                    DataPrevistaEntrega = DateTime.Now,
                    HistoricoEventos = new List<string>
                    {
                        "Pedido confirmado.",
                        "Pacote enviado ao centro de distribuição",
                        "Pacote em trânsito para o destino.",
                        "Pacote já entregue ao destinatario."
                    }
                },
                new Pacote
                {
                    PacoteId = "902898",
                    Status = "Em trânsito",
                    DataEnvio = DateTime.Now.AddDays(-2),
                    DataPrevistaEntrega = DateTime.Now.AddDays(5),
                    HistoricoEventos = new List<string>
                    {
                        "Pedido confirmado",
                        "Pacote enviado ao centro de distribuição",
                        "Pacote em trânsito para o destido"
                    }
                },
                new Pacote
                {
                    PacoteId = "411331",
                    Status = "Pedido Confirmado",
                    DataEnvio = DateTime.Now,
                    DataPrevistaEntrega = DateTime.Now.AddDays(7),
                    HistoricoEventos = new List<string>
                    {
                        "Pedido Confirmado",
                    }
                },
            };
    }

    public async Task BuscarInformacoesPacoteAsync(string codigoRastreamento)
    {
        var pacoteEncontrado = _pacotes.FirstOrDefault(p => p.PacoteId == codigoRastreamento);

        if (pacoteEncontrado != null)
        {
            Pacote = pacoteEncontrado;
        }
        else
        {
            Pacote = null;
            await Application.Current.MainPage.DisplayAlert("Pacote não encontrado", "Verifique o código digitado e tente novamente.", "Ok");
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}