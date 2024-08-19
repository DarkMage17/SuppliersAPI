using Microsoft.EntityFrameworkCore;
using SuppliersAPI.Data.Interfaces;
using SuppliersAPI.Entities;

namespace SuppliersAPI.Data.DataAccess
{
    public class SupplierDA : ISupplierDA
    {
        public readonly AppDbContext DbContext;
        public SupplierDA(AppDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task AddSupplier(Supplier Supplier)
        {
            await DbContext.Suppliers.AddAsync(Supplier);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteSupplier(int Id)
        {
            Supplier? FoundSupplier = await DbContext.Suppliers.FindAsync(Id);
            if (FoundSupplier != null)
            {
                DbContext.Suppliers.Remove(FoundSupplier);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            List<Supplier> Suppliers = await DbContext.Suppliers.OrderByDescending(x => x.LastEdit).ToListAsync();
            return Suppliers;
        }

        public async Task<Supplier?> GetSupplierById(int Id)
        {
            Supplier? FoundSupplier = await DbContext.Suppliers.FindAsync(Id);
            return FoundSupplier;
        }

        public async Task UpdateSupplier(Supplier Supplier)
        {
            Supplier? FoundSupplier = await DbContext.Suppliers.FindAsync(Supplier.Id);
            if (FoundSupplier != null) 
            {
                FoundSupplier.CompanyName = Supplier.CompanyName;
                FoundSupplier.TradeName = Supplier.TradeName;
                FoundSupplier.PhoneNumber = Supplier.PhoneNumber;
                FoundSupplier.PhysicalAddress = Supplier.PhysicalAddress;
                FoundSupplier.AnnualBilling = Supplier.AnnualBilling;
                FoundSupplier.Email = Supplier.Email;
                FoundSupplier.TaxIdentification = Supplier.TaxIdentification;
                FoundSupplier.Website = Supplier.Website;
                FoundSupplier.Country = Supplier.Country;
                FoundSupplier.LastEdit = DateTime.Now;

                await DbContext.SaveChangesAsync();
            }
        }
    }
}
