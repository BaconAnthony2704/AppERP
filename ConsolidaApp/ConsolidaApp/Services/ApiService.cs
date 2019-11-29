using ConsolidaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Web2.ViewModels;
using Xamarin.Essentials;

namespace ConsolidaApp.Services
{
   
    public class ApiService
    {
        Constantes estatico = new Constantes();
        public async Task<bool> RegisterUser(string email, string password)
        {
            var registerModel = new RegisterModel()
            {
                email = email, 
                password = password,
                client_id=estatico.cliente_id,
                connection = estatico.conexionDb
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://"+estatico.auth0_domain+"/dbconnections/signup", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<TokenResponse> GetToken(string email, string password)
        {
            var httpClient = new HttpClient();
            var content=new StringContent($"grant_type=password&client_id={estatico.cliente_id}&audience={estatico.audience}&username={email}&password={password}&client_secret={estatico.client_secret}", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("https://" + estatico.auth0_domain + "/oauth/token", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponse>(jsonResult);
            Console.WriteLine(result);
            return result;
        }

        public async Task<bool> PasswordRecovery(string email)
        {
            var httpClient = new HttpClient();
            var recoveryPasswordModel = new PasswordRecoveryModel() 
            {
                client_id =estatico.cliente_id,
                email = email,
                connection=estatico.conexionDb
            };
            var json = JsonConvert.SerializeObject(recoveryPasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://" + estatico.auth0_domain + "/dbconnections/change_password", content);
            return response.IsSuccessStatusCode;

        }
        public async Task<List<ClientesViewModels>> GetClientes()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accesstoken",""));
            var response = await httpClient.GetStringAsync("https://consolidaerp.azurewebsites.net/api/Clientes/Listar/o");
            return JsonConvert.DeserializeObject<List<ClientesViewModels>>(response);

        }
        public async Task<List<ClientesViewModels>> GetClientes(string value)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("accesstoken", ""));
            var response = await httpClient.GetStringAsync("https://consolidaerp.azurewebsites.net/api/Clientes/Listar/" + value);
            return JsonConvert.DeserializeObject<List<ClientesViewModels>>(response);
        }
    }
}
