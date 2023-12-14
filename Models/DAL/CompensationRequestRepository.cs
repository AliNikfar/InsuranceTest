using InsuranceTest.Models.Contract;
using InsuranceTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceTest.Models.DAL
{
    public class CompensationRequestRepository : ICompensationRequestRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CompensationRequestRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }


        public async Task<CompensationRequest?> GetById(int id)
        {
            var existRequest = await _ctx.CompensationRequest.Where(p => p.Id == id).FirstOrDefaultAsync();
            if(existRequest is not null)
            {
                return existRequest;
            }
            return null;
        }

        public async Task<CompensationRequest> InsertAsync(CompensationRequest req)
        {
            await _ctx.CompensationRequest.AddAsync(req);
            await _ctx.SaveChangesAsync();
            return req;
        }
    }
}
