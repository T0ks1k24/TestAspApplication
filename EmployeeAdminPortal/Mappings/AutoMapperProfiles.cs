using AutoMapper;
using EmployeeAdminPortal.Models.Domain;
using EmployeeAdminPortal.Models.DTO.Difficulty;
using EmployeeAdminPortal.Models.DTO.Region;
using EmployeeAdminPortal.Models.DTO.Walk;

namespace EmployeeAdminPortal.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Region Mapping
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            //Walk Mapping
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            CreateMap<Difficulty, DifficultyDto>().ReverseMap();



        }

    }

}
