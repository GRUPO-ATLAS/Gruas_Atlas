using Gruas_Atlas.Modelo;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gruas_Atlas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Act_Eli_Alimentacion : ContentPage
    {
        private string idPrv;
        private string idEml;
        MetodosV objetoV;
        public Act_Eli_Alimentacion(Modelo.regAlimentacion regAlimentacion, string idProve)
        {
            InitializeComponent();
            idPrv = idProve;
            objetoV = new MetodosV();
            txtId.Text = regAlimentacion.idAlim.ToString();
            txtCedulaEmpleado.Text = regAlimentacion.cedEmple.ToString();
            txtNombreEmpleado.Text = regAlimentacion.nombEmple.ToString();
            txtTipoAlimentacion.Text = regAlimentacion.tAlimen.ToString();
            txtFechaconsumo.Text = regAlimentacion.fecCon.ToString();
            txtValorC.Text = regAlimentacion.valorC.ToString();
            txtRubro.Text = regAlimentacion.rubro.ToString();
            txtObservacion.Text = regAlimentacion.obser.ToString();
            txtidProveedor.Text = regAlimentacion.idProve.ToString();
            idEml = regAlimentacion.idEmple.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                string idAlim = txtId.Text;
                string cedEmple = txtCedulaEmpleado.Text;
                string nomEmple = txtNombreEmpleado.Text;
                string fecCon = txtFechaconsumo.Text;
                string talim = txtTipoAlimentacion.Text;
                string valorC = txtValorC.Text;
                string rubro = txtRubro.Text;
                string obser = txtObservacion.Text;
                string idProve = idPrv;

                string url = $"{GlobalVariables.urlAlimentacion}?idAlim={idAlim}&cedEmple={cedEmple}&nombEmple={nomEmple}&tAlimen={talim}&fecCon={fecCon}&valorC={valorC}&rubro={rubro}&obser={obser}&idProve={idProve}&idEmple={idEml}";
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("idAlim", txtId.Text);
                parametros.Add("cedEmple", txtCedulaEmpleado.Text);
                parametros.Add("nombEmple", txtNombreEmpleado.Text);
                parametros.Add("tAlimen", txtTipoAlimentacion.Text);
                parametros.Add("fecCon", txtFechaconsumo.Text);
                parametros.Add("valorC", txtValorC.Text);
                parametros.Add("rubro", txtRubro.Text);
                parametros.Add("obser", txtObservacion.Text);
                parametros.Add("idProve", txtidProveedor.Text);
                parametros.Add("idEmple", txtidEmpleado.Text);
                cliente.UploadValues(url, "PUT", parametros);
                DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgDatosActualizadosExito, GlobalVariables.cerrar);
                Navigation.PushAsync(new Prov_alimentacion(idPrv));
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 3]);
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            } catch (Exception ex) {
                Console.Write(ex);
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
                Conf_Elimminar popup = new Conf_Elimminar();
                popup.OnClosed += Popup_OnClosedAlimentacion;
                PopupNavigation.Instance.PushAsync(popup);  
        }

        private void Popup_OnClosedAlimentacion(object sender, bool flag)
        {
            try
            {
                WebClient cliente = new WebClient();
                string idAlim = txtId.Text;
                string cedEmple = txtCedulaEmpleado.Text;
                string nomEmple = txtNombreEmpleado.Text;
                string fecCon = txtFechaconsumo.Text;
                string talim = txtTipoAlimentacion.Text;
                string valorC = txtValorC.Text;
                string rubro = txtRubro.Text;
                string obser = txtObservacion.Text;
                string idProve = idPrv;
                string idEmple = txtidEmpleado.Text;

                string url = $"{GlobalVariables.urlAlimentacion}?idAlim={idAlim}";
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("idAlim", txtId.Text);
                parametros.Add("cedEmple", txtCedulaEmpleado.Text);
                parametros.Add("nombEmple", txtNombreEmpleado.Text);
                parametros.Add("tAlimen", txtTipoAlimentacion.Text);
                parametros.Add("fecCon", txtFechaconsumo.Text);
                parametros.Add("valorC", txtValorC.Text);
                parametros.Add("rubro", txtRubro.Text);
                parametros.Add("obser", txtObservacion.Text);
                parametros.Add("idProve", txtidProveedor.Text);
                parametros.Add("idEmple", txtidEmpleado.Text);

                cliente.UploadValues(url, "DELETE", parametros);
                DisplayAlert(GlobalVariables.alerta, GlobalVariables.datos_eliminados, GlobalVariables.cerrar);
                Navigation.PushAsync(new Prov_alimentacion(idPrv));
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 3]);
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                
            }
            catch (Exception ex) {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
     }
}