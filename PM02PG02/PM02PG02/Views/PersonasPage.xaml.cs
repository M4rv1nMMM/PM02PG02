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
    public partial class PersonasPage : ContentPage
    {
        public PersonasPage()
        {
            InitializeComponent();
        }

        private async void btnenviar_Clicked(object sender, EventArgs e)
        {
            // var personas = (Models.Personas)BindingContext;

            try
            {
                var personas = new Models.Personas
                {
                    nombre = this.txtnomb.Text,
                    apellido = this.txtapellido.Text,
                    edad = Convert.ToInt32(this.txtedad.Text),
                    direccion = txtdireccion.Text,
                    email = txtcorreo.Text
                };

                var resultado = await App.BaseDatos.GrabarPersona(personas);

                if (resultado == 1)
                {
                    await DisplayAlert("Agregado", "Ingresado Exitosamente", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo grabar persona", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

           
        }

        private void ClearScreen()
        {
            this.txtnomb.Text = String.Empty;
            this.txtapellido.Text = String.Empty;
            this.txtedad.Text = String.Empty;
            this.txtdireccion.Text = String.Empty;
            this.txtcorreo.Text = String.Empty;
        }
    }
}