using System.Net.Http;
using System.Threading.Tasks;

namespace CNPJValidacao
{
    public class CNPJService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public async Task<HttpResponseMessage> GetApiResponse(string apiUrl)
        {
            // Faz uma chamada para a URL fornecida e retorna a resposta
            return await httpClient.GetAsync(apiUrl);
        }
    }
}
