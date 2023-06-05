using CompanyAPI.Models;

namespace CompanyAPI.Services
{
    public interface ICompanyService
    {
        Task<ICollection<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int id);
        Task<bool> CreateAsync(Company company);
        Task<bool> UpdateAsync(int id, Company company);
        Task<bool> DeleteAsync(int id);

    }
}
