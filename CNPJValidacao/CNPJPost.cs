using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YourNamespace
{
    public class ApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task SendDataAsync(CombinedModel model)
        {
            // URL da API da TOTVS RM
            string url = "https://api.totvs.com.br/"; // Substitua pela URL real da API da TOTVS RM

            try
            {
                // Serialize o modelo para JSON
                string json = JsonConvert.SerializeObject(model);

                // Crie o conteúdo da requisição HTTP
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // Envie a requisição POST
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                // Verifique se a resposta foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Dados enviados com sucesso. Resposta da API: " + responseContent);
                }
                else
                {
                    Console.WriteLine($"Falha ao enviar dados. Código de status: {response.StatusCode}");
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Resposta de erro: " + errorResponse);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao enviar os dados: {ex.Message}");
            }
        }
    }
}


//Explicação Detalhada
//CombinedModel

//Cada propriedade é anotada com o atributo [JsonProperty] para mapear a propriedade JSON correspondente.
//Propriedades do CombinedModel

//Informações Gerais: Inclui propriedades como CustomerVendorId, CompanyId, BranchId, etc., que representam identificadores e dados gerais sobre o cliente ou fornecedor.
//Informações de Mercado e Governamentais: Inclui MarketSegment e GovernmentalInformation, que são estruturas complexas para informações de mercado e governamentais.
//Endereços e Contatos: Propriedades como Address, ShippingAddress, ListOfCommunicationInformation, e ListOfContacts são usadas para armazenar endereços e detalhes de comunicação.
//Informações Bancárias e de Faturamento: Inclui BankingInformation, BillingInformation, VendorInformation, e FiscalInformation.
//Informações de Crédito e Complementares: Inclui CreditInformation e ComplementaryFields.
//Classes Internas

//MarketSegment: Representa dados relacionados ao segmento de mercado.
//GovernmentalInformation: Contém informações governamentais, como identificadores e datas de validade.
//Address e City: Representam endereços e cidades.
//CommunicationInformation, Contact, BankingInformation, BillingInformation, VendorInformation, FiscalInformation, e CreditInformation: Cada uma representa uma parte específica dos dados que você precisa enviar ou receber.
//ComplementaryFields: Contém campos adicionais que podem ser necessários.
//Como Usar o CombinedModel
//Coletar Dados: Depois de consultar a API de CNPJ e obter os dados, você preenche um objeto CombinedModel com essas informações.
//Enviar Dados: O objeto CombinedModel é então enviado para a API da TOTVS usando o cliente TotvsApiClient.