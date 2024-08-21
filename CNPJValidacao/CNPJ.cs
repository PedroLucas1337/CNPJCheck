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
                    // Exibindo raz�o social e inscri��o estadual na label2
                    var inscricaoEstadual = cnpjData.Estabelecimento?.InscricoesEstaduais?.Find(i => i.Ativo);
                    label2.Text = $"Raz�o Social: {cnpjData.RazaoSocial ?? "N�o dispon�vel"}\n" +
                                  $"Inscri��o Estadual: {(inscricaoEstadual != null ? inscricaoEstadual.NumeroInscricao : "N�o dispon�vel")}";
                }
                else
                {
                    label2.Text = "Raz�o Social e Inscri��o Estadual: Dados n�o encontrados";
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                MessageBox.Show($"Erro na consulta: {httpRequestException.Message}");
                label2.Text = "Raz�o Social e Inscri��o Estadual: Erro na consulta";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
                label2.Text = "Raz�o Social e Inscri��o Estadual: Erro inesperado";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "Raz�o Social e Inscri��o Estadual: ";
        }
    }

    // Adicione a defini��o de CNPJData e InscricaoEstadual aqui.
}


//Explica��o Detalhada
//Importa��o de Namespaces e Inicializa��o

//using System;: Importa o namespace b�sico do .NET.
//using CNPJValidacao;
//using System.Net.Http;: Importa classes para opera��es HTTP.
//using System.Threading.Tasks;: Importa classes para tarefas ass�ncronas.
//using System.Windows.Forms;: Importa classes para criar a interface gr�fica do usu�rio.
//using Newtonsoft.Json;: Importa o Newtonsoft.Json para manipula��o de JSON.
//using YourNamespace;: Importa o namespace onde suas classes de modelos e cliente da API est�o localizadas.
//Defini��o da Classe Form1

//A classe Form1 � a forma principal que o usu�rio v�.
//Inicializa��o do HttpClient e TotvsApiClient

//private static readonly HttpClient httpClient = new HttpClient();: Cria um cliente HTTP para enviar e receber solicita��es.
//private readonly TotvsApiClient totvsApiClient;: Cria um cliente para interagir com a API da TOTVS.
//Construtor Form1()

//totvsApiClient = new TotvsApiClient("https://api.totvs.com.br", new CNPJService(), new CnpjToTotvsMapper());: Inicializa o cliente da API TOTVS com o URL da API e a classe de mapeamento.
//M�todo button1_Click

//Valida��o do CNPJ: Verifica se o CNPJ inserido n�o est� vazio.
//Requisi��o HTTP: Faz uma solicita��o GET para a API p�blica do CNPJ usando o URL.
//Deserializa��o JSON: Converte a resposta JSON para a classe CNPJData.
//Exibi��o de Dados: Atualiza as label1 e label2 com a Raz�o Social e a Inscri��o Estadual.
//Envio para a API da TOTVS: Cria um objeto ModelClass e envia para a API da TOTVS usando o cliente TotvsApiClient.
//M�todo Form1_Load

//Inicializa��o das Labels: Define o texto inicial das labels quando o formul�rio � carregado.
//Observa��es
//Tratamento de Erros: O c�digo inclui tratamento de exce��es para erros na consulta HTTP e erros inesperados.
//Assincronidade: O m�todo button1_Click � ass�ncrono (async), permitindo opera��es ass�ncronas, como requisi��es HTTP e processamento de JSON, sem bloquear a interface do usu�rio.