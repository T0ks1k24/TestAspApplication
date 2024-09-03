using AutoMapper;
using EmployeeAdminPortal.CustomActionFilters;
using EmployeeAdminPortal.Models.Domain;
using EmployeeAdminPortal.Models.DTO.Walk;
using EmployeeAdminPortal.Repositories.Walks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        #region DDD
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }
        #endregion

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool isAscending)
        {
            var walkDomain = await _walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending);

            return Ok(_mapper.Map<List<Walk>>(walkDomain));
        }
        #endregion

        #region Create
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto walkAdd)
        {
            var walkDomainModel = _mapper.Map<Walk>(walkAdd);

            try
            {
                await _walkRepository.CreateAsync(walkDomainModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while saving the walk.");
            }

            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }
        #endregion

        #region Update
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto walkUpdate)
        {
            var walkDomainModel = _mapper.Map<Walk>(walkUpdate);

            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return null;
            }

            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteWalk = await _walkRepository.DeleteAsync(id);
            return Ok(_mapper.Map<WalkDto>(deleteWalk));
        }
        #endregion

    }
}
