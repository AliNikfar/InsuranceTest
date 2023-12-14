using InsuranceTest.Models.Entities;

namespace InsuranceTest.Models.Contract
{
    public interface IInsuranceCoverRepository
    {
        Task<IEnumerable<InsuranceCover>> GetAllAsync();

    }
}
