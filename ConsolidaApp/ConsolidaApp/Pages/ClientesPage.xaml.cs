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
    public partial class ClientesPage : ContentPage
        
    {
        public ObservableCollection<ClientesViewModels> clientes;
        
       public ClientesPage()
        {
            InitializeComponent();
            clientes = new ObservableCollection<ClientesViewModels>();
            
        }

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            string valor = null;
            try
            {
                valor = EntSearch.Text.Trim();
                if (valor==null)
                {
                    await DisplayAlert("Falta parametros", "Debe ingresar un valor de busqueda", "Salir");
                    clientes.Clear();
                    BusyIndicator.IsRunning = false;
                    
                }
                else
                {
                    BusyIndicator.IsRunning = true;
                    clientes.Clear();
                    ApiService apiService = new ApiService();
                    var listaCliente = await apiService.GetClientes(valor);
                    foreach (var cli in listaCliente)
                    {
                        clientes.Add(cli);
                    }
                    LvClientes.ItemsSource = clientes;
                    BusyIndicator.IsRunning = false;
                }
            }catch(NullReferenceException)
            {
                await DisplayAlert("Error", "Ingrese un campo de busqueda", "Salir");
            }
            catch (HttpRequestException)
            {
                clientes.Clear();
                BusyIndicator.IsRunning = false;
            }
            

        }

        private void LvClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCliente = e.SelectedItem as ClientesViewModels;

            if (selectedCliente != null)
            {
                Preferences.Set("codigo", selectedCliente.Codigo);
                var homepage = new HomePage();
                ChangeScreen(1);
            }

        }
        public void ChangeScreen(int page)
        {
            /*Se crea una variable que hara referencia a un TabbedPage
                 luego a la pagina actual, se activa la pagina No.2*/
            var masterpage = this.Parent as TabbedPage;
            masterpage.CurrentPage = masterpage.Children[page]; //Accede a pagina 2
            masterpage.CurrentPage.Focus();
        }

        private void LlamarCliente_Clicked(object sender, EventArgs e)
        {

        }
    }
}