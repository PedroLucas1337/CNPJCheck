using System;
using System.Collections.Generic;
using System.Linq;
using YourNamespace;

namespace CNPJValidacao
{
    internal class CNPJAll
    {
        public void ExibirInformacoes(CNPJModels cnpjModels)
        {
            if (cnpjModels == null)
            {
                Console.WriteLine("CNPJ Nulo");
                return;
            }

            Console.WriteLine("Razão Social: " + (cnpjModels.RazaoSocial ?? "Razão Social não disponível"));
            Console.WriteLine("Situação Cadastral: " + (cnpjModels.Estabelecimento?.SituacaoCadastral ?? "Situação Cadastral não disponível"));
            Console.WriteLine("Tipo: " + (cnpjModels.Estabelecimento?.Tipo ?? "Tipo não disponível"));
            Console.WriteLine("Porte: " + (cnpjModels.Porte?.Descricao ?? "Porte não disponível"));
            Console.WriteLine("Natureza Jurídica: " + (cnpjModels.NaturezaJuridica?.Descricao ?? "Natureza Jurídica não disponível"));

            if (cnpjModels.Estabelecimento?.AtividadePrincipal != null)
            {
                Console.WriteLine("Atividade Principal: ");
                var atividade = cnpjModels.Estabelecimento.AtividadePrincipal;
                Console.WriteLine($"- Código: {atividade.Id}, Descrição: {atividade.Descricao}");
            }
            else
            {
                Console.WriteLine("Atividade Principal não disponível");
            }

            if (cnpjModels.Socios != null && cnpjModels.Socios.Count > 0)
            {
                Console.WriteLine("Quadro Societário:");
                foreach (var qsa in cnpjModels.Socios)
                {
                    Console.WriteLine($"- Nome: {qsa.Nome}, Qualificação: {qsa.Qual}");
                }
            }
            else
            {
                Console.WriteLine("Quadro Societário não disponível");
            }
        }
    }
}
