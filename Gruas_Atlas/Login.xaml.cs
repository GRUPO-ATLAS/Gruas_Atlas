using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Gruas_Atlas.Modelo;


namespace Gruas_Atlas
{
	
	public partial class Login : ContentPage
	{
        private ServicioApi servicioApi;
        public Login ()
		{
			InitializeComponent ();
            servicioApi = new ServicioApi();

        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            login1 log = new login1
            {
                usuario = txtUsuario.Text,
                contrasena = txtContraseña.Text,
            };


            login1 respuesta = await servicioApi.IniciarSesion(log);

            if (respuesta != null && respuesta.Exito)
            {
                // El inicio de sesión fue exitoso
                await DisplayAlert( GlobalVariables.msgInicioCorrecto, GlobalVariables.bienvenido, GlobalVariables.aceptar);

                // Redirigir a diferentes páginas según el rol
                switch (respuesta.rol)
                {
                    case GlobalVariables.supervisor:
                        await Navigation.PushAsync(new supervisor());
                        break;
                    case GlobalVariables.hospedaje:
                        await Navigation.PushAsync(new Prov_hospedaje(respuesta.idProve));
                        break;
                    case GlobalVariables.alimentacion:
                        await Navigation.PushAsync(new Prov_alimentacion(respuesta.idProve));
                        break;
                    case GlobalVariables.hospedaje_alimentacion:
                        await Navigation.PushAsync(new provHospAlime());
                        break;
                    default:
                        await DisplayAlert(GlobalVariables.error, GlobalVariables.msgRolError, GlobalVariables.aceptar);
                        break;
                }
            }
            else
            {
                // El inicio de sesión falló
                await DisplayAlert(GlobalVariables.msgIncioError, GlobalVariables.msgCredError, GlobalVariables.aceptar);
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
