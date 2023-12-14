using InsuranceTest.Models.Entities;

namespace InsuranceTest.Models.Contract
{
    public interface ICompensationRequestRepository
    {
        Task<CompensationRequest?> GetById(int id);
        Task<CompensationRequest> InsertAsync(CompensationRequest Cover);
    }
}
