using MauiAppHotel.Models;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public List<Quarto> lista_quartos { get; set; }

        public App()
        {
            InitializeComponent();

            // Cria a lista de quartos disponíveis
            lista_quartos = new List<Quarto>
            {
                new Quarto { Descricao = "Suíte Luxo", ValorDiariaAdulto = 250, ValorDiariaCrianca = 100 },
                new Quarto { Descricao = "Suíte Standard", ValorDiariaAdulto = 180, ValorDiariaCrianca = 80 },
                new Quarto { Descricao = "Suíte Econômica", ValorDiariaAdulto = 120, ValorDiariaCrianca = 50 }
            };

            // ✅ Agora o app usa o Shell, que mostra as abas
            MainPage = new AppShell();
        }
    }
}
