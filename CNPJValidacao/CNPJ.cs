using CNPJValidacao;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;

namespace CNPJValidacao
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly TotvsApiClient totvsApiClient;

        public Form1()
        {
            InitializeComponent();

            totvsApiClient = new TotvsApiClient("https://api.totvs.com.br");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Obt�m o CNPJ inserido no TextBox
            string cnpj = textBox1.Text.Trim();

            // Verifica se o CNPJ � v�lido (n�o est� vazio)
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                MessageBox.Show("Por favor, insira um CNPJ.");
                return;
            }

            try
            {

                CNPJService cnpjService = new CNPJService();
                CNPJAll cnpjAll = new CNPJAll();
                CNPJModels cnpjModels = await cnpjService.ObterInfoCNPJAsync(cnpj);
                await totvsApiClient.FetchAndSendDataAsync(cnpj);

                if (cnpjModels != null)
                {

                    cnpjAll.exibirInformacoes(cnpjModels);
                    label2.Text = $"Nome: {cnpjModels.Nome ?? "Nome Indisponivel"}\n" +
                                  $"Situa��o: {cnpjModels.Situacao ?? "Situa��o Indisponivel"}\n" +
                                  $"Tipo: {cnpjModels.Tipo ?? "Tipo Indisponivel"}";
                }

                else
                {
                    label2.Text = "Resposta da API n�o cont�m dados v�lidos.";
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                MessageBox.Show($"Erro na consulta: {httpRequestException.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializa o texto da label1
            label1.Text = "CNPJ";
            // Inicializa o texto da label2
            label2.Text = "Valida��o";
        }
    }
}

//Explica��o:
//Consulta CNPJ: Ao clicar no bot�o, consultamos a API da Receita Federal.
//Mapeamento: Convertendo os dados recebidos para ModelClass.
//Envio para Totvs RM: Enviamos o ModelClass mapeado para a API do Totvs RM e informamos o usu�rio sobre o sucesso ou falha da opera��o.


//Resumo
//Mapper: Converte dados da Receita Federal para o formato esperado pela API do Totvs RM.
//API Client: Envia os dados para a API do Totvs RM.
//Formul�rio: Coordena a consulta, mapeamento e envio dos dados, e fornece feedback ao usu�rio.