using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LastOneStanding.Entities;
using LastOneStanding.Context;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly SurvivorDbContext _context;

    public CategoriesController(SurvivorDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<object>>> GetCategories()
    {
        var categories = await _context.Categories
            .Select(c => new
            {
                c.Id,
                c.CategoryType,
                CategoryTypeName = c.CategoryType.ToString(),
                CreatedDate = c.CreatedDate,
                ModifiedDate = c.ModifiedDate,
                IsDeleted = c.IsDeleted,
                Competitors = _context.Competitors
                    .Where(comp => comp.CategoryId == c.Id)
                    .Select(comp => new
                    {
                        FullName = $"{comp.FirstName} {comp.LastName}"
                    })
                    .ToList()
            })
            .ToListAsync();

        return Ok(categories);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetCategory(int id)
    {
        var category = await _context.Categories
            .Where(c => c.Id == id)
            .Select(c => new
            {
                c.Id,
                c.CategoryType,
                CategoryTypeName = c.CategoryType.ToString(),
                CreatedDate = c.CreatedDate,
                ModifiedDate = c.ModifiedDate,
                IsDeleted = c.IsDeleted,
                Competitors = _context.Competitors
                    .Where(comp => comp.CategoryId == c.Id)
                    .Select(comp => new
                    {
                        FullName = $"{comp.FirstName} {comp.LastName}"
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }
}

