using ConsolidaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Web2.ViewModels;

namespace ConsolidaApp.Services
{
   
    public class ApiService
    {
        RegisterModel registro = new RegisterModel(); 
        public string auth0_domain = "pruebaapi.auth0.com";
        public string conexionDb = "AuthUserDb";
        public string cliente_id = "19qtN9oShqChEpqHNtZy5v5vHzNvdd6i";
        public string client_secret = "cnHhLXYZCavXRVx99xr6BH3BOMvnuxOREwp3tVRPnt7aN9DHjtvmPp9_TFMG9NF3";
        public string audience = "https://localhost:44306/";
        public async Task<bool> RegisterUser(string email, string password)
        {
            var registerModel = new RegisterModel()
            {
                Email = email, 
                Password = password,
                Client_Id=cliente_id,
                Connection=conexionDb
            };

            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(registerModel);
            Console.WriteLine(json);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://"+auth0_domain+"/dbconnections/signup", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<TokenResponse> GetToken(string email, string password)
        {
            var httpClient = new HttpClient();
            var content=new StringContent($"grant_type=password&client_id={cliente_id}&audience={audience}&username={email}&password={password}&client_secret={client_secret}", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("https://" + auth0_domain + "/oauth/token", content);
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
                Client_id =cliente_id,
                Email = email,
                Connection=conexionDb
            };
            var json = JsonConvert.SerializeObject(recoveryPasswordModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://" + auth0_domain + "/dbconnections/change_password", content);
            return response.IsSuccessStatusCode;

        }
        public async Task<List<ClientesViewModels>> GetClientes()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IlF6a3lOME15TURVelFURTNSa0V4UkRWQ1FqUTVOVU16TnpKQ05UWkJSamd6T0RrME9ESkZRUSJ9.eyJpc3MiOiJodHRwczovL3BydWViYWFwaS5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NWRkZDU2NDRmOGQ1OWMwZGVhZDA3ZmJjIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDYvIiwiaWF0IjoxNTc0OTc1MzgxLCJleHAiOjE1NzUwNjE3ODEsImF6cCI6IjE5cXROOW9TaHFDaEVwcUhOdFp5NXY1dkh6TnZkZDZpIiwiZ3R5IjoicGFzc3dvcmQifQ.EI_eJUtrSJMqDnkO3NOESFmSd0wD7zQXyvNSRz1fuTKAYdJL-9oK4hpgFEmCYaZ8a5XzDtoMTxg1js_uvbFliXz0--1kibAmTFRdAy_bynx1rAusDzAdGLYMbsGJm5HHDI38lEEKT6dH-nhnXzZry8McsepVs6hMtNy93Pj7NicIL5nhK3B_kYcwTqV6X07sfDZd6LimXQ56UgrVNZspBZxZCMd1IPqc2eyKFwZOxagN5FEe9E29nmg-47jLy4wVRH73haJCd-Lc58PC8ODjaiJFlP-UrcgAkR7Ix2g7LBxhl1PBhAUBZ1uSdOEmeGMCy_wgpXH3BYXtpQcVQajuDA");
            var response = await httpClient.GetStringAsync("https://consolidaerp.azurewebsites.net/api/Clientes/Listar/o");
            return JsonConvert.DeserializeObject<List<ClientesViewModels>>(response);

        }
        public async Task<List<ClientesViewModels>> GetClientes(string value)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IlF6a3lOME15TURVelFURTNSa0V4UkRWQ1FqUTVOVU16TnpKQ05UWkJSamd6T0RrME9ESkZRUSJ9.eyJpc3MiOiJodHRwczovL3BydWViYWFwaS5hdXRoMC5jb20vIiwic3ViIjoiYXV0aDB8NWRkZDU2NDRmOGQ1OWMwZGVhZDA3ZmJjIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzMDYvIiwiaWF0IjoxNTc0OTc1MzgxLCJleHAiOjE1NzUwNjE3ODEsImF6cCI6IjE5cXROOW9TaHFDaEVwcUhOdFp5NXY1dkh6TnZkZDZpIiwiZ3R5IjoicGFzc3dvcmQifQ.EI_eJUtrSJMqDnkO3NOESFmSd0wD7zQXyvNSRz1fuTKAYdJL-9oK4hpgFEmCYaZ8a5XzDtoMTxg1js_uvbFliXz0--1kibAmTFRdAy_bynx1rAusDzAdGLYMbsGJm5HHDI38lEEKT6dH-nhnXzZry8McsepVs6hMtNy93Pj7NicIL5nhK3B_kYcwTqV6X07sfDZd6LimXQ56UgrVNZspBZxZCMd1IPqc2eyKFwZOxagN5FEe9E29nmg-47jLy4wVRH73haJCd-Lc58PC8ODjaiJFlP-UrcgAkR7Ix2g7LBxhl1PBhAUBZ1uSdOEmeGMCy_wgpXH3BYXtpQcVQajuDA");
            var response = await httpClient.GetStringAsync("https://consolidaerp.azurewebsites.net/api/Clientes/Listar/" + value);
            return JsonConvert.DeserializeObject<List<ClientesViewModels>>(response);
        }
    }
}
