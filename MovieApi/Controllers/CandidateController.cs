using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Core.Context;
using MovieApi.Core.Dtos.Candidate;
using MovieApi.Core.Entites;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private IMapper _mapper { get; }
        public CandidateController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD

        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> createCandidate([FromForm] CandidateCreateDto dto,IFormFile pdfFile)
        {
            var fiveMegaByte = 1024 * 1024 * 5;
            var pdfMineType = "application/pdf";
            if(pdfFile.Length>fiveMegaByte|| pdfFile.ContentType!=pdfMineType)
            {
                return BadRequest("File is not valid");
            }
            var resumeUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", resumeUrl);
            using(var stream=new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }
            var newCandidate = _mapper.Map<Candidate>(dto);
            newCandidate.ResumrUrl = resumeUrl;
            await _context.candidates.AddAsync(newCandidate);
            await _context.SaveChangesAsync();
            return Ok("Candidate saved successfully");

        }
        //Read
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<CandidateGetDto>>> getCandidates()
        {
            var candidates = await _context.candidates.Include(c => c.Job).OrderByDescending(q => q.CreatedAt).ToListAsync();
            var convertedCandidate = _mapper.Map<IEnumerable<CandidateGetDto>>(candidates);
            return Ok(convertedCandidate);
        }

        //Download pdf file
        [HttpGet]
        [Route("download/{url}")]
        public IActionResult downloadPdfFile(string url)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "documents", "pdfs", url);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found");
            }

            var pdfByte=System.IO.File.ReadAllBytes(filePath);
            var file = File(pdfByte, "application/pdf", url);
            return file;
        }
    }
}
