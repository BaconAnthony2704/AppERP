using ConsolidaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            
            ApiService apiService = new ApiService();
            if (codigo != null)
            {
                var cliente = await apiService.GetClientes(codigo);
                foreach (var cli in cliente)
                {
                    clientes.Add(cli);
                }
                LvExist.ItemsSource = clientes;

            }
            else
            {
                await DisplayAlert("status", "Seleccione el cliente", "salir");
            }

        }

    }
}