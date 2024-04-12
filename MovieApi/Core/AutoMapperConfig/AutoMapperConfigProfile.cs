using AutoMapper;
using MovieApi.Core.Dtos.Candidate;
using MovieApi.Core.Dtos.Compony;
using MovieApi.Core.Dtos.Job;
using MovieApi.Core.Entites;

namespace MovieApi.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile() {
            //Compony
            CreateMap<ComponyCreateDto, Compony>();
            CreateMap<Compony, ComponyGetDto>();
            //Job
            CreateMap<JobCreateDto, Job>();

            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.componyName, opt => opt.MapFrom(src => src.Compony.Name));
            //Candidate
            CreateMap<CandidateCreateDto, Candidate>();
            CreateMap<Candidate, CandidateGetDto>()
                .ForMember(dest => dest.jobTitle, opt => opt.MapFrom(src => src.Job.Title));
        }
    }
}
