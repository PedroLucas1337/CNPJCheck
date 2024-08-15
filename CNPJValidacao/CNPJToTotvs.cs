using System;
using CNPJValidacao; // Namespace onde CNPJModels e outros estão definidos

namespace YourNamespace
{
    public class CnpjToTotvsMapper
    {
        public ModelClass MapToTOTVSModel(CNPJModels cnpjData)
        {
            if (cnpjData == null)
            {
                throw new ArgumentNullException(nameof(cnpjData), "Cnpj Nulo");
            }

            return new ModelClass
            {
                CustomerVendorId = cnpjData.Cnpj,
                CompanyId = "456", // Ajuste conforme necessário
                BranchId = "D MG 01", // Ajuste conforme necessário
                CompanyInternalId = cnpjData.Cnpj,
                Code = "000001", // Ajuste conforme necessário
                StoreId = "01", // Ajuste conforme necessário
                InternalId = cnpjData.Cnpj,
                ShortName = cnpjData.Fantasia,
                Name = cnpjData.Nome,
                Type = "1", // Ajuste conforme necessário
                EntityType = "1-Company", // Ajuste conforme necessário
                MarketSegment = new MarketSegment
                {
                    MarketSegmentCode = "001", // Ajuste conforme necessário
                    MarketSegmentInternalId = "002", // Ajuste conforme necessário
                    MarketSegmentDescription = "Segmento Exemplo" // Ajuste conforme necessário
                },
                RegisterDate = DateTime.UtcNow.ToString("o"),
                RegisterSituation = "1", // Ajuste conforme necessário
                Comments = cnpjData.MotivoSituacao,
                Address = new Address
                {
                    Number = cnpjData.Numero,
                    Complement = cnpjData.Complemento,
                    City = new City
                    {
                        CityCode = cnpjData.Uf,
                        CityInternalId = "001", // Ajuste conforme necessário
                        CityDescription = cnpjData.Municipio
                    },
                    District = cnpjData.Bairro,
                    State = new State
                    {
                        StateId = cnpjData.Uf,
                        StateInternalId = "001", // Ajuste conforme necessário
                        StateDescription = "São Paulo" // Ajuste conforme necessário
                    },
                    Country = new Country
                    {
                        CountryCode = "BR",
                        CountryInternalId = "001", // Ajuste conforme necessário
                        CountryDescription = "Brasil"
                    },
                    ZipCode = cnpjData.Cep,
                    Region = "Zona Central", // Ajuste conforme necessário
                    PoBox = "12345", // Ajuste conforme necessário
                    MainAddress = true, // Ajuste conforme necessário
                    ShippingAddress = false, // Ajuste conforme necessário
                    BillingAddress = true // Ajuste conforme necessário
                },
                // Adicione outros campos conforme necessário
            };
        }
    }
}

//Explicação:
//Propriedades Básicas: Estamos pegando informações básicas do CNPJModels (como Cnpj, Nome, Fantasia) e mapeando para as propriedades correspondentes de ModelClass.
//MarketSegment: Definimos valores fixos para os campos do segmento de mercado. Estes valores podem ser ajustados conforme a necessidade.
//Address: Mapeamos os detalhes do endereço a partir de CNPJModels, incluindo cidade, estado, país, etc.
