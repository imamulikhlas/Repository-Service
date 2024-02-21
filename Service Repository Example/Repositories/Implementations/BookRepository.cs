using Microsoft.EntityFrameworkCore;
using Service_Repository_Example.Models;
using Service_Repository_Example.Repositories.Interface;
using Service_Repository_Example.Data;

namespace Service_Repository_Example.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.book.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.book.FindAsync(id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.book.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await GetByIdAsync(id);
            if (book != null)
            {
                _context.book.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
