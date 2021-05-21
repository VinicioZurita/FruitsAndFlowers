using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FruitsAndFlowers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Clientes : ContentPage
    {
        private const string Url = "http://192.168.1.20/FruitsAndFlowers/post_clientes.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<FruitsAndFlowers._WS.ClientesDatos> _post;
     

        public Clientes()
        {
            InitializeComponent();
            _ = cargaClientes();
        }
        public async Task cargaClientes()
        {
            var content = await client.GetStringAsync(Url);
            List<FruitsAndFlowers._WS.ClientesDatos> posts = JsonConvert.DeserializeObject<List<FruitsAndFlowers._WS.ClientesDatos>>(content);
            _post = new ObservableCollection<FruitsAndFlowers._WS.ClientesDatos>(posts);
            listaClientesView.ItemsSource = _post;
        }

        private async void btnInsertaCliente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new insertaClientes());
        }

       

        private async void listaClientesView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemclic = ((ListView)sender).SelectedItem as _WS.ClientesDatos;
            // await DisplayAlert("Alerta", itemclic.ced_cli + " " + itemclic.nom_cli, "Ok");
            await Navigation.PushAsync(new actualizaClientes(itemclic.ced_cli, itemclic.nom_cli, itemclic.ape_cli, itemclic.dir_cli, itemclic.cel_cli));
        }
    }
}