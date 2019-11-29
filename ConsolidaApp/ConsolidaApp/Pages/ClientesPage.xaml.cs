using ConsolidaApp.Models;
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
    public partial class ClientesPage : ContentPage
        
    {
        public ObservableCollection<ClientesViewModels> clientes;
       public ClientesPage()
        {
            InitializeComponent();
            clientes = new ObservableCollection<ClientesViewModels>();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ApiService apiService = new ApiService();
            var listaClientes = await apiService.GetClientes();
            foreach(var cli in listaClientes)
            {
                clientes.Add(cli);
            }
            LvClientes.ItemsSource = clientes;

        }

    }
}