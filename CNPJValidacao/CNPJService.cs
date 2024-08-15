using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CNPJValidacao
{
    public class CNPJService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<CNPJModels> ObterInfoCNPJAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                throw new ArgumentException("Cnpj vazio", nameof(cnpj));
            }

            string apiUrl = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";

            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            CNPJModels cnpjModels = JsonConvert.DeserializeObject<CNPJModels>(responseBody);

            return cnpjModels;
        }
    }
}
