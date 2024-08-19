namespace SuppliersAPI.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string TradeName { get; set; }
        public required string TaxIdentification { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Website { get; set; }
        public required string PhysicalAddress { get; set; }
        public required string Country { get; set; }
        public required decimal AnnualBilling { get; set; }
        public DateTime LastEdit { get; set; }
    }
}
