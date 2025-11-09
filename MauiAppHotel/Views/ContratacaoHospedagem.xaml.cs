using System;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        App PropriedadesApp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();
            PropriedadesApp = (App)Application.Current;
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

            // Corrija o ItemDisplayBinding para garantir que o Picker use o tipo correto
            pck_quarto.ItemDisplayBinding = new Binding("Descricao");

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(1);

            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(6);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pck_quarto.SelectedItem == null)
                {
                    await DisplayAlert("Atenção", "Selecione uma acomodação.", "OK");
                    return;
                }

                // Faça o cast explicitamente para MauiAppHotel.Models.Quarto
                var hospedagem = new Hospedagem
                {
                    QuartoSelecionado = (MauiAppHotel.Models.Quarto)pck_quarto.SelectedItem,
                    QntAdultos = (int)stp_adultos.Value,
                    QntCriancas = (int)stp_criancas.Value,
                    DataCheckIn = dtpck_checkin.Date,
                    DataCheckOut = dtpck_checkout.Date
                };

                await Navigation.PushAsync(new HospedagemContratada
                {
                    BindingContext = hospedagem
                });
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            dtpck_checkout.MinimumDate = e.NewDate.AddDays(1);
            dtpck_checkout.MaximumDate = e.NewDate.AddMonths(6);
        }
    }
}
