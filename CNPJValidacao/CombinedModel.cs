using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace YourNamespace
{
    public class CombinedModel
    {
        // Propriedades do CNPJ
        [JsonProperty("cnpjData")]
        public CNPJData CNPJData { get; set; }

        // Propriedades do TOTVS RM
        [JsonProperty("customerVendor")]
        public CustomerVendor CustomerVendor { get; set; }
    }

    // Modelos do CNPJ
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
    }

    public class InscricaoEstadual
    {
        [JsonProperty("inscricao_estadual")]
        public string NumeroInscricao { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }
    }

    // Modelos do TOTVS RM
    public class CustomerVendor
    {
        public string CustomerVendorId { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string CompanyInternalId { get; set; }
        public string Code { get; set; }
        public string StoreId { get; set; }
        public string InternalId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string EntityType { get; set; }
        public MarketSegment MarketSegment { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterSituation { get; set; }
        public string Comments { get; set; }
        public List<GovernmentalInformation> GovernmentalInformation { get; set; }
        public Address Address { get; set; }
        public Address ShippingAddress { get; set; }
        public List<CommunicationInformation> ListOfCommunicationInformation { get; set; }
        public List<Contact> ListOfContacts { get; set; }
        public List<BankingInformation> ListOfBankingInformation { get; set; }
        public BillingInformation BillingInformation { get; set; }
        public VendorInformation VendorInformation { get; set; }
        public FiscalInformation FiscalInformation { get; set; }
        public CreditInformation CreditInformation { get; set; }
        public string PaymentConditionCode { get; set; }
        public string PaymentConditionInternalId { get; set; }
        public string PriceListHeaderItemCode { get; set; }
        public string PriceListHeaderItemInternalId { get; set; }
        public int CarrierCode { get; set; }
        public string StrategicCustomerType { get; set; }
        public decimal RateDiscount { get; set; }
        public string SellerCode { get; set; }
        public string SellerInternalId { get; set; }
        public string Classification { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedOn { get; set; }
        public string RecModifiedBy { get; set; }
        public DateTime RecModifiedOn { get; set; }
        public decimal CreditLimit { get; set; }
        public DateTime LastChangeDate { get; set; }
        public decimal OptionalValue1 { get; set; }
        public decimal OptionalValue2 { get; set; }
        public decimal OptionalValue3 { get; set; }
        public decimal Patrimony { get; set; }
        public int EmployeesNumber { get; set; }
        public int ClassificationCompanyId { get; set; }
        public int Contributor { get; set; }
        public int Blocked { get; set; }
        public decimal ProviderShippingPrice { get; set; }
        public int TakerType { get; set; }
        public int IssContributor { get; set; }
        public int DependentsNumber { get; set; }
        public int PublicBody { get; set; }
        public int SelfEmployedCategory { get; set; }
        public int CustomerVendorIdentityId { get; set; }
        public decimal OtherDeductionsIRRFCalculations { get; set; }
        public string IssRegime { get; set; }
        public string IssRetentionResponsible { get; set; }
        public int FuelOperationType { get; set; }
        public int Size { get; set; }
        public int ActivityBranch { get; set; }
        public int TypeContributorINSS { get; set; }
        public int Nationality { get; set; }
        public int TaxCodeColcfo { get; set; }
        public int CalculatesAVP { get; set; }
        public string Nif { get; set; }
        public int NifSituation { get; set; }
        public string IncomeType { get; set; }
        public string TaxationForm { get; set; }
        public int InnovateAuto { get; set; }
        public string FormulaApplication { get; set; }
        public string AutomaticDebitCheckerType { get; set; }
        public string ExecutingEntityPaa { get; set; }
        public int OwnWork { get; set; }
        public int RetiredPensioner { get; set; }
        public int SocialCategoryId { get; set; }
        public int CooperativePartner { get; set; }
        public ComplementaryFields ComplementaryFields { get; set; }
    }

    public class MarketSegment
    {
        public string MarketSegmentCode { get; set; }
        public string MarketSegmentInternalId { get; set; }
        public string MarketSegmentDescription { get; set; }
    }

    public class GovernmentalInformation
    {
        public List<string> Id { get; set; }
        public string Scope { get; set; }
        public string Name { get; set; }
        public DateTime IssueOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }

    public class Address
    {
        public string AddressLine { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public City City { get; set; }
        public string District { get; set; }
        public State State { get; set; }
        public Country Country { get; set; }
        public string ZipCode { get; set; }
        public string Region { get; set; }
        public string PoBox { get; set; }
        public bool MainAddress { get; set; }
        public bool ShippingAddress { get; set; }
        public bool BillingAddress { get; set; }
    }

    public class City
    {
        public string CityCode { get; set; }
        public string CityInternalId { get; set; }
        public string CityDescription { get; set; }
    }

    public class State
    {
        public string StateId { get; set; }
        public string StateInternalId { get; set; }
        public string StateDescription { get; set; }
    }

    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryInternalId { get; set; }
        public string CountryDescription { get; set; }
    }

    public class CommunicationInformation
    {
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExtension { get; set; }
        public string FaxNumber { get; set; }
        public string FaxNumberExtension { get; set; }
        public string HomePage { get; set; }
        public string Email { get; set; }
        public string DiallingCode { get; set; }
        public string InternationalDiallingCode { get; set; }
    }

    public class Contact
    {
        public string ContactInformationCode { get; set; }
        public string ContactInformationInternalId { get; set; }
        public string ContactInformationTitle { get; set; }
        public string ContactInformationName { get; set; }
        public string ContactInformationDepartment { get; set; }
        public CommunicationInformation CommunicationInformation { get; set; }
        public Address ContactInformationAddress { get; set; }
    }

    public class BankingInformation
    {
        public int BankCode { get; set; }
        public string BankInternalId { get; set; }
        public string BankName { get; set; }
        public string BranchCode { get; set; }
        public string BranchKey { get; set; }
        public string CheckingAccountNumber { get; set; }
        public string CheckingAccountNumberKey { get; set; }
        public string CheckingAccountType { get; set; }
        public string MainAccount { get; set; }
        public string CurrencyAccount { get; set; }
    }

    public class BillingInformation
    {
        public int BillingCustomerCode { get; set; }
        public string BillingCustomerInternalId { get; set; }
        public Address Address { get; set; }
    }

    public class VendorInformation
    {
        public string VendorClassification { get; set; }
        public string VendorTypeCode { get; set; }
        public string VendorTypeInternalId { get; set; }
        public string VendorTypeDescription { get; set; }
    }

    public class FiscalInformation
    {
        public string Category { get; set; }
        public bool IsRetentionAgent { get; set; }
        public List<TaxPayer> TaxPayer { get; set; }
    }

    public class TaxPayer
    {
        public string TaxName { get; set; }
        public bool IsPayer { get; set; }
        public string Mode { get; set; }
    }

    public class CreditInformation
    {
        public int CreditIndicator { get; set; }
        public int CreditEvaluation { get; set; }
        public int ShipmentCreditEvaluation { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditLimitCurrency { get; set; }
        public DateTime CreditLimitDate { get; set; }
        public decimal AdditionalCreditLimit { get; set; }
        public string AdditionalCreditLimitCurrency { get; set; }
        public DateTime AdditionalCreditLimitDate { get; set; }
        public int LatePeriods { get; set; }
        public decimal BalanceOfCredit { get; set; }
    }

    public class ComplementaryFields
    {
        public int Codcoligada { get; set; }
        public string CodCfo { get; set; }
        public string Vendedor { get; set; }
        public string Comprador { get; set; }
        public int DiasAtraso { get; set; }
        public string RecCreatedBy { get; set; }
        public DateTime RecCreatedOn { get; set; }
        public string RecModifiedBy { get; set; }
        public DateTime RecModifiedOn { get; set; }
    }
}
