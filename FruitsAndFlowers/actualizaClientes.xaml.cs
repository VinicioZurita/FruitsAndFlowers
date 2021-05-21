using FruitsAndFlowers._WS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FruitsAndFlowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class actualizaClientes : ContentPage
    {
        private const string Url = "http://192.168.1.20/FruitsAndFlowers/post_clientes.php";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<_WS.ClientesDatos> _post;
       
        public actualizaClientes(string ced,string nom, string ape, string dir, string tel)
        {
            InitializeComponent();
            txtCedula.Text = ced;
            txtNombre.Text = nom;
            txtApellido.Text = ape;
            txtDireccion.Text = dir;
            txtTelefono.Text = tel;

        }

        private async void btnRegresarAct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Clientes());
        }

        private async void btnActCliente_Clicked(object sender, EventArgs e)
        {
            try
            {

                var parametro = new System.Collections.Specialized.NameValueCollection();
                parametro.Add("ced_cli", txtCedula.Text);
                parametro.Add("nom_cli", txtNombre.Text);
                parametro.Add("ape_cli", txtApellido.Text);
                parametro.Add("dir_cli", txtDireccion.Text);
                parametro.Add("cel_cli", txtTelefono.Text);


                StringContent content = new StringContent(JsonConvert.SerializeObject(parametro), Encoding.UTF8, "application/json");
              

                HttpResponseMessage response = await _client.PutAsync(Url, content);
                // 
                //_WS.ClientesDatos post = _post; //Assigning the first Post object of the Post Collection to a new instance of Post
                //post.ced_cli += " [ced_cli]"; //Appending an [updated] string to the current value of the Title property

                // string content = JsonConvert.SerializeObject(parametro); //Serializes or convert the created Post into a JSON String
                // await _client.PutAsync(Url + "/" + itemclic.ced_cli, new StringContent(content, Encoding.UTF8, "application/json")); //Send a PUT request to the specified Uri as an asynchronous operation.

                var mensaje = "Datos ingresados Exitosamente";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
               await Navigation.PushAsync(new Clientes());
            }
            catch (Exception ex)
            {
                //await DisplayAlert("Error", ex.Message, "Error" );
                DependencyService.Get<Mensaje>().ShortAlert("No se pudo actualizar");
            }
           
        }

    }
}