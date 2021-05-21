using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FruitsAndFlowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class insertaClientes : ContentPage
    {
        public insertaClientes()
        {
            InitializeComponent();
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Clientes());
        }

        private async  void btnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("ced_cli", txtCedula.Text);
                parametro.Add("nom_cli", txtNombre.Text);
                parametro.Add("ape_cli", txtApellido.Text);
                parametro.Add("dir_cli", txtDireccion.Text);
                parametro.Add("cel_cli", txtTelefono.Text);


                cliente.UploadValues("http://192.168.1.20/FruitsAndFlowers/post_clientes.php", "POST", parametro);
                //await DisplayAlert("Alerta", "Ingreso Exitoso", "Ok");
                var mensaje = "Datos ingresados Exitosamente";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                // Limpiar textos
                txtCedula.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";

            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.Message, "Error" );
                DependencyService.Get<Mensaje>().ShortAlert("Error");
            }

        }
    }
}