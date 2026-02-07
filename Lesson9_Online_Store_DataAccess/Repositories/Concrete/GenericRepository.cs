using Lesson9_Online_Store_DataAccess.Contexts;
using Lesson9_Online_Store_Domain.Entities.Abstracts;
using Lesson9_Online_Store_DataAccess.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Lesson9_Online_Store_DataAccess.Repositories.Concrete;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsnyc(int id)
    {
        var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        if (entity is null)
            return;

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);

        await _context.SaveChangesAsync();
    }
}
