using CNPJValidacao;

public class ModelClass
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
    public string RegisterDate { get; set; }
    public string RegisterSituation { get; set; }
    public string Comments { get; set; }
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
    public int RateDiscount { get; set; }
    public string SellerCode { get; set; }
    public string SellerInternalId { get; set; }
    public string Classification { get; set; }
    public string RecCreatedBy { get; set; }
    public string RecCreatedOn { get; set; }
    public string RecModifiedBy { get; set; }
    public string RecModifiedOn { get; set; }
    public int CreditLimit { get; set; }
    public string LastChangeDate { get; set; }
    public int OptionalValue1 { get; set; }
    public int OptionalValue2 { get; set; }
    public int OptionalValue3 { get; set; }
    public int Patrimony { get; set; }
    public int EmployeesNumber { get; set; }
    public int ClassificationCompanyId { get; set; }
    public int Contributor { get; set; }
    public int Blocked { get; set; }
    public int ProviderShippingPrice { get; set; }
    public int TakerType { get; set; }
    public int IssContributor { get; set; }
    public int DependentsNumber { get; set; }
    public int PublicBody { get; set; }
    public int SelfEmployedCategory { get; set; }
    public int CustomerVendorIdentityId { get; set; }
    public int OtherDeductionsIRRFCalculations { get; set; }
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

public class Address
{
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
}

public class Contact
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Position { get; set; }
}

public class BankingInformation
{
    public string BankName { get; set; }
    public string AccountNumber { get; set; }
    public string Branch { get; set; }
    public string SwiftCode { get; set; }
    public string AccountType { get; set; }
}

public class BillingInformation
{
    public string BillingMethod { get; set; }
    public string BillingFrequency { get; set; }
    public string BillingDate { get; set; }
}

public class VendorInformation
{
    public string VendorType { get; set; }
    public string VendorStatus { get; set; }
}

public class FiscalInformation
{
    public string FiscalRegime { get; set; }
    public string FiscalStatus { get; set; }
}

public class CreditInformation
{
    public int CreditLimit { get; set; }
    public int CreditAvailable { get; set; }
    public int CreditUsed { get; set; }
}

public class ComplementaryFields
{
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
    public string Field4 { get; set; }
}
