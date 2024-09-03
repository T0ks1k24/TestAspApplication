using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Domain;
using EmployeeAdminPortal.Models.DTO.Difficulty;
using EmployeeAdminPortal.Models.DTO.Region;
using EmployeeAdminPortal.Models.DTO.Walk;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Repositories.Walks
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _context;

        public SQLWalkRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
        {
            var walks = _context.Walks
                .Include("Difficulty")
                .Include("Region")
                .AsQueryable();


            //Filter
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Lenght", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            return await walks.ToListAsync();
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _context.Walks.AddAsync(walk);
            await _context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            walk.Id = id;
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _context.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = _context.Walks.FirstOrDefault(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            _context.Remove(existingWalk);
            await _context.SaveChangesAsync();

            return existingWalk;
        }
    }
}
