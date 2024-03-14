using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace Gruas_Atlas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Conf_Elimminar : PopupPage
    {
        public event EventHandler<bool> OnClosed;
        public Conf_Elimminar()
		{
			InitializeComponent ();
            BindingContext = this;
        }
        private void btnCompararID(object sender, EventArgs e)
        {
            bool flag = true;
            OnClosed?.Invoke(this, flag);
            PopupNavigation.Instance.PopAsync();
        }
        private void btnClosePopup(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}