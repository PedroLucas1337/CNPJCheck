using Newtonsoft.Json;
using System.Collections.Generic;

namespace YourNamespace
{
    public class CNPJData
    {
        [JsonProperty("cnpj_raiz")]
        public string CNPJRaiz { get; set; }

        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty("capital_social")]
        public string CapitalSocial { get; set; }

        [JsonProperty("estabelecimento")]
        public Estabelecimento Estabelecimento { get; set; }
    }

    public class Estabelecimento
    {
        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }

        [JsonProperty("inscricoes_estaduais")]
        public List<InscricaoEstadual> InscricoesEstaduais { get; set; }

        // Outras propriedades se necessário
    }

    public class InscricaoEstadual
    {
        [JsonProperty("inscricao_estadual")]
        public string NumeroInscricao { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }
}
