using System;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QntAdultos { get; set; }
        public int QntCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadia => (int)(DataCheckOut - DataCheckIn).TotalDays;

        public double ValorTotal
        {
            get
            {
                if (QuartoSelecionado == null) return 0;
                return (QntAdultos * QuartoSelecionado.ValorDiariaAdulto +
                        QntCriancas * QuartoSelecionado.ValorDiariaCrianca) * Estadia;
            }
        }
    }
}
