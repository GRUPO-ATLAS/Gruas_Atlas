using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Npgsql;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Gruas_Atlas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registro : ContentPage
	{
        
        public Registro ()
		{
			InitializeComponent ();
            // Establecer la condicion del tipo de servicio
            pkTipoServicio.SelectedIndexChanged += pkTipoServicio_SelectedIndexChanged;

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
           
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
           

        }
       
        private void pkTipoServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selecionTipoServicio = pkTipoServicio.SelectedItem as string;

            alimentacionLayout.IsVisible = false;           
            hospedajeLayout.IsVisible = false;
            hospedajeAlimentacionLayout.IsVisible = false;

            switch (selecionTipoServicio)
            {
                case "Alimentación":
                    alimentacionLayout.IsVisible = true;
                    break;
                case "Hospedaje":
                    hospedajeLayout.IsVisible = true;
                    break;
                case "Hospedaje y Alimentación":
                    hospedajeAlimentacionLayout.IsVisible = true;
                    break;
            }switch (selecionTipoServicio)
            {
                case "Alimentación":
                    alimentacionLayout.IsVisible = true;
                    break;
                case "Hospedaje":
                    hospedajeLayout.IsVisible = true;
                    break;
                case "Hospedaje y Alimentación":
                    hospedajeAlimentacionLayout.IsVisible = true;
                    break;
            }

        }
    }
}