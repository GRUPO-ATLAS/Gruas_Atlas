using Gruas_Atlas.Modelo;
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
    public partial class Insertar_alimentacion : ContentPage
    {
        string idPrvd;
        MetodosV objetoV;
        public Insertar_alimentacion()
        {
            InitializeComponent();
        }
        public Insertar_alimentacion(string idPrv)
        {
            InitializeComponent();
            idPrvd = idPrv;
            objetoV = new MetodosV();
            txtidProveedores.Text = idPrvd;
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            try {
                WebClient cliente = new WebClient();
                if (objetoV.validarCampos(txtCedulaEmpleado.Text, txtNombreEmpleado.Text,
                    txtValor.Text, picker_alimentacion.SelectedItem.ToString()))
                {
                    if (objetoV.validarCedula(txtCedulaEmpleado.Text, GlobalVariables.patronCedula))
                    {
                        var parametros = new System.Collections.Specialized.NameValueCollection();

                        parametros.Add("idAlim", txtid.Text);
                        parametros.Add("cedEmple", txtCedulaEmpleado.Text);
                        parametros.Add("nombEmple", txtNombreEmpleado.Text);
                        parametros.Add("tAlimen", picker_alimentacion.SelectedItem.ToString());
                        parametros.Add("fecCon", txtFechaconsumo.Date.ToString(GlobalVariables.formatoFecha));
                        parametros.Add("valorC", txtValor.Text);
                        parametros.Add("rubro", txtRubro.Text);
                        parametros.Add("obser", txtObservacion.Text);
                        parametros.Add("idProve", idPrvd);
                        parametros.Add("idEmple", txtidEmpleado.Text);

                        byte[] respuesta = cliente.UploadValues(GlobalVariables.urlAlimentacion, "POST", parametros);
                        string respuestaString = Encoding.UTF8.GetString(respuesta);

                        if (respuestaString.Equals("\"Ok\""))
                        {
                            await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgRegConsumoExito, GlobalVariables.cerrar);
                            await Navigation.PushAsync(new Prov_alimentacion(idPrvd));
                        }
                        else
                        {
                            await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgRegConsumoError, GlobalVariables.cerrar);
                        }   

                    }
                    else
                    {
                        await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgCedulaError, GlobalVariables.cerrar);
                    }
                }
                else
                {
                    await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgCamposVacios, GlobalVariables.cerrar);
                }
                } catch (Exception ex) {
                Console.Write(ex);
                await DisplayAlert(GlobalVariables.alerta, GlobalVariables.msgRegConsumoError, GlobalVariables.cerrar);
            }
        }
    }
}