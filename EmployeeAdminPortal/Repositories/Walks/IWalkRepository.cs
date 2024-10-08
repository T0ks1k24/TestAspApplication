﻿using EmployeeAdminPortal.Models.Domain;

namespace EmployeeAdminPortal.Repositories.Walks
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string filterQuery = null, string? sortBy = null, bool isAscending = true);
        Task<Walk> CreateAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
        
    }
}
