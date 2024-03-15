using Gruas_Atlas.Modelo;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gruas_Atlas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Act_Eli_Hospedaje : ContentPage
    {
        private string idPrv;
        private string idEml;
        MetodosV objetoV;
        public Act_Eli_Hospedaje (Modelo.regHospedaje regHospedaje, string idProve)
		{
			InitializeComponent ();
            idPrv = idProve;
            objetoV = new MetodosV();
            txtId.Text = regHospedaje.idHosp.ToString();
			txtCedulaEmpleado.Text = regHospedaje.cedEmple.ToString();
			txtNombreEmpleado.Text = regHospedaje.nomEmple.ToString();
            txtFechaIngreso.Text = regHospedaje.fecIn.ToString();
            txtFechaSalida.Text = regHospedaje.fecSa.ToString();
            txtDiasH.Text = regHospedaje.diasH.ToString();
			txtValorC.Text = regHospedaje.valorC.ToString();
            txtRubro.Text = regHospedaje.rubro.ToString();
			txtObservacion.Text = regHospedaje.obser.ToString();
			txtidProveedor.Text = regHospedaje.idProve.ToString();
            idEml = regHospedaje.idEmple.ToString();

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try {
                WebClient cliente = new WebClient();
                string idHosp = txtId.Text;
                string cedEmple = txtCedulaEmpleado.Text;
                string nomEmple = txtNombreEmpleado.Text;
                string fecIn = txtFechaIngreso.Text;
                string fecSa = txtFechaSalida.Text;
                string diasH = txtDiasH.Text;
                string valorC = txtValorC.Text;
                string rubro = txtRubro.Text;
                string obser = txtObservacion.Text;
                string idProve = idPrv;

                string url = $"{GlobalVariables.urlHospedaje}?idHosp={idHosp}&cedEmple={cedEmple}&nomEmple={nomEmple}&fecIn={fecIn}&fecSa={fecSa}&diasH={diasH}&valorC={valorC}&rubro={rubro}&obser={obser}&idProve={idProve}&idEmple={idEml}";

                var parametros = new System.Collections.Specialized.NameValueCollection();

                    parametros.Add("idHosp", txtId.Text);
                    parametros.Add("cedEmple", txtCedulaEmpleado.Text);
                    parametros.Add("nomEmple", txtNombreEmpleado.Text);
                    parametros.Add("fecIn", txtFechaIngreso.Text);
                    parametros.Add("fecSa", txtFechaSalida.Text);
                    parametros.Add("diasH", txtDiasH.Text);
                    parametros.Add("valorC", txtValorC.Text);
                    parametros.Add("rubro", txtRubro.Text);
                    parametros.Add("obser", txtObservacion.Text);
                    parametros.Add("idProve", txtidProveedor.Text);
                    parametros.Add("idEmple", txtidEmpleado.Text);
                    cliente.UploadValues(url, "PUT", parametros);
                    DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgDatosActualizadosExito, GlobalVariables.cerrar);
                    Navigation.PushAsync(new Prov_hospedaje(idPrv));
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 3]);
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            catch(Exception ex) {
                Console.Write(ex);
            }
                
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            Conf_Elimminar popup = new Conf_Elimminar();
            popup.OnClosed += Popup_OnClosedHospedaje;
            PopupNavigation.Instance.PushAsync(popup);
            
        }

        private void Popup_OnClosedHospedaje(object sender, bool flag)
        {
            try
            {
                WebClient cliente = new WebClient();
                string idHosp = txtId.Text;
                string cedEmple = txtCedulaEmpleado.Text;
                string nomEmple = txtNombreEmpleado.Text;
                string fecIn = txtFechaIngreso.Text;
                string fecSa = txtFechaSalida.Text;
                string diasH = txtDiasH.Text;
                string valorC = txtValorC.Text;
                string rubro = txtRubro.Text;
                string obser = txtObservacion.Text;
                string idProve = txtidProveedor.Text;
                string idEmple = txtidEmpleado.Text;

                string url = $"{GlobalVariables.urlHospedaje}?idHosp={idHosp}";
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("idHosp", txtId.Text);
                parametros.Add("cedEmple", txtCedulaEmpleado.Text);
                parametros.Add("nomEmple", txtNombreEmpleado.Text);
                parametros.Add("fecIn", txtFechaIngreso.Text);
                parametros.Add("fecSa", txtFechaSalida.Text);
                parametros.Add("diasH", txtDiasH.Text);
                parametros.Add("valorC", txtValorC.Text);
                parametros.Add("rubro", txtValorC.Text);
                parametros.Add("obser", txtObservacion.Text);
                parametros.Add("idProve", txtidProveedor.Text);
                parametros.Add("idEmple", txtidEmpleado.Text);

                cliente.UploadValues(url, "DELETE", parametros);
                DisplayAlert(GlobalVariables.alerta, GlobalVariables.datos_eliminados, GlobalVariables.cerrar);
                Navigation.PushAsync(new Prov_hospedaje(idPrv));
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 3]);
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}