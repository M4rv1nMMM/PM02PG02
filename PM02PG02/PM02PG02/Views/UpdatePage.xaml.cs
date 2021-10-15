using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02PG02.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public UpdatePage()
        {
            InitializeComponent();
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            var personas = new Models.Personas
            {
                codigo = Convert.ToInt32(this.txtid.Text),
                nombre = this.txtnomb.Text,
                apellido = this.txtapellido.Text,
                edad = Convert.ToInt32(this.txtedad.Text),
                direccion = txtdireccion.Text,
                email = txtcorreo.Text
            };
            if (await App.BaseDatos.GrabarPersona(personas) != 0)
            {
                await DisplayAlert("Dato Actualizado", "Dato a sido actualizado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Dato no a sido actualizado", "OK");
            }
        }

        private async void btneliminar_Clicked(object sender, EventArgs e)
        {
            var personas = new Models.Personas
            {
                codigo = Convert.ToInt32(this.txtid.Text),
                nombre = this.txtnomb.Text,
                apellido = this.txtapellido.Text,
                edad = Convert.ToInt32(this.txtedad.Text),
                direccion = txtdireccion.Text,
                email = txtcorreo.Text
            };
            if (await App.BaseDatos.EliminarPersona(personas) != 0)
            {
                await DisplayAlert("Dato Eliminado", "Dato a sido eliminado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Dato no a sido eliminado", "OK");
            }
        }
    }
}