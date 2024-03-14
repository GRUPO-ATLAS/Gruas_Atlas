using Gruas_Atlas.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gruas_Atlas.Modelo
{
    public class ServicioApi
    {
        private HttpClient cliente;

        public ServicioApi()
        {
            cliente = new HttpClient();
        }

        public async Task<login1> IniciarSesion(login1 usuario)
        {

            try
            {
                string json = JsonConvert.SerializeObject(usuario);
                HttpContent contenido = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage respuesta = await cliente.PostAsync(GlobalVariables.urlLogin, contenido);
                string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();

                if (respuesta.IsSuccessStatusCode)
                {
                    login1 respuestaApi = JsonConvert.DeserializeObject<login1>(contenidoRespuesta);
                    return respuestaApi;
                }
                else
                {
                    

                    return null;
                }
            }
            catch (Exception)
            {
                // Maneja las excepciones según tus necesidades
                return null;
            }
        }
    }
}
