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
