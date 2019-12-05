using ConsolidaApp.Models;
using ConsolidaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web2.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsolidaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExistenciaPage : ContentPage

    {
        ObservableCollection<ClientesViewModels> clientes;
        Validaciones validaciones = new Validaciones();
        string number,email;
        public ExistenciaPage()
        {
            InitializeComponent();
            clientes = new ObservableCollection<ClientesViewModels>();

        }
        
        protected async override void OnAppearing()
        {
            clientes.Clear();
            base.OnAppearing();
            var codigo=Preferences.Get("codigo", "");
            try
            {
                ApiService apiService = new ApiService();
                if (codigo != null)
                {
                    var cliente = await apiService.GetClientes(codigo);
                    foreach (var cli in cliente)
                    {
                        clientes.Add(cli);
                        number = cli.Telefono;
                        email = cli.Email;

                    }
                    LvExist.ItemsSource = clientes;
                    

                }
                else
                {
                    await DisplayAlert("status", "Seleccione el cliente", "salir");
                }
            }
            catch (HttpRequestException)
            {
                await DisplayAlert("Advertencia", "Seleccione un cliente", "De acuerdo");
            }
            

        }

        private void LlamarCliente_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (validaciones.verificarCampo(number.Trim()))
                {
                    PhoneDialer.Open(number);
                }
                else
                {
                    DisplayAlert("Advertencia", "Cliente no tiene numero telefonico", "Entendido");
                }
            }
            catch (NullReferenceException)
            {
                DisplayAlert("Advertencia", "Cliente no tiene numero telefonico", "Entendido");
            }
        }

        private void EmailCliente_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (validaciones.verificarCorreo(email))
                {
                    var message = new EmailMessage("", "", email);
                    Email.ComposeAsync(message);
                }
                else
                {
                    DisplayAlert("Advertencia", "Cliente no tiene correo electronico", "Entendido");
                }
            }
            catch (NullReferenceException)
            {
                DisplayAlert("Advertencia", "Cliente no tiene correo electronico", "Entendido");
            }
        }
    }
}