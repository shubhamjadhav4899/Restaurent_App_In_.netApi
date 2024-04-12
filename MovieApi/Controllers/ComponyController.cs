using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Core.Context;
using MovieApi.Core.Dtos.Compony;
using MovieApi.Core.Entites;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponyController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private IMapper _mapper { get; }
        public ComponyController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD
        //CREATE

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> createCompony([FromBody] ComponyCreateDto dto)
        {
            Compony newCompony= _mapper.Map<Compony>(dto);
            await _context.componies.AddAsync(newCompony);
            await _context.SaveChangesAsync();
            return Ok("Compony created sucssesfully"); 
        }
        //READ
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<ComponyGetDto>>> getComponies()
        {
            
            
            
            
            
            
            
            
            
            
            
            
            var componies = await _context.componies.OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedCompanies = _mapper.Map<IEnumerable<ComponyGetDto>>(componies);
            return Ok(convertedCompanies);
        }

        //Read compony by ID


        //UPDATE
        //DELETE
    }
}
