using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LastOneStanding.Entities;
using LastOneStanding.Context;

[Route("api/[controller]")]
[ApiController]
public class CompetitorsController : ControllerBase
{
    private readonly SurvivorDbContext _context;

    public CompetitorsController(SurvivorDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompetitors()
    {
        var competitors = await _context.Competitors
            .Select(c => new
            {
                c.Id,
                c.FirstName,
                c.LastName,
                CategoryName = _context.Categories
                    .Where(cat => cat.Id == c.CategoryId)
                    .Select(cat => cat.CategoryType.ToString())
                    .FirstOrDefault(),
                c.CreatedDate,
                c.ModifiedDate,
                c.IsDeleted
            })
            .ToListAsync();

        return Ok(competitors);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Competitors>> GetCompetitor(int id)
    {
        var competitor = await _context.Competitors
            .FirstOrDefaultAsync(c => c.Id == id);

        if (competitor == null)
        {
            return NotFound();
        }

        return competitor;
    }

    [HttpGet("categories/{CategoryId}")]
    public async Task<ActionResult<IEnumerable<Competitors>>> GetCompetitorsByCategoryId(int CategoryId)
    {
        var competitors = await _context.Competitors
            .Where(c => c.CategoryId == CategoryId)
            .ToListAsync();

        return competitors;
    }

    [HttpPost]
    public async Task<ActionResult<Competitors>> CreateCompetitor([FromBody] Competitors newCompetitor)
    {
        _context.Competitors.Add(newCompetitor);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCompetitor), new { id = newCompetitor.Id }, newCompetitor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompetitor(int id, [FromBody] Competitors updatedCompetitor)
    {
        if (id != updatedCompetitor.Id)
        {
            return BadRequest();
        }

        _context.Entry(updatedCompetitor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CompetitorExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetitor(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null)
        {
            return NotFound();
        }

        _context.Competitors.Remove(competitor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CompetitorExists(int id)
    {
        return _context.Competitors.Any(e => e.Id == id);
    }
}
