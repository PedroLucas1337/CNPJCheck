using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YourNamespace;

namespace CNPJValidacao
{
    public class TotvsApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly CNPJService _cnpjService;
        private readonly CnpjToTotvsMapper _mapper;

        public TotvsApiClient(string baseAddress, CNPJService cnpjService, CnpjToTotvsMapper mapper)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
            _cnpjService = cnpjService ?? throw new ArgumentNullException(nameof(cnpjService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public TotvsApiClient(HttpClient httpClient, CNPJService cnpjService, CnpjToTotvsMapper mapper)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _cnpjService = cnpjService ?? throw new ArgumentNullException(nameof(cnpjService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> SendCustomerVendorDataAsync(ModelClass model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Modelo de dados nulo");
            }

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("/customerVendor", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Falha ao enviar dados. Status: {response.StatusCode}, Resposta: {responseBody}");
            }
        }

        public async Task FetchAndSendDataAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                throw new ArgumentException("CNPJ vazio", nameof(cnpj));
            }

            try
            {
                CNPJModels cnpjData = await _cnpjService.ObterInfoCNPJAsync(cnpj);

                if (cnpjData != null)
                {
                    // Mapeia para o modelo TOTVS
                    ModelClass model = _mapper.MapToTOTVSModel(cnpjData);

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
                // Considere registrar o erro em um log em vez de apenas escrever no console
            }
        }
    }
}
