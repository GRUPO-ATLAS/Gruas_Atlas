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
	public partial class Prov_hospedaje : ContentPage
	{
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Gruas_Atlas.Modelo.regHospedaje> _post;
        private string idPvr;

        public Prov_hospedaje()
        {
            InitializeComponent();
        }
        public Prov_hospedaje(string idProve)
		{
			InitializeComponent ();
            idPvr = idProve;
            obtener(idPvr);
        }
        public async void obtener(string idProve)
        {
            var contenido = await client.GetStringAsync(GlobalVariables.urlHospedaje+"?idProve="+ idProve);
            List<Gruas_Atlas.Modelo.regHospedaje> listaPost = JsonConvert.DeserializeObject<List<Gruas_Atlas.Modelo.regHospedaje>>(contenido);
            _post = new ObservableCollection<Gruas_Atlas.Modelo.regHospedaje>(listaPost);
            ListaResultados.ItemsSource = _post;
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new Insertar_hospedaje(idPvr));
        }

        private void ListaResultados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objHospedaje = (Gruas_Atlas.Modelo.regHospedaje)e.SelectedItem;
            
            Navigation.PushAsync(new Act_Eli_Hospedaje(objHospedaje, idPvr));
        }

        private void btnatras_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}