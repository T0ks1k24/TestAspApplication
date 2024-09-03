using AutoMapper;
using EmployeeAdminPortal.CustomActionFilters;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Domain;
using EmployeeAdminPortal.Models.DTO.Region;
using EmployeeAdminPortal.Repositories.Regions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        #region DDD
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }
        #endregion

        #region GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsDomain = await _regionRepository.GetAllAsync();

            return Ok(_mapper.Map<List<RegionDto>>(regionsDomain));
        }
        #endregion

        #region GetById 
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regionDomainModel = await _regionRepository.GetByIdAsync(id);

            if (regionDomainModel is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));
        }
        #endregion

        #region Create
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto regionAdd)
        {
            var regionDomainModel = _mapper.Map<Region>(regionAdd);

            await _regionRepository.CreateAsync(regionDomainModel);

            var regionDto = _mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);

        }
        #endregion

        #region Update
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto regionUpdate)
        {
            var regionDomainModel = _mapper.Map<Region>(regionUpdate);

            regionDomainModel = await _regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(regionDomainModel));

        }
        #endregion

        #region DeleteById
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteRegion = await _regionRepository.DeleteAsync(id);

            return Ok(_mapper.Map<RegionDto>(deleteRegion));
        }
        #endregion

    }
}
