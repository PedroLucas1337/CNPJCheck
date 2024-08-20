using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YourNamespace;

namespace CNPJValidacao
{
    public class CNPJService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<CNPJModels> ObterInfoCNPJAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                throw new ArgumentException("CNPJ não pode ser vazio", nameof(cnpj));
            }

            // Remover caracteres especiais do CNPJ (., /, -)
            string cnpjFormatado = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

            // Garantir que o CNPJ tenha exatamente 14 dígitos
            if (cnpjFormatado.Length != 14)
            {
                throw new ArgumentException("CNPJ deve conter 14 dígitos", nameof(cnpj));
            }

            string apiUrl = $"https://publica.cnpj.ws/cnpj/{cnpjFormatado}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                CNPJModels cnpjModels = JsonConvert.DeserializeObject<CNPJModels>(responseBody);

                return cnpjModels;
            }
            catch (HttpRequestException e)
            {
                // Log the exception or handle it as needed
                throw new Exception("Erro ao consultar a API do CNPJ", e);
            }
            catch (JsonException e)
            {
                // Log the exception or handle it as needed
                throw new Exception("Erro ao processar a resposta da API", e);
            }
        }
    }
}
