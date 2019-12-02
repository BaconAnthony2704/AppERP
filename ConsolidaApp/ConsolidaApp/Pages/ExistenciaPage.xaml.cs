using ConsolidaApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsolidaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExistenciaPage : ContentPage

    {
        public ObservableCollection<ClientesViewModels> clientes;
        public ExistenciaPage()
        {
            InitializeComponent();
            
        }
        public ExistenciaPage(string id)
        {
            InitializeComponent();
            clientes = new ObservableCollection<ClientesViewModels>();
            GetClienteProfile(id);
        }
        
        
        public async void GetClienteProfile(string id)
        {
            ApiService apiService = new ApiService();
            var listaCliente = await apiService.GetClientes(id);
            foreach (var cli in listaCliente)
            {
                clientes.Add(cli);
                idCliente.ItemsSource = clientes;
            }
            
        }

    }
}