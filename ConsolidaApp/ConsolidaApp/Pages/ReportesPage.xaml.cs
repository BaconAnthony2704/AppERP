using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
using ConsolidaApp.Services;
using System.Collections.ObjectModel;
using Web2.ViewModels;

namespace ConsolidaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportesPage : ContentPage
    {
        public ObservableCollection<ClientesViewModels> clientes;

        public ReportesPage()
        {
            InitializeComponent();
            BusyIndicator.IsRunning = true;
            generarGrafico();
        }

        private async void generarGrafico()
        {
               
            ApiService apiService = new ApiService();
            var listaTipoCliente = await apiService.GetClientes();
            int contadorTipoCliente = 0, contadorSocio=0,contadorVisitante=0;
            foreach(var tipo in listaTipoCliente)
            {
                //clientes.Add(tipo);
                if (tipo.TipoCliente.Contains("TIPO CLIENTE"))
                {
                    contadorTipoCliente++;
                }else if (tipo.TipoCliente.Contains("Socio"))
                {
                    contadorSocio++;
                }else if (tipo.TipoCliente.Contains("visitante"))
                {
                    contadorVisitante++;
                }
            }
            List<Entry> entries = new List<Entry>
            {
                new Entry(contadorTipoCliente)
                {
                Color=SKColor.Parse("#00CED1"),
                Label="Tipo Cliente",
                ValueLabel=contadorTipoCliente.ToString()
                },
                new Entry(contadorSocio)
                {
                Color=SKColor.Parse("#00BFFF"),
                Label="Socio",
                ValueLabel=contadorSocio.ToString()
                },
                new Entry(contadorVisitante)
                {
                Color=SKColor.Parse("#00BFAC"),
                Label="Visitante",
                ValueLabel=contadorVisitante.ToString()
                }
            };
            
            Chart1.Chart = new BarChart { Entries = entries };
            BusyIndicator.IsRunning = false;

        }
    }
}