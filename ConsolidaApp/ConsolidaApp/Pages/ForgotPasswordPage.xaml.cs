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
    public partial class ForgotPasswordPage : ContentPage
    {
        Validaciones validaciones = new Validaciones();
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ApiService apiService = new ApiService();
                if (validaciones.verificarCorreo(EntEmail.Text.Trim()))
                {
                    bool response = await apiService.PasswordRecovery(EntEmail.Text.Trim());
                    if (!response)
                    {
                        await DisplayAlert("Advertencia", "No se podido verificar, intente de nuevo", "Cancelar");

                    }
                    else
                    {
                        await DisplayAlert("Exito", "Se le ha enviado un correo a: " + EntEmail.Text, "Aceptar");
                        await Navigation.PopToRootAsync();
                    }
                }
                else
                {
                    await DisplayAlert("Advertencia", "Debe ser correo electrinico", "Aceptar");
                    EntEmail.Text = "";
                }
            }
            catch (NullReferenceException)
            {
                await DisplayAlert("Advertencia", "Debe ingresar un correo electronico", "Entendido");
            }
        }
    }
}