using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Repositories.Regions
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;

        public SQLRegionRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        //GetAll
        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        //GetById
        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

        }

        //Create
        public async Task<Region> CreateAsync(Region region)
        {
            await _context.Regions.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        //Update
        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            region.Id = id;
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _context.SaveChangesAsync();

            return region;
        }

        //Delete
        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }

            _context.Regions.Remove(existingRegion);
            await _context.SaveChangesAsync();

            return existingRegion;
        }
    }
}
