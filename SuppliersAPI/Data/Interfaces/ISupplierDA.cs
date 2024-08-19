using SuppliersAPI.Entities;

namespace SuppliersAPI.Data.Interfaces
{
    public interface ISupplierDA
    {
        Task<List<Supplier>> GetAllSuppliers();
        Task<Supplier?> GetSupplierById(int Id);
        Task AddSupplier(Supplier Supplier);
        Task UpdateSupplier(Supplier Supplier);
        Task DeleteSupplier(int Id);
    }
}
