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
                    label2.Text = $"Raz�o Social: {cnpjModels.RazaoSocial ?? "Raz�o Social Indispon�vel"}\n" +
                                  $"Capital Social: {cnpjModels.CapitalSocial ?? "Capital Social Indispon�vel"}\n" +
                                  $"Respons�vel Federativo: {cnpjModels.ResponsavelFederativo ?? "Respons�vel Federativo Indispon�vel"}\n" +
                                  $"Porte: {cnpjModels.Porte?.Descricao ?? "Porte Indispon�vel"}\n" +
                                  $"Natureza Jur�dica: {cnpjModels.NaturezaJuridica?.Descricao ?? "Natureza Jur�dica Indispon�vel"}\n" +
                                  $"Atualizado Em: {cnpjModels.AtualizadoEm.ToString("dd/MM/yyyy")}";

                    if (cnpjModels.Estabelecimento != null)
                    {
                        label2.Text += $"\nNome Fantasia: {cnpjModels.Estabelecimento.NomeFantasia ?? "Nome Fantasia Indispon�vel"}\n" +
                                      $"Situa��o Cadastral: {cnpjModels.Estabelecimento.SituacaoCadastral ?? "Situa��o Cadastral Indispon�vel"}\n" +
                                      $"Data In�cio Atividade: {cnpjModels.Estabelecimento.DataInicioAtividade ?? "Data In�cio Atividade Indispon�vel"}\n" +
                                      $"Inscri��o Estadual: {string.Join(", ", cnpjModels.Estabelecimento.InscricoesEstaduais?.Select(i => i.NumeroInscricao) ?? new[] { "Inscri��o Estadual Indispon�vel" })}";
                    }

                    if (cnpjModels.Socios != null && cnpjModels.Socios.Count > 0)
                    {
                        label2.Text += "\nS�cios:";
                        foreach (var socio in cnpjModels.Socios)
                        {
                            label2.Text += $"\n- Nome: {socio.Nome}, Qualifica��o: {socio.Qual}, Nome Representante Legal: {socio.NomeRepLegal}, Qualifica��o Representante Legal: {socio.QualRepLegal}";
                        }
                    }
                    else
                    {
                        label2.Text += "\nS�cios n�o dispon�veis";
                    }
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
            label1.Text = "CNPJ";
            label2.Text = "Valida��o";
        }
    }
}
