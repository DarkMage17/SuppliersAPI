using SuppliersAPI.Data.Interfaces;
using SuppliersAPI.Entities;

namespace SuppliersAPI.Services
{
    public class SupplierService
    {
        private readonly ISupplierDA SupplierDA;
        public SupplierService(ISupplierDA SupplierDA)
        {
            this.SupplierDA = SupplierDA;
        }

        public async Task<List<Supplier>> GetAllSuppliers()
        {
            try
            {
                return await SupplierDA.GetAllSuppliers();
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al obtener los proveedores", ex);
            }
        }

        public async Task<Supplier?> GetSupplierById(int Id)
        {
            try
            {
                return await SupplierDA.GetSupplierById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Hubo un error al obtener el proveedor con Id: " + Id, ex);
            }
        }

        public async Task<bool> AddSupplier(Supplier Supplier)
        {
            try
            {
                Supplier.LastEdit = DateTime.Now;
                await SupplierDA.AddSupplier(Supplier);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateSupplier(Supplier Supplier)
        {
            try
            {
                await SupplierDA.UpdateSupplier(Supplier);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteSupplier(int Id)
        {
            try
            {
                await SupplierDA.DeleteSupplier(Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
