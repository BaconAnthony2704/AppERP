using ConsolidaApp.Models;
using ConsolidaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ApiService apiService = new ApiService();
            var response= await apiService.GetToken(EntEmail.Text, EntPassword.Text);
            if (string.IsNullOrEmpty(response.access_token))
            {
                await DisplayAlert("Error","Algo salio mal","Ok");

            }
            else
            {
                Application.Current.MainPage = new MainPage();
                //await DisplayAlert("Encontro", response.token_type, "Ok");
            }

        }
    }
}