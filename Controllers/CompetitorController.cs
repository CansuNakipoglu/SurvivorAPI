namespace SurvivorAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SurvivorAPI.Data;
    using SurvivorAPI.Model.DTOs;
    using SurvivorAPI.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class CompetitorController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public CompetitorController(SqlDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitorDTO>>> GetCompetitors()
        {
            var competitors = await _context.Competitors.Select(x => new CompetitorDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    CategoryId = x.CategoryId
                }).ToListAsync();

            return Ok(competitors);
        }

        [HttpPost]
        public async Task<ActionResult<CompetitorDTO>> PostCompetitor(CompetitorDTO competitorDTO)
        {
            var competitor = new Competitor
            {
                FirstName = competitorDTO.FirstName,
                LastName = competitorDTO.LastName,
                CategoryId = competitorDTO.CategoryId
            };

            _context.Competitors.Add(competitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompetitors), new { id = competitor.Id }, competitorDTO);
        }
    }
}
