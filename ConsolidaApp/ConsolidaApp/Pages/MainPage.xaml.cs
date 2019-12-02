using ConsolidaApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ConsolidaApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, false);
        }

        /*private async void Login_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
            IsPresented = false;
        }*/

        private void ChangePassword_Tapped(object sender, EventArgs e)
        {

            //Detail = new NavigationPage(new ForgotPasswordPage());
            //NavigationPage.SetHasNavigationBar(this, true);
            Navigation.PushAsync(new ForgotPasswordPage());
            IsPresented = false;
            
            
        }

        private void Seguimiento_Tapped(object sender, EventArgs e)
        {






            //Detail = new NavigationPage(new SeguimientoPage());
            Navigation.PushAsync(new SeguimientoPage());
            IsPresented = false;
            
                
            
        }

        private void Reportes_Tapped(object sender, EventArgs e)
        {

            //Detail = new NavigationPage(new ReportesPage());
            Navigation.PushAsync(new ReportesPage());
            IsPresented = false;
 
        }


        private void Salir_Tapped(object sender, EventArgs e)
        {

            Preferences.Set("useremail", string.Empty);
            Preferences.Set("password", string.Empty);
            Preferences.Set("accesstoken", string.Empty);
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private void Page_Inicio_Tapped(object sender, EventArgs e)
        {
            
                IsPresented = false;
           
        }
    }
}
