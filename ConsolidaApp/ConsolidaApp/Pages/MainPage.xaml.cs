using ConsolidaApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private async void ChangePassword_Tapped(object sender, EventArgs e)
        {
            
                await Navigation.PushAsync(new ChangePasswordPage());
                IsPresented = false;
            
            
        }

        private async void Seguimiento_Tapped(object sender, EventArgs e)
        {
            
                await Navigation.PushAsync(new SeguimientoPage());
                IsPresented = false;
            
                
            
        }

        private async void Reportes_Tapped(object sender, EventArgs e)
        {
            
                await Navigation.PushAsync(new ReportesPage());
                IsPresented = false;
            
                
        }


        async void Salir_Tapped(object sender, EventArgs e)
        {

            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
            IsPresented = false;
            
        }

        private void Page_Inicio_Tapped(object sender, EventArgs e)
        {
            
                IsPresented = false;
           
        }
    }
}
