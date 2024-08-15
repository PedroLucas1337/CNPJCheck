using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPJValidacao
{
    internal class CNPJAll
    {
        public void exibirInformacoes (CNPJModels cnpjModels)
        {
            if (cnpjModels == null)
            {
                Console.WriteLine("CNPJ Nulo");
                return;
            }
            Console.WriteLine("Nome: " + (cnpjModels.Nome ?? "Nome não disponível"));
            Console.WriteLine("Situação: " + (cnpjModels.Situacao ?? "Situação não disponível"));
            Console.WriteLine("Tipo: " + (cnpjModels.Tipo ?? "Tipo não disponível"));
            Console.WriteLine("Porte: " + (cnpjModels.Porte ?? "Porte não disponível"));
            Console.WriteLine("Natureza Jurídica: " + (cnpjModels.NaturezaJuridica ?? "Natureza Jurídica não disponível"));

            if (cnpjModels.AtividadePrincipal != null && cnpjModels.AtividadePrincipal.Count > 0)
            {
                Console.WriteLine("Atividade Principal: ");
                foreach (var atividade in cnpjModels.AtividadePrincipal)
                {
                    Console.WriteLine($"- Código: {atividade.Code}, Descrição: {atividade.Text}");
                }
            }
            else
            {
                Console.WriteLine("Atiivdade Principal não disponível");
            }

            if (cnpjModels.Qsa != null && cnpjModels.Qsa.Count > 0)
            {
                Console.WriteLine("Quadro Societário:");
                foreach (var qsa in cnpjModels.Qsa)
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
