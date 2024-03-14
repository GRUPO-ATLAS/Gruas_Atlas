using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Gruas_Atlas.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Cuando se ejecuta fuera de lo archivos de la carpeta android*/
[assembly: Xamarin.Forms.Dependency(typeof(mensajeAndroid))]

namespace Gruas_Atlas.Droid
{
    public class mensajeAndroid
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void SortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}