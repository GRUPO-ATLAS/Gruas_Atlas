using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gruas_Atlas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Index : ContentPage
	{
		public Index ()
		{
			InitializeComponent ();  
            BackgroundImageSource = "fondo.png";
		}


        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}