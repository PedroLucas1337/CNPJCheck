using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using YourNamespace;

namespace CNPJValidacao
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly TotvsApiClient totvsApiClient;

        public Form1()
        {
            InitializeComponent();
            totvsApiClient = new TotvsApiClient("https://api.totvs.com.br", new CNPJService(), new YourNamespace.CnpjToTotvsMapper());
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
                CNPJService cnpjService = new CNPJService();
                CNPJModels cnpjModels = await cnpjService.ObterInfoCNPJAsync(cnpj);

                await totvsApiClient.FetchAndSendDataAsync(cnpj);

                if (cnpjModels != null)
                {
                    label1.Text = "CNPJ";
                    label2.Text = $"Razão Social: {cnpjModels.RazaoSocial ?? "Razão Social Indisponível"}\n" +
                                  $"Capital Social: {cnpjModels.CapitalSocial ?? "Capital Social Indisponível"}\n" +
                                  $"Responsável Federativo: {cnpjModels.ResponsavelFederativo ?? "Responsável Federativo Indisponível"}\n" +
                                  $"Porte: {cnpjModels.Porte?.Descricao ?? "Porte Indisponível"}\n" +
                                  $"Natureza Jurídica: {cnpjModels.NaturezaJuridica?.Descricao ?? "Natureza Jurídica Indisponível"}\n" +
                                  $"Atualizado Em: {cnpjModels.AtualizadoEm.ToString("dd/MM/yyyy")}";

                    if (cnpjModels.Estabelecimento != null)
                    {
                        label2.Text += $"\nNome Fantasia: {cnpjModels.Estabelecimento.NomeFantasia ?? "Nome Fantasia Indisponível"}\n" +
                                      $"Situação Cadastral: {cnpjModels.Estabelecimento.SituacaoCadastral ?? "Situação Cadastral Indisponível"}\n" +
                                      $"Data Início Atividade: {cnpjModels.Estabelecimento.DataInicioAtividade ?? "Data Início Atividade Indisponível"}\n" +
                                      $"Inscrição Estadual: {string.Join(", ", cnpjModels.Estabelecimento.InscricoesEstaduais?.Select(i => i.NumeroInscricao) ?? new[] { "Inscrição Estadual Indisponível" })}";
                    }

                    if (cnpjModels.Socios != null && cnpjModels.Socios.Count > 0)
                    {
                        label2.Text += "\nSócios:";
                        foreach (var socio in cnpjModels.Socios)
                        {
                            label2.Text += $"\n- Nome: {socio.Nome}, Qualificação: {socio.Qual}, Nome Representante Legal: {socio.NomeRepLegal}, Qualificação Representante Legal: {socio.QualRepLegal}";
                        }
                    }
                    else
                    {
                        label2.Text += "\nSócios não disponíveis";
                    }
                }
                else
                {
                    label2.Text = "Resposta da API não contém dados válidos.";
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
            label1.Text = "CNPJ";
            label2.Text = "Validação";
        }
    }
}
