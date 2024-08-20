using System;
using System.Collections.Generic;
using CNPJValidacao;

namespace YourNamespace
{
    public class CnpjToTotvsMapper
    {
        public ModelClass MapToTOTVSModel(CNPJModels cnpjData)
        {
            if (cnpjData == null)
            {
                throw new ArgumentNullException(nameof(cnpjData), "CNPJ data cannot be null.");
            }

            var estabelecimento = cnpjData.Estabelecimento;
            var primaryActivity = estabelecimento.AtividadePrincipal;
            var estado = estabelecimento.Estado;

            return new ModelClass
            {
                customerVendorId = estabelecimento.Cnpj,
                companyId = "456", // Ajuste conforme necessário
                branchId = "D MG 01", // Ajuste conforme necessário
                companyInternalId = estabelecimento.Cnpj,
                code = "000001", // Ajuste conforme necessário
                storeId = "01", // Ajuste conforme necessário
                internalId = estabelecimento.Cnpj,
                shortName = estabelecimento.NomeFantasia,
                name = cnpjData.RazaoSocial,
                type = "1", // Ajuste conforme necessário
                entityType = "1-Company", // Ajuste conforme necessário
                marketsegment = new MarketSegment
                {
                    marketSegmentCode = "001", // Ajuste conforme necessário
                    marketSegmentInternalId = "002", // Ajuste conforme necessário
                    marketSegmentDescription = primaryActivity.Descricao // Ajuste conforme necessário
                },
                registerdate = DateTime.UtcNow, // Ajuste conforme necessário
                registerSituation = estabelecimento.SituacaoCadastral,
                comments = estabelecimento.SituacaoEspecial, // Pode ser ajustado conforme necessário
                address = new Address
                {
                    address = estabelecimento.TipoLogradouro + " " + estabelecimento.Logradouro,
                    number = estabelecimento.Numero,
                    complement = estabelecimento.Complemento,
                    city = new City
                    {
                        cityCode = estabelecimento.Cidade.IbgeId.ToString(),
                        cityInternalId = estabelecimento.Cidade.SiafiId,
                        cityDescription = estabelecimento.Cidade.Nome
                    },
                    district = estabelecimento.Bairro,
                    state = new State
                    {
                        stateId = estado.Sigla,
                        stateInternalId = estado.Id.ToString(),
                        stateDescription = estado.Nome
                    },
                    country = new Country
                    {
                        countryCode = estabelecimento.Pais.Iso2,
                        countryInternalId = estabelecimento.Pais.Id,
                        countryDescription = estabelecimento.Pais.Nome
                    },
                    zipCode = estabelecimento.Cep,
                    region = "Zona Central", // Ajuste conforme necessário
                    poBox = "12345", // Ajuste conforme necessário
                    mainAddress = true, // Ajuste conforme necessário
                    shippingAddress = false, // Ajuste conforme necessário
                    billingAddress = true // Ajuste conforme necessário
                },
                listOfCommunicationInformation = new List<CommunicationInformation>
                {
                    new CommunicationInformation
                    {
                        Type = "Email",
                        PhoneNumber = null,
                        PhoneExtension = null,
                        FaxNumber = estabelecimento.Fax,
                        FaxNumberExtension = null,
                        HomePage = null,
                        Email = estabelecimento.Email,
                        DiallingCode = estabelecimento.Ddd1
                    }
                },
                listOfContacts = new List<ContactInformation>
                {
                    new ContactInformation
                    {
                        ContactInformationCode = "001", // Ajuste conforme necessário
                        ContactInformationInternalId = "002", // Ajuste conforme necessário
                        ContactInformationTitle = "Responsável",
                        ContactInformationName = cnpjData.QualificacaoResponsavel.Descricao,
                        ContactInformationDepartment = null,
                        CommunicationInformation = new CommunicationInformation
                        {
                            Type = "Email",
                            PhoneNumber = $"{estabelecimento.Ddd1} {estabelecimento.Telefone1}",
                            Email = estabelecimento.Email,
                            FaxNumber = estabelecimento.Fax
                        },
                        ContactInformationAddress = new Address
                        {
                            address = estabelecimento.TipoLogradouro + " " + estabelecimento.Logradouro,
                            number = estabelecimento.Numero,
                            complement = estabelecimento.Complemento,
                            city = new City
                            {
                                cityCode = estabelecimento.Cidade.IbgeId.ToString(),
                                cityInternalId = estabelecimento.Cidade.SiafiId,
                                cityDescription = estabelecimento.Cidade.Nome
                            },
                            district = estabelecimento.Bairro,
                            state = new State
                            {
                                stateId = estado.Sigla,
                                stateInternalId = estado.Id.ToString(),
                                stateDescription = estado.Nome
                            },
                            country = new Country
                            {
                                countryCode = estabelecimento.Pais.Iso2,
                                countryInternalId = estabelecimento.Pais.Id,
                                countryDescription = estabelecimento.Pais.Nome
                            },
                            zipCode = estabelecimento.Cep,
                            region = "Zona Central", // Ajuste conforme necessário
                            poBox = "12345", // Ajuste conforme necessário
                            mainAddress = true, // Ajuste conforme necessário
                            shippingAddress = false, // Ajuste conforme necessário
                            billingAddress = true // Ajuste conforme necessário
                        }
                    }
                },
                listOfBankingInformation = new List<BankingInformation>(), // Preencha conforme necessário
                billingInformation = new BillingInformation
                {
                    billingCustomerCode = 1, // Ajuste conforme necessário
                    billingCustomerInternalId = "002", // Ajuste conforme necessário
                    address = new Address
                    {
                        address = estabelecimento.TipoLogradouro + " " + estabelecimento.Logradouro,
                        number = estabelecimento.Numero,
                        complement = estabelecimento.Complemento,
                        city = new City
                        {
                            cityCode = estabelecimento.Cidade.IbgeId.ToString(),
                            cityInternalId = estabelecimento.Cidade.SiafiId,
                            cityDescription = estabelecimento.Cidade.Nome
                        },
                        district = estabelecimento.Bairro,
                        state = new State
                        {
                            stateId = estado.Sigla,
                            stateInternalId = estado.Id.ToString(),
                            stateDescription = estado.Nome
                        },
                        country = new Country
                        {
                            countryCode = estabelecimento.Pais.Iso2,
                            countryInternalId = estabelecimento.Pais.Id,
                            countryDescription = estabelecimento.Pais.Nome
                        },
                        zipCode = estabelecimento.Cep,
                        region = "Zona Central", // Ajuste conforme necessário
                        poBox = "12345", // Ajuste conforme necessário
                        mainAddress = true, // Ajuste conforme necessário
                        shippingAddress = false, // Ajuste conforme necessário
                        billingAddress = true // Ajuste conforme necessário
                    }
                },
                vendorInformation = new VendorInformation
                {
                    vendorClassification = "Classificação", // Ajuste conforme necessário
                    vendorTypeCode = "Tipo1", // Ajuste conforme necessário
                    vendorTypeInternalId = "002", // Ajuste conforme necessário
                    vendorTypeDescription = "Descrição", // Ajuste conforme necessário
                },
                fiscalInformation = new FiscalInformation
                {
                    category = cnpjData.NaturezaJuridica.Descricao,
                    isRetentionAgent = false, // Ajuste conforme necessário
                    taxPayer = new List<TaxPayer>
                    {
                        new TaxPayer
                        {
                            taxName = "Imposto", // Ajuste conforme necessário
                            isPayer = true, // Ajuste conforme necessário
                            mode = "MODO" // Ajuste conforme necessário
                        }
                    }
                },
                creditInformation = new CreditInformation
                {
                    creditIndicator = 1, // Ajuste conforme necessário
                    creditEvaluation = 1, // Ajuste conforme necessário
                    shipmentCreditEvaluation = 1, // Ajuste conforme necessário
                    creditLimit = 100000, // Ajuste conforme necessário
                    creditLimitCurrency = 1, // Ajuste conforme necessário
                    creditLimitDate = DateTime.UtcNow, // Ajuste conforme necessário
                    additionalCreditLimit = 50000, // Ajuste conforme necessário
                    additionalCreditLimitCurrency = "1", // Ajuste conforme necessário
                    additionalCreditLimitDate = DateTime.UtcNow, // Ajuste conforme necessário
                    latePeriods = 0, // Ajuste conforme necessário
                    balanceOfCredit = 50000 // Ajuste conforme necessário
                },
                paymentConditionCode = "001", // Ajuste conforme necessário
                paymentConditionInternalId = "002", // Ajuste conforme necessário
                priceListHeaderItemCode = "PL001", // Ajuste conforme necessário
                priceListHeaderItemInternalId = "PL002", // Ajuste conforme necessário
                carrierCode = 1, // Ajuste conforme necessário
                strategicCustomerType = "VIP", // Ajuste conforme necessário
                rateDiscount = 10, // Ajuste conforme necessário
                sellerCode = "001", // Ajuste conforme necessário
                sellerInternalId = "002", // Ajuste conforme necessário
                classification = "Class A", // Ajuste conforme necessário
                recCreatedBy = "System",
                recCreatedOn = DateTime.UtcNow,
                recModifiedBy = "System",
                recModifiedOn = DateTime.UtcNow,
                creditLimit = 100000,
                lastChangeDate = DateTime.UtcNow,
                optionalValue1 = 1,
                optionalValue2 = 2,
                optionalValue3 = 3,
                patrimony = 10000,
                employeesNumber = 50,
                classificationCompanyId = 1,
                contributor = 1,
                blocked = 0,
                providerShippingPrice = 1000,
                takerType = 1,
                issContributor = 1,
                dependentsNumber = 0,
                publicBody = 0,
                selfEmployedCategory = 0,
                customerVendorIdentityId = 1,
            };
        }
    }
}
