using InsuranceTest.Models.Contract;
using InsuranceTest.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceTest.Models.DAL
{
    public class InsuranceCoverRepository : IInsuranceCoverRepository
    {
        private readonly ApplicationDbContext _ctx;
        public InsuranceCoverRepository(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public async Task<IEnumerable<InsuranceCover>> GetAllAsync()
        {
            return await _ctx.InsuranceCover.ToListAsync();
        }
    }
}
