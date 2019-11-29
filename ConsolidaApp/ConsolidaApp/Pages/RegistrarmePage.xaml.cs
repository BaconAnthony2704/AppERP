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
    public partial class RegistrarmePage : ContentPage
    {
        public RegistrarmePage()
        {
            InitializeComponent();
        }

        private async void BtnRegistrarme_Clicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            if (EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                bool response = await apiService.RegisterUser(EntEmail.Text, EntPassword.Text);
                if (!response)
                {
                    await DisplayAlert("Oops", "No se pudo crear su cuenta", "Cancelar");
                }
                else
                {
                    await DisplayAlert("Exito", "Tu cuenta ha sido creada", "OK");
                    await Navigation.PopToRootAsync();
                }
            }

        }
    }
}