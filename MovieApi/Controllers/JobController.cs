using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Core.Context;
using MovieApi.Core.Dtos.Job;
using MovieApi.Core.Entites;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private IMapper _mapper { get; }
        public JobController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CURD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> createJob([FromBody] JobCreateDto dto)
        {
            var newJob = _mapper.Map<Job>(dto);
            await _context.jobs.AddAsync(newJob);
            await _context.SaveChangesAsync();
            return Ok("Job Created Sucssesfully");
        }

        //Read
        [HttpGet]
        [Route("Job")]
        public async Task<ActionResult<IEnumerable<JobGetDto>>> getJobs()
        {
            var jobs =await _context.jobs.Include(job => job.Compony).OrderByDescending(q=>q.CreatedAt).ToListAsync();  
            var convertedJob = _mapper.Map<IEnumerable<JobGetDto>>(jobs);
            return Ok(convertedJob);
        }
    }
}
