using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Module32_MVC.Models.DB;
using System;
using System.Threading.Tasks;

namespace Module32_MVC.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppContext _context;

        public BlogRepository(AppContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }

        [HttpPost]
        public async Task Register(User user)
        {
            user.JoinDate = DateTime.Now;
            user.Id = Guid.NewGuid();

            // Добавление пользователя
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изменений
            await _context.SaveChangesAsync();
            //return Content($"Registration successful, {user.FirstName}");
        }
    }
}
