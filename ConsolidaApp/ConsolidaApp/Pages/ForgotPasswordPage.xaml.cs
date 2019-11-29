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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            bool response=await apiService.PasswordRecovery(EntEmail.Text.Trim());
            if (!response)
            {
                await DisplayAlert("Oops", "A ocurrido un error, intente de nuevo", "Cancel");

            }
            else
            {
                await DisplayAlert("Exito", "Se le ha enviado un correo a: "+EntEmail.Text, "OK");
                await Navigation.PopToRootAsync();
            }
        }
    }
}