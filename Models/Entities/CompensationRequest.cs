using System.ComponentModel.DataAnnotations;

namespace InsuranceTest.Models.Entities
{
    public class CompensationRequest : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public float Fund { get; set; }

        public float? DentalFund { get; set; }
        public float? SurgeryFund { get; set; }
        public float? HospitalizationFund { get; set; }


    }
}
