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
using static System.Net.WebRequestMethods;

namespace Gruas_Atlas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Prov_alimentacion : ContentPage
	{
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Gruas_Atlas.Modelo.regAlimentacion> _post;
        private string idPrv;

        public Prov_alimentacion()
        {
            InitializeComponent();
        }
        public Prov_alimentacion(String idProve)
        {
            InitializeComponent();
            idPrv = idProve;
            obtener(idPrv);
        }
        public async void obtener(string idProve)
        {
            var contenido = await client.GetStringAsync(GlobalVariables.urlAlimentacion + "?idProve=" + idProve);
            List<Gruas_Atlas.Modelo.regAlimentacion> listaPost = JsonConvert.DeserializeObject<List<Gruas_Atlas.Modelo.regAlimentacion>>(contenido);
            _post = new ObservableCollection<Gruas_Atlas.Modelo.regAlimentacion>(listaPost);
            ListaResultadosA.ItemsSource = _post;
        }

        private void ListaResultadosA_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objAlimentacion = (Gruas_Atlas.Modelo.regAlimentacion)e.SelectedItem;
            Navigation.PushAsync(new Act_Eli_Alimentacion(objAlimentacion, idPrv));
        }

        private void btn_cerrar_sesion(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btn_insertar_alimentacion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar_alimentacion(idPrv));
        }
    }
}