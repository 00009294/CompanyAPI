using CompanyAPI.DbConstants;
using CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext appDbContext;


        public async Task<ICollection<Company>> GetAllAsync()
        {
            try
            {
                return await this.appDbContext.Companies.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public CompanyService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<bool> CreateAsync(Company company)
        {
            try
            {
                var addedItem = await this.appDbContext.AddAsync(company);
                await this.appDbContext.SaveChangesAsync();
                return addedItem != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var deletedItem = await this.appDbContext.Companies.FindAsync(id);
                if(deletedItem != null)
                {
                    this.appDbContext.Companies.Remove(deletedItem);
                    await this.appDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public async Task<Company> GetByIdAsync(int id)
        {
            var selectedItem = await this.appDbContext.Companies.FindAsync(id);
            if(selectedItem != null)
            {
                return selectedItem;
            }
            return null;
            
        }

        public async Task<bool> UpdateAsync(int id, Company company)
        {
            try
            {
                var updatedItem = await this.appDbContext.Companies.FindAsync(id);
                if (updatedItem != null)
                {
                    updatedItem.Id = company.Id;
                    updatedItem.Name= company.Name;
                    await this.appDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
