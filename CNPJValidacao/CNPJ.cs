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
