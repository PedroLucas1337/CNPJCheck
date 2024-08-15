using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using YourNamespace;

namespace CNPJValidacao
{
    public class TotvsApiClient
    {
        private readonly HttpClient _httpClient;
        

        public TotvsApiClient(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        public TotvsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> SendCustomerVendorDataAsync(ModelClass model)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("/customerVendor", content);

            return response.IsSuccessStatusCode;
        }

        public async Task FetchAndSendDataAsync(string cnpj)
        {
          try
            {
                CNPJService cnpjService = new CNPJService();
                CNPJModels cnpjData = await cnpjService.ObterInfoCNPJAsync(cnpj);

                if (cnpjData != null)
                {
                    // Mapeia para o modelo TOTVS
                    CnpjToTotvsMapper mapper = new CnpjToTotvsMapper();
                    ModelClass model = mapper.MapToTOTVSModel(cnpjData);

                    // Envia para a API Totvs RM
                    bool success = await SendCustomerVendorDataAsync(model);

                    if (!success)
                    {
                        throw new Exception("Falha ao enviar dados para a API Totvs RM.");
                    }
                }
                else
                {
                    throw new Exception("Dados do CNPJ são nulos.");
                }
            } 
            
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}

//Explicação:
//Construtor: Configura a URL base para a API do Totvs RM.
//SendCustomerVendorDataAsync: Método que envia os dados para a API do Totvs RM. Ele serializa o ModelClass para JSON e envia via POST.
