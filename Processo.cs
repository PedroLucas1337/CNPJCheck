using System;

namespace CNPJValidacao
{
    public class Processo
    {
        public void Start(string cnpj)
        {
            // Lógica para processar o CNPJ
            if (IsValidCNPJ(cnpj))
            {
                // Lógica para processar o CNPJ, como registrar em um banco de dados
                Console.WriteLine($"CNPJ {cnpj} é válido e foi processado.");
            }
            else
            {
                Console.WriteLine($"CNPJ {cnpj} não é válido.");
            }
        }

        private bool IsValidCNPJ(string cnpj)
        {
            // Implementação simplificada de validação (não é a validação real)
            return cnpj.Length == 14; // Exemplo: deve ter 14 caracteres
        }
    }
}
