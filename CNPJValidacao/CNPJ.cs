using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using YourNamespace;

namespace CNPJValidacao
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string cnpj = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(cnpj))
            {
                MessageBox.Show("Por favor, insira um CNPJ.");
                return;
            }

            try
            {
                string url = $"https://publica.cnpj.ws/cnpj/{cnpj}";

                // Log URL
                Console.WriteLine($"URL: {url}");

                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Log raw JSON response
                Console.WriteLine($"Raw JSON: {jsonResponse}");

                CNPJData cnpjData = JsonConvert.DeserializeObject<CNPJData>(jsonResponse);

                if (cnpjData != null)
                {
                    // Exibindo razão social e inscrição estadual na label2
                    var inscricaoEstadual = cnpjData.Estabelecimento?.InscricoesEstaduais?.Find(i => i.Ativo);
                    label2.Text = $"Razão Social: {cnpjData.RazaoSocial ?? "Não disponível"}\n" +
                                  $"Inscrição Estadual: {(inscricaoEstadual != null ? inscricaoEstadual.NumeroInscricao : "Não disponível")}";
                }
                else
                {
                    label2.Text = "Razão Social e Inscrição Estadual: Dados não encontrados";
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                MessageBox.Show($"Erro na consulta: {httpRequestException.Message}");
                label2.Text = "Razão Social e Inscrição Estadual: Erro na consulta";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
                label2.Text = "Razão Social e Inscrição Estadual: Erro inesperado";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Razão Social e Inscrição Estadual: ";
        }
    }

    // Adicione a definição de CNPJData e InscricaoEstadual aqui.
}


//Explicação Detalhada
//Importação de Namespaces e Inicialização

//using System;: Importa o namespace básico do .NET.
//using CNPJValidacao;
//using System.Net.Http;: Importa classes para operações HTTP.
//using System.Threading.Tasks;: Importa classes para tarefas assíncronas.
//using System.Windows.Forms;: Importa classes para criar a interface gráfica do usuário.
//using Newtonsoft.Json;: Importa o Newtonsoft.Json para manipulação de JSON.
//using YourNamespace;: Importa o namespace onde suas classes de modelos e cliente da API estão localizadas.
//Definição da Classe Form1

//A classe Form1 é a forma principal que o usuário vê.
//Inicialização do HttpClient e TotvsApiClient

//private static readonly HttpClient httpClient = new HttpClient();: Cria um cliente HTTP para enviar e receber solicitações.
//private readonly TotvsApiClient totvsApiClient;: Cria um cliente para interagir com a API da TOTVS.
//Construtor Form1()

//totvsApiClient = new TotvsApiClient("https://api.totvs.com.br", new CNPJService(), new CnpjToTotvsMapper());: Inicializa o cliente da API TOTVS com o URL da API e a classe de mapeamento.
//Método button1_Click

//Validação do CNPJ: Verifica se o CNPJ inserido não está vazio.
//Requisição HTTP: Faz uma solicitação GET para a API pública do CNPJ usando o URL.
//Deserialização JSON: Converte a resposta JSON para a classe CNPJData.
//Exibição de Dados: Atualiza as label1 e label2 com a Razão Social e a Inscrição Estadual.
//Envio para a API da TOTVS: Cria um objeto ModelClass e envia para a API da TOTVS usando o cliente TotvsApiClient.
//Método Form1_Load

//Inicialização das Labels: Define o texto inicial das labels quando o formulário é carregado.
//Observações
//Tratamento de Erros: O código inclui tratamento de exceções para erros na consulta HTTP e erros inesperados.
//Assincronidade: O método button1_Click é assíncrono (async), permitindo operações assíncronas, como requisições HTTP e processamento de JSON, sem bloquear a interface do usuário.