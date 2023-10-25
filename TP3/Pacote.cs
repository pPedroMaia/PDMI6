using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP03.Model;

public class Pacote
{
    public string PacoteId { get; set; }
    public string Status { get; set; }
    public DateTime DataEnvio { get; set; }
    public DateTime DataPrevistaEntrega { get; set; }
    public List<string> HistoricoEventos { get; set; }
}