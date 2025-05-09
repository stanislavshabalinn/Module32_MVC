﻿using Microsoft.EntityFrameworkCore;
using Module32_MVC.Models.DB;
using System.Threading.Tasks;

namespace Module32_MVC.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppContext _context;

        public RequestRepository(AppContext context)
        {
            _context = context;
        }

        public async Task AddRequest( Request request)
        {
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
