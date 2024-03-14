using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gruas_Atlas
{
    public partial class App : Application
    {
        public static FlyoutPage MasterDet {  get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Splash_Screen());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
