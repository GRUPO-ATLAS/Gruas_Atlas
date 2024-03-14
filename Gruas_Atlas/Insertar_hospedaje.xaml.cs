using Gruas_Atlas.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace Gruas_Atlas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Insertar_hospedaje : ContentPage
	{
        private string idPrv;
        MetodosV objetoV;
        public Insertar_hospedaje(string idProve)
        {
            InitializeComponent();
            objetoV = new MetodosV();
            idPrv = idProve;
            txtidProveedores.Text = idPrv;
        }
        public Insertar_hospedaje ()
		{
			InitializeComponent ();
		}

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                if (objetoV.validarCampos(txtCedulaEmpleado.Text,txtNombreEmpleado.Text,
                    txtDiasHospedaje.Text,txtValor.Text)) 
                { 
                if (objetoV.validarCedula(txtCedulaEmpleado.Text, GlobalVariables.patronCedula)) 
                    {

                    var parametros = new System.Collections.Specialized.NameValueCollection();

                    parametros.Add("idHosp", txtid.Text);
                    parametros.Add("cedEmple", txtCedulaEmpleado.Text);
                    parametros.Add("nomEmple", txtNombreEmpleado.Text);
                    parametros.Add("fecIn", txtFechaIngreso.Date.ToString(GlobalVariables.formatoFecha));
                    parametros.Add("fecSa", txtFechaSalida.Date.ToString(GlobalVariables.formatoFecha));
                    parametros.Add("diasH", txtDiasHospedaje.Text);
                    parametros.Add("valorC", txtValor.Text);
                    parametros.Add("rubro", txtRubro.Text);
                    parametros.Add("obser", txtObservacion.Text);
                    parametros.Add("idProve", idPrv);
                    parametros.Add("idEmple", txtidEmpleado.Text);

                    byte[] respuesta = cliente.UploadValues(GlobalVariables.urlHospedaje, "POST", parametros);
                    string respuestaString = Encoding.UTF8.GetString(respuesta);

                    if (respuestaString.Equals("\"Ok\""))
                    {
                        await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgRegConsumoExito, GlobalVariables.cerrar);
                        await Navigation.PushAsync(new Prov_hospedaje(idPrv));
                    }
                    else
                    {
                        await DisplayAlert(GlobalVariables.alerta,GlobalVariables.msgRegConsumoError, GlobalVariables.cerrar);
                    }
                }
                else
                {
                    await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgCedulaError, GlobalVariables.cerrar);
                }
                }
                else {
                    await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgCamposVacios, GlobalVariables.cerrar);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgRegConsumoError, GlobalVariables.cerrar);
            }
        }
    }
}