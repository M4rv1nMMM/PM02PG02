using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM02PG02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.PersonasPage());
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listapersona = await App.BaseDatos.ObtenerListaPersonas();
            lspersonas.ItemsSource = listapersona;
           
        }

        private async void lspersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Personas item = (Models.Personas)e.Item;
            //await DisplayAlert("Elemento tocado ", "Correo:" + item.email, "OK");

            var page = new Views.UpdatePage();
            page.BindingContext = item;
            await Navigation.PushAsync(page);
        }
    }
}
