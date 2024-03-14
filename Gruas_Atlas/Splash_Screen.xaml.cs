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
    public partial class Splash_Screen : ContentPage
    {
        public Splash_Screen()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            LoadApp();
        }

        async void LoadApp()
        {
            await Task.Delay(1500);
            await Navigation.PopAsync();
            await Navigation.PushAsync(new Index());
            Navigation.RemovePage(this);
            NavigationPage.SetHasNavigationBar(this, true);
        }
    }

}