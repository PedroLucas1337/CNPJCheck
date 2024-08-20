using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YourNamespace;

namespace CNPJValidacao
{
    public class MarketSegment
    {
        public string marketSegmentCode { get; set; }
        public string marketSegmentInternalId { get; set; }
        public string marketSegmentDescription { get; set; }
    }

    public class GovernmentalInformation
    {
        public List<string> Id { get; set; }
        public string scope { get; set; }
        public string name { get; set; }
        public DateTime issueOn { get; set; }
        public DateTime expiresOn { get; set; }
    }

    public class City
    {
        public string cityCode { get; set; }
        public string cityInternalId { get; set; }
        public string cityDescription { get; set; }
    }

    public class State
    {
        public string stateId { get; set; }
        public string stateInternalId { get; set; }
        public string stateDescription { get; set; }
    }

    public class Country
    {
        public string countryCode { get; set; }
        public string countryInternalId { get; set; }
        public string countryDescription { get; set; }
    }

    public class Address
    {
        public string address { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public City city { get; set; }
        public string district { get; set; }
        public State state { get; set; }
        public Country country { get; set; }
        public string zipCode { get; set; }
        public string region { get; set; }
        public string poBox { get; set; }
        public bool mainAddress { get; set; }
        public bool shippingAddress { get; set; }
        public bool billingAddress { get; set; }
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

    public class ContactInformation
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
        public int bankCode { get; set; }
        public string bankInternalId { get; set; }
        public string bankName { get; set; }
        public string branchCode { get; set; }
        public string branchKey { get; set; }
        public string checkingAccountNumber { get; set; }
        public string checkingAccountNumberKey { get; set; }
        public string checkingAccountType { get; set; }
        public string mainAccount { get; set; }
        public string currencyAccount { get; set; }
    }

    public class BillingInformation
    {
        public int billingCustomerCode { get; set; }
        public string billingCustomerInternalId { get; set; }
        public Address address { get; set; }
    }

    public class VendorInformation
    {
        public string vendorClassification { get; set; }
        public string vendorTypeCode { get; set; }
        public string vendorTypeInternalId { get; set; }
        public string vendorTypeDescription { get; set; }
    }

    public class TaxPayer
    {
        public string taxName { get; set; }
        public bool isPayer { get; set; }
        public string mode { get; set; }
    }

    public class FiscalInformation
    {
        public string category { get; set; }
        public bool isRetentionAgent { get; set; }
        public List<TaxPayer> taxPayer { get; set; }
    }

    public class CreditInformation
    {
        public int creditIndicator { get; set; }
        public int creditEvaluation { get; set; }
        public int shipmentCreditEvaluation { get; set; }
        public int creditLimit { get; set; }
        public int creditLimitCurrency { get; set; }
        public DateTime creditLimitDate { get; set; }
        public int additionalCreditLimit { get; set; }
        public string additionalCreditLimitCurrency { get; set; }
        public DateTime additionalCreditLimitDate { get; set; }
        public int latePeriods { get; set; }
        public int balanceOfCredit { get; set; }
    }

    public class ModelClass
    {
        public string customerVendorId { get; set; }
        public string companyId { get; set; }
        public string branchId { get; set; }
        public string companyInternalId { get; set; }
        public string code { get; set; }
        public string storeId { get; set; }
        public string internalId { get; set; }
        public string shortName { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string entityType { get; set; }
        public MarketSegment marketsegment { get; set; }
        public DateTime registerdate { get; set; }
        public string registerSituation { get; set; }
        public string comments { get; set; }
        public List<GovernmentalInformation> governmentalInformation { get; set; }
        public Address address { get; set; }
        public Address shippingAddress { get; set; }
        public List<CommunicationInformation> listOfCommunicationInformation { get; set; }
        public List<ContactInformation> listOfContacts { get; set; }
        public List<BankingInformation> listOfBankingInformation { get; set; }
        public BillingInformation billingInformation { get; set; }
        public VendorInformation vendorInformation { get; set; }
        public FiscalInformation fiscalInformation { get; set; }
        public CreditInformation creditInformation { get; set; }
        public string paymentConditionCode { get; set; }
        public string paymentConditionInternalId { get; set; }
        public string priceListHeaderItemCode { get; set; }
        public string priceListHeaderItemInternalId { get; set; }
        public int carrierCode { get; set; }
        public string strategicCustomerType { get; set; }
        public int rateDiscount { get; set; }
        public string sellerCode { get; set; }
        public string sellerInternalId { get; set; }
        public string classification { get; set; }
        public string recCreatedBy { get; set; }
        public DateTime recCreatedOn { get; set; }
        public string recModifiedBy { get; set; }
        public DateTime recModifiedOn { get; set; }
        public int creditLimit { get; set; }
        public DateTime lastChangeDate { get; set; }
        public int optionalValue1 { get; set; }
        public int optionalValue2 { get; set; }
        public int optionalValue3 { get; set; }
        public int patrimony { get; set; }
        public int employeesNumber { get; set; }
        public int classificationCompanyId { get; set; }
        public int contributor { get; set; }
        public int blocked { get; set; }
        public int providerShippingPrice { get; set; }
        public int takerType { get; set; }
        public int issContributor { get; set; }
        public int dependentsNumber { get; set; }
        public int publicBody { get; set; }
        public int selfEmployedCategory { get; set; }
        public int customerVendorIdentityId { get; set; }
        public int otherDeductionsIRRFCalculations { get; set; }
        public string issRegime { get; set; }
        public string issRetentionResponsible { get; set; }
        public int fuelOperationType { get; set; }
        public int size { get; set; }
        public int activityBranch { get; set; }
        public int typeContributorINSS { get; set; }
        public int nationality { get; set; }
        public int taxCodeColcfo { get; set; }
        public int calculatesAVP { get; set; }
        public string nif { get; set; }
        public int nifSituation { get; set; }
        public string incomeType { get; set; }
        public string taxationForm { get; set; }
        public int innovate_auto { get; set; }
        public string formulaApplication { get; set; }
        public string automaticDebitCheckerType { get; set; }
        public string executingEntityPaa { get; set; }
        public int ownWork { get; set; }
        public int retiredPensioner { get; set; }
        public int socialCategoryId { get; set; }
        public int cooperativePartner { get; set; }
        public ComplementaryFields complementaryFields { get; set; }
    }

    public class ComplementaryFields
    {
        public int codcoligada { get; set; }
        public string codCfo { get; set; }
        public string vendedor { get; set; }
        public string comprador { get; set; }
        public int diasAtraso { get; set; }
        public string recCreatedBy { get; set; }
        public DateTime recCreatedOn { get; set; }
        public string recModifiedBy { get; set; }
        public DateTime recModifiedOn { get; set; }
    }

}