using ConsolidaApp.Models;
using ConsolidaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsolidaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            
        }

        public async void InicioSesion_Clicked(object sender, EventArgs e)
        {
            BusyIndicator.IsRunning = true;
            ApiService apiService = new ApiService();
            var response= await apiService.GetToken(EntEmail.Text, EntPassword.Text);
            if (string.IsNullOrEmpty(response.access_token))
            {
                BusyIndicator.IsRunning = false;
                await DisplayAlert("Error","No tiene acceso a esta cuenta","Ok");
            }
            else
            {
               
                Preferences.Set("useremail",EntEmail.Text);
                Preferences.Set("password", EntPassword.Text);
                Preferences.Set("accesstoken", response.access_token);
                Application.Current.MainPage = new MainPage();
                BusyIndicator.IsRunning = false;   
                
            }

        }


        private void Registrarme_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrarmePage());
        }

        private void TapForgotPassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}