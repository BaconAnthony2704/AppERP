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
        Validaciones validaciones = new Validaciones();
        public LoginPage()
        {
            
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
        }

        public async void InicioSesion_Clicked(object sender, EventArgs e)
        {
            try
            {
                BusyIndicator.IsRunning = true;
                ApiService apiService = new ApiService();

                if (!validaciones.verificarCampo(EntEmail.Text.Trim()))
                {
                    await DisplayAlert("Advertencia", "Debe agregar un correo electronico", "Entendido");
                    BusyIndicator.IsRunning = false;
                }
                else if (!validaciones.verificarCampo(EntPassword.Text.Trim()))
                {
                    await DisplayAlert("Advertencia", "Debe agregar una contraseña", "Entendido");
                    BusyIndicator.IsRunning = false;
                }
                if (validaciones.verificarCorreo(EntEmail.Text.Trim()))
                {
                    var response = await apiService.GetToken(EntEmail.Text.Trim(), EntPassword.Text.Trim());
                    if (string.IsNullOrEmpty(response.access_token))
                    {
                        BusyIndicator.IsRunning = false;
                        await DisplayAlert("Advertencia", "No tiene acceso a esta cuenta", "Entendido");
                    }
                    else
                    {
                        BusyIndicator.IsRunning = false;
                        Preferences.Set("useremail", EntEmail.Text.Trim());
                        Preferences.Set("password", EntPassword.Text.Trim());
                        Preferences.Set("accesstoken", response.access_token);
                        Application.Current.MainPage = new MainPage();

                    }

                }
                else
                {
                    await DisplayAlert("Advertencia", "Debe ser un correo electronico", "Entendido");
                }
            }
            catch (NullReferenceException)
            {
                await DisplayAlert("Advertencia", "Debe agregar un correo electronico", "Entendido");
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