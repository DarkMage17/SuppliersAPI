using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuppliersAPI.Entities;
using SuppliersAPI.Services;

namespace SuppliersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : Controller
    {
        private readonly SupplierService SupplierService;
        public SuppliersController(SupplierService SupplierService)
        {
            this.SupplierService = SupplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            List<Supplier> Suppliers = await SupplierService.GetAllSuppliers();
            return StatusCode(StatusCodes.Status200OK, Suppliers);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSupplierById(int Id)
        {
            Supplier? FoundSupplier = await SupplierService.GetSupplierById(Id);
            if (FoundSupplier == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, FoundSupplier);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(Supplier Supplier)
        {
            try
            {
                bool response = await SupplierService.AddSupplier(Supplier);
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = false });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(Supplier Supplier)
        {
            try
            {
                bool response = await SupplierService.UpdateSupplier(Supplier);
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = false });
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteSupplier(int Id)
        {
            try
            {
                bool response = await SupplierService.DeleteSupplier(Id);
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = response });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { isSuccess = false });
            }
        }
    }
}
